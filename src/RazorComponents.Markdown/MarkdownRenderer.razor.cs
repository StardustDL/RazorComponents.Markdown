using Ganss.XSS;
using Markdig;
using Markdig.Extensions.MediaLinks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Modulight.Modules.Hosting;
using StardustDL.RazorComponents.Markdown.Extensions;
using System;
using System.Threading.Tasks;

namespace StardustDL.RazorComponents.Markdown
{
    public partial class MarkdownRenderer : ComponentBase
    {
        [Parameter]
        public string Value { get; set; } = "";

        [Parameter]
        public string Style { get; set; } = "";

        [Parameter]
        public string Class { get; set; } = "";

        [Parameter]
        public TimeSpan? RenderInterval { get; set; } = null;

        [Parameter]
        public bool EnableCodeHighlighting { get; set; } = true;

        [Parameter]
        public bool EnableDiagrams { get; set; } = true;

        [Parameter]
        public bool EnableMathematics { get; set; } = true;

        [Parameter]
        public bool EnableHtmlSanitizing { get; set; } = true;

        private string Html { get; set; } = "";

        private string? OldValue { get; set; } = null;

        private DateTimeOffset? LastRender { get; set; } = null;

        private bool ScheduledRender { get; set; } = false;

        private string BaseUrl { get; set; } = "";

        private ElementReference markdownContent;

        protected override void OnInitialized()
        {
            BaseUrl = NavigationManager.ToBaseRelativePath(NavigationManager.Uri);
            var ind = BaseUrl.IndexOf('#');
            if (ind >= 0)
                BaseUrl = BaseUrl.Remove(ind);
        }

        protected override async Task OnParametersSetAsync()
        {
            if (LastRender is null) // Havn't rendered
            {
                await Rerender();
            }
            else if (Value != OldValue) // Only render when changed
            {
                if (RenderInterval is null) // No delay rendering
                {
                    await Rerender();
                }
                else
                {
                    var interval = DateTimeOffset.Now - LastRender.Value;
                    if (interval >= RenderInterval.Value) // Exceed the interval after last rendering
                    {
                        await Rerender();
                    }
                    else if (!ScheduledRender) // Havn't schedule rendering
                    {
                        ScheduledRender = true;
                        _ = Task.Delay(RenderInterval.Value - interval).ContinueWith(async _ =>
                        {
                            if (Value != OldValue && (RenderInterval is null || DateTimeOffset.Now - LastRender.Value >= RenderInterval.Value))
                            {
                                await Rerender();
                            }
                            ScheduledRender = false;
                        });
                    }
                }
            }
            await base.OnParametersSetAsync();
        }
        protected virtual MarkdownPipeline GetPipeline()
        {
            MediaOptions mediaOptions = new MediaOptions();
            mediaOptions.Hosts.Add(new BilibiliMediaLinkHost());
            mediaOptions.Hosts.Add(new NeteaseMusicMediaLinkHost());

            var builder = new MarkdownPipelineBuilder();
            builder.UseAbbreviations()
                .UseAutoIdentifiers()
                .UseCitations()
                .UseCustomContainers()
                .UseDefinitionLists()
                .UseEmphasisExtras()
                .UseFigures()
                .UseFooters()
                .UseFootnotes()
                .UseGridTables()
                .UseMediaLinks(mediaOptions)
                .UsePipeTables()
                .UseListExtras()
                .UseTaskLists()
                .UseAutoLinks()
                .UseSmartyPants()
                .UseEmojiAndSmiley();
            // .UseBootstrap()

            if (EnableMathematics)
                builder.UseMathematics();
            if (EnableDiagrams)
                builder.UseDiagrams();

            builder.UseGenericAttributes(); // Must be last as it is one parser that is modifying other parsers
            return builder.Build();
        }

        protected virtual Task<string> RenderHtml(string value)
        {
            var html = Markdig.Markdown.ToHtml(value, GetPipeline());

            if (EnableHtmlSanitizing)
            {
                html = HtmlSanitizer.Sanitize(html);
            }

            return Task.FromResult(html);
        }

        public async Task Rerender()
        {
            // Logger.LogInformation("Rendering.");
            OldValue = Value;
            LastRender = DateTimeOffset.Now;
            Html = await RenderHtml(OldValue);
            StateHasChanged();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (EnableCodeHighlighting)
            {
                await JSRuntime.InvokeVoidAsync("StardustDL_RazorComponents_Markdown.highlight", markdownContent);
            }
            if (EnableMathematics)
            {
                await JSRuntime.InvokeVoidAsync("StardustDL_RazorComponents_Markdown.math", markdownContent);
            }
            if (EnableDiagrams)
            {
                await JSRuntime.InvokeVoidAsync("StardustDL_RazorComponents_Markdown.diagram", markdownContent);
            }
            await JSRuntime.InvokeVoidAsync("StardustDL_RazorComponents_Markdown.fixAnchor", markdownContent, BaseUrl);
        }
    }
}

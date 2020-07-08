using Markdig;
using Markdig.Extensions.MediaLinks;
using StardustDL.RazorComponents.Markdown.Extensions;

namespace StardustDL.RazorComponents.Markdown
{
    public class MarkdownComponentService : IMarkdownComponentService
    {
        public bool EnableCodeHighlight { get; set; } = true;

        public bool EnableDiagrams { get; set; } = true;

        public bool EnableMathematics { get; set; } = true;

        public virtual MarkdownPipeline GetPipeline()
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
    }
}
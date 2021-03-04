using Modulight.Modules;
using Modulight.Modules.Client.RazorComponents;
using Modulight.Modules.Client.RazorComponents.UI;
using Modulight.Modules.Hosting;

namespace StardustDL.RazorComponents.Markdown
{
    /// <summary>
    /// Extensions for markdown module.
    /// </summary>
    public static class ModuleExtensions
    {
        /// <summary>
        /// Add <see cref="AntDesignModule"/>.
        /// </summary>
        /// <param name="modules"></param>
        /// <returns></returns>
        public static IModuleHostBuilder AddMarkdownModule(this IModuleHostBuilder modules) => modules.AddModule<MarkdownModule>();
    }

    [Module(Description = "Markdown components.", Url = "https://github.com/StardustDL/RazorComponents.Markdown", Author = "StardustDL")]
    [ModuleUIResource(UIResourceType.Script, "_content/StardustDL.RazorComponents.Markdown/component-min.js")]
    [ModuleUIResource(UIResourceType.Script, "_content/StardustDL.RazorComponents.Markdown/mermaid/mermaid.min.js")]
    [ModuleUIResource(UIResourceType.Script, "_content/StardustDL.RazorComponents.Markdown/prismjs/components/prism-core.min.js")]
    [ModuleUIResource(UIResourceType.Script, "_content/StardustDL.RazorComponents.Markdown/prismjs/plugins/autoloader/prism-autoloader.min.js")]
    [ModuleUIResource(UIResourceType.StyleSheet, "_content/StardustDL.RazorComponents.Markdown/prismjs/themes/prism.css")]
    [ModuleUIResource(UIResourceType.StyleSheet, "_content/StardustDL.RazorComponents.Markdown/katex/katex.min.css")]
    [ModuleUIResource(UIResourceType.StyleSheet, "_content/StardustDL.RazorComponents.Markdown/css/markdown.css")]
    [ModuleService(typeof(MarkdownComponentService), ServiceType = typeof(IMarkdownComponentService), Lifetime = Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton, RegisterBehavior = ServiceRegisterBehavior.Optional)]
    public class MarkdownModule : RazorComponentClientModule
    {
        public MarkdownModule(IModuleHost host) : base(host)
        {
        }
    }
}
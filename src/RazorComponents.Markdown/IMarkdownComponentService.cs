using Markdig;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace StardustDL.RazorComponents.Markdown
{
    public interface IMarkdownComponentService
    {
        bool EnableCodeHighlight { get; set; }

        bool EnableDiagrams { get; set; }

        bool EnableMathematics { get; set; }

        MarkdownPipeline GetPipeline();

        Task<string> RenderHtml(string value);
    }

    public static class MarkdownComponentServiceExtensions
    {
        public static IServiceCollection AddMarkdownComponent(this IServiceCollection services)
        {
            return services.AddSingleton<IMarkdownComponentService, MarkdownComponentService>();
        }
    }
}
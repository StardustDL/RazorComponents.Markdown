using Markdig;
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
}
using Markdig;

namespace StardustDL.RazorComponents.Markdown
{
    public interface IMarkdownComponentService
    {
        bool EnableCodeHighlight { get; set; }

        bool EnableDiagrams { get; set; }

        bool EnableMathematics { get; set; }

        MarkdownPipeline GetPipeline();
    }
}
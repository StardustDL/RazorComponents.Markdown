# RazorComponents.Markdown

![CI](https://github.com/StardustDL/RazorComponents.Markdown/workflows/CI/badge.svg) ![CD](https://github.com/StardustDL/RazorComponents.Markdown/workflows/CD/badge.svg) ![License](https://img.shields.io/github/license/StardustDL/RazorComponents.Markdown.svg) [![downloads](https://img.shields.io/nuget/dt/StardustDL.RazorComponents.Markdown)](https://www.nuget.org/packages/StardustDL.RazorComponents.Markdown/)

Razor component for Markdown rendering.

Online demo:

- [GitHub Pages](https://acblog.github.io/posts/article)
- [Gitee Pages](https://acblog.gitee.io/posts/article)

## Features

- Abbreviations
- Auto identifiers
- Citations
- Custom containers
- Definition lists
- Emphasis extras
- Figures
- Footers
- Footnotes
- GridTables
- Mathematics
- Media links
  - Youtube
  - Bilibili
  - Netease music
- Pipe tables
- Task lists
- Diagrams, flowcharts
- Auto links
- Smarty pants
- Emoji
- Code highlighting
- Delay rendering for less CPU intensive
- HTML Sanitizing to prevent XSS

## Usage

Add the newest package on NuGet.

```sh
dotnet add package StardustDL.RazorComponents.Markdown
```

### Install

This project is built on [Modulight](https://github.com/StardustDL/modulight).

Here are the example codes, which based on the instructions from [Usage](https://github.com/StardustDL/modulight#usage) and [Use Razor Component Modules](https://github.com/StardustDL/modulight#use-razor-component-modules). See [demo](./demo/HostBase/Client) for details.

**WebAssembly**

```cs
// in Program.cs

public static async Task Main(string[] args) 
{ 
    var builder = WebAssemblyHostBuilder.CreateDefault(args); 
    builder.RootComponents.Add<App>("app");

    builder.Services.AddModules(builder => 
    { 
        builder.UseRazorComponentClientModules().AddMarkdownModule(); 
    }); 

    builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) }); 

    // Attention: RunAsyncWithModules
    await builder.Build().RunAsyncWithModules(); 
} 
```

**Razor Pages**

```cs
// in App.razor

<Modulight.Modules.Client.RazorComponents.UI.ResourceDeclare />

// in Startup: void ConfigureServices(ISeviceCollection services)

using StardustDL.RazorComponents.Markdown;

services.AddModules(builder => {
    builder.UseRazorComponentClientModules().AddMarkdownModule();
});

// Generic hosting. (provided by package Modulight.Modules.Hosting, need to add this package)
// in Program: Task Main(string[] args)

using Microsoft.Extensions.Hosting;

await CreateHostBuilder(args).Build().RunAsyncWithModules();
```

### Using

```razor
<StardustDL.RazorComponents.Markdown.MarkdownRenderer
    Value="@MarkdownText"
    Class="your class"
    Style="your styles"
    RenderInterval="@TimeSpan.FromSeconds(10)"/>
```

Parameters:

- `Value` Raw Markdown (`String`)
- `Class` class attribute
- `Style` style attribute
- `RenderInterval` Delay rendering interval (`TimeSpan`), default `null` for no delay.
- `EnableCodeHighlighting` Highlighing code blocks, default `true`.
- `EnableDiagrams` Rendering diagrams, default `true`.
- `EnableMathematics` Rendering LaTex lines, default `true`.
- `EnableHtmlSanitizing` Sanitizing the final HTML to prevent XSS, default `true`.

## Preview

Here are some screenshots from the demo project.

### Header

![](docs/images/demo1.png)

### Code with highlighting

![](docs/images/demo2.png)

### Extensions

![](docs/images/demo3.png)

### Mathematics

![](docs/images/demo4.png)

### Diagram

![](docs/images/demo5.png)

## Dependencies

- [Markdig](https://github.com/lunet-io/markdig)
- [HtmlSanitizer](https://github.com/mganss/HtmlSanitizer)
- [Katex](https://github.com/KaTeX/KaTeX)
- [Mermaid.js](https://github.com/mermaid-js/mermaid)
- [PrismJS](https://github.com/PrismJS/prism)

## License

Apache-2.0

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

## Usage

Add the newest package on NuGet.

Visit https://www.nuget.org/packages/StardustDL.RazorComponents.Markdown for all versions.

```sh
dotnet add package StardustDL.RazorComponents.Markdown
```

### Install

This project is built on [Modulight](https://github.com/StardustDL/modulight).

Here are the example codes, which based on the instructions from [Usage](https://github.com/StardustDL/modulight#usage) and [Use Razor Component Modules](https://github.com/StardustDL/modulight#use-razor-component-modules). See [demo](./demo/HostBase/Client) for details.

**WebAssembly**

```cs
// in App.razor

<Modulight.Modules.Client.RazorComponents.UI.ResourceDeclare />

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

### Use the component

```razor
<StardustDL.RazorComponents.Markdown.MarkdownRenderer Value="@MarkdownText" Class="your class" Style="your styles" RenderInterval="@TimeSpan.FromSeconds(10)"/>
```

- `Value` Raw Markdown (`String`)
- `Class` class attribute
- `Style` style attribute
- `RenderInterval` Delay rendering interval (`TimeSpan`), default `null` for no delay.

## Configuration

Use `IMarkdownComponentService` to configure.

> Attention: The configuration will be changed in next version.

```csharp
Service.EnableCodeHighlight = true;
Service.EnableDiagrams = true;
Service.EnableMathematics = true;
```

If you want to customize Markdown's parser pipeline, you can inherit inherit `MarkdownComponentService` and override the method `GetPipeline()`.

If you want to customize the all things, you can inherit inherit `MarkdownComponentService` and override the method `RenderHTML(string)`.

For custom `IMarkdownComponentService`, use the codes below to inject services.

```cs
// before AddModules
builder.Services.AddSingleton<IMarkdownComponentService, MarkdownComponentService>();
```

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
- [Katex](https://github.com/KaTeX/KaTeX)
- [Mermaid.js](https://github.com/mermaid-js/mermaid)
- [PrismJS](https://github.com/PrismJS/prism)

## License

Apache-2.0

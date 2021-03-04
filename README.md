# RazorComponents.Markdown

![CI](https://github.com/StardustDL/RazorComponents.Markdown/workflows/CI/badge.svg) ![CD](https://github.com/StardustDL/RazorComponents.Markdown/workflows/CD/badge.svg) ![License](https://img.shields.io/github/license/StardustDL/RazorComponents.Markdown.svg) [![downloads](https://img.shields.io/nuget/dt/StardustDL.RazorComponents.Markdown)](https://www.nuget.org/packages/StardustDL.RazorComponents.Markdown/)

Razor component for Markdown rendering.

Online demo:

- [GitHub Pages](https://acblog.github.io/posts/article)
- [Gitee Pages](https://acblog.gitee.io/posts/article)

## Features

Most features are based on Markdig.

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

## Usage

Add the newest package on NuGet.

Visit https://www.nuget.org/packages/StardustDL.RazorComponents.Markdown for all versions.

```sh
dotnet add package StardustDL.RazorComponents.Markdown
```

> For latest build, use the following source.
> https://sparkshine.pkgs.visualstudio.com/StardustDL/_packaging/feed/nuget/v3/index.json

### Module Install

This project is built on [Modulight](https://github.com/StardustDL/modulight).

You can it by following the instructions from [Usage](https://github.com/StardustDL/modulight#usage) and [Use Razor Component Modules](https://github.com/StardustDL/modulight#use-razor-component-modules)

```cs
builder.AddMarkdownModule();
```

### Original Install

> If you don't want to use the module, and want to control all resources manually, then use this.

1. Add static assets to `index.html`.

```html
<link rel="stylesheet" type="text/css" href="_content/StardustDL.RazorComponents.Markdown/prismjs/themes/prism.css">
<link rel="stylesheet" type="text/css" href="_content/StardustDL.RazorComponents.Markdown/katex/katex.min.css">
<link rel="stylesheet" type="text/css" href="_content/StardustDL.RazorComponents.Markdown/css/markdown.css">

<script src="_content/StardustDL.RazorComponents.Markdown/component-min.js" type="text/javascript"></script>
<script src="_content/StardustDL.RazorComponents.Markdown/mermaid/mermaid.min.js" type="text/javascript"></script>
<script src="_content/StardustDL.RazorComponents.Markdown/prismjs/components/prism-core.min.js"></script>
<script src="_content/StardustDL.RazorComponents.Markdown/prismjs/plugins/autoloader/prism-autoloader.min.js"></script>
```

2. Add services.

```csharp
using StardustDL.RazorComponents.Markdown;

builder.Services.AddMarkdownComponent();
```

### Use the component

```razor
<StardustDL.RazorComponents.Markdown.MarkdownRenderer Value="@MarkdownText" Class="your class" Style="your styles"/>
```

## Configuration

Use `IMarkdownComponentService` to configure.

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

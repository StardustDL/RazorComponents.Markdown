# RazorComponents.Markdown

![CI](https://github.com/StardustDL/RazorComponents.Markdown/workflows/CI/badge.svg) ![CD](https://github.com/StardustDL/RazorComponents.Markdown/workflows/CD/badge.svg) ![License](https://img.shields.io/github/license/StardustDL/RazorComponents.Markdown.svg)

Razor component for Markdown rendering.

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
- Pipe tables
- Task lists
- Diagrams
- Auto links
- Smarty pants
- Emoji
- Code highlight

## Usage

1. Add the newest package on NuGet.

See https://www.nuget.org/packages/StardustDL.RazorComponents.Markdown for all versions.

```sh
dotnet add package StardustDL.RazorComponents.Markdown --version <version>
```

2. Add static assets to `index.html`.

```html
<link rel="stylesheet" type="text/css" href="_content/StardustDL.RazorComponents.Markdown/highlight.js/github.css">
<link rel="stylesheet" type="text/css" href="_content/StardustDL.RazorComponents.Markdown/katex/katex.min.css">

<script src="_content/StardustDL.RazorComponents.Markdown/component-min.js" type="text/javascript"></script>
<script src="_content/StardustDL.RazorComponents.Markdown/mermaid/mermaid.min.js" type="text/javascript"></script>
```

3. Use the component in Razor components.

```razor
<StardustDL.RazorComponents.Markdown.MarkdownRenderer Value="@MarkdownText" />
```

## Dependencies

- Markdig
- Katex
- Mermaid.js
- Highlight.js

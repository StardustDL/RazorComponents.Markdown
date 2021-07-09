using Markdig.Extensions.MediaLinks;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace StardustDL.RazorComponents.Markdown.Extensions
{
    public class BilibiliMediaLinkHost : IHostProvider
    {
        static string? MediaLink(Uri uri)
        {
            string path = uri.AbsolutePath;
            var items = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
            if (items.Length >= 2 && items[0] == "video")
            {
                return $"//player.bilibili.com/player.html?bvid={items[1]}";
            }
            else
            {
                return null;
            }
        }

        static IHostProvider Inner { get; } = HostProviderBuilder.Create(
                "www.bilibili.com", MediaLink, iframeClass: "bilibili");

        public bool TryHandle(Uri mediaUri, bool isSchemaRelative, [NotNullWhen(true)] out string? iframeUrl) => Inner.TryHandle(mediaUri, isSchemaRelative, out iframeUrl);

        public string? Class => Inner.Class;

        public bool AllowFullScreen => Inner.AllowFullScreen;
    }
}

using Markdig;
using Markdig.Extensions.MediaLinks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StardustDL.RazorComponents.Markdown
{
    static class CustomPipeline
    {
        private static string[] SplitQuery(Uri uri)
        {
            var query = uri.Query.Substring(uri.Query.IndexOf('?') + 1);
            return query.Split("&", StringSplitOptions.RemoveEmptyEntries);
        }

        static string MediaLinkBilibili(Uri uri)
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

        static string MediaLinkNeteaseMusic(Uri uri)
        {
            try
            {
                string url = uri.ToString();
                url = url.Substring(uri.Scheme.Length + 3); // ://
                string pre = "music.163.com/#/";
                if (url.StartsWith(pre))
                {
                    var items = url.Substring(pre.Length).Split('?');
                    var id = items[1].Split("&", StringSplitOptions.RemoveEmptyEntries).First(p => p.StartsWith("id="))?.Substring(3);
                    int type = 0;
                    if (items[0] == "song")
                        type = 2;
                    else if (items[0] == "playlist")
                        type = 0;
                    else if (items[0] == "album")
                        type = 1;
                    return $"//music.163.com/outchain/player?type={type}&id={id}&auto=0";
                }
            }
            catch { }
            return null;
        }

        public static MarkdownPipeline Build()
        {
            MediaOptions mediaOptions = new MediaOptions();
            mediaOptions.Hosts.Add(HostProviderBuilder.Create(
                "www.bilibili.com", MediaLinkBilibili, iframeClass: "bilibili"));
            mediaOptions.Hosts.Add(HostProviderBuilder.Create(
                "music.163.com", MediaLinkNeteaseMusic, iframeClass: "neteasemusic"));

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
                .UseMathematics()
                .UseMediaLinks(mediaOptions)
                .UsePipeTables()
                .UseListExtras()
                .UseTaskLists()
                .UseDiagrams()
                .UseAutoLinks()
                .UseSmartyPants()
                .UseEmojiAndSmiley()
                // .UseBootstrap()
                .UseGenericAttributes(); // Must be last as it is one parser that is modifying other parsers
            return builder.Build();
        }
    }
}

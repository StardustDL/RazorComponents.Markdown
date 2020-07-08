using Markdig.Extensions.MediaLinks;
using System;
using System.Linq;

namespace StardustDL.RazorComponents.Markdown.Extensions
{
    public class NeteaseMusicMediaLinkHost : IHostProvider
    {
        static string MediaLink(Uri uri)
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

        static IHostProvider Inner { get; } = HostProviderBuilder.Create(
                "music.163.com", MediaLink, iframeClass: "neteasemusic");

        public bool TryHandle(Uri mediaUri, bool isSchemaRelative, out string iframeUrl) => Inner.TryHandle(mediaUri, isSchemaRelative, out iframeUrl);

        public string Class => Inner.Class;

        public bool AllowFullScreen => Inner.AllowFullScreen;
    }
}

using System;
using CookComputing.XmlRpc;
using WordPressSharp.Models;

namespace WordPressSharp
{
    public class WordPressClient : IDisposable
    {
        protected WordPressSiteConfig WordPressSiteConfig { get; set; }

        public IWordPressService WordPressService { get; internal set; }

        public WordPressClient(WordPressSiteConfig siteConfig)
        {
            WordPressSiteConfig = siteConfig;

            WordPressService = (IWordPressService) XmlRpcProxyGen.Create(typeof (IWordPressService));
            WordPressService.Url = WordPressSiteConfig.FullUrl;
        }

        public Post GetPost(int postId)
        {
            return WordPressService.GetPost(WordPressSiteConfig, postId);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using CookComputing.XmlRpc;
using WordPressSharp.Models;

namespace WordPressSharp
{
    public class WordPressClient : IDisposable
    {
        protected WordPressSiteConfig WordPressSiteConfig { get; set; }

        /// <summary>
        /// The interface extension for the CookComputing.XmlRpc proxy
        /// </summary>
        public IWordPressService WordPressService { get; internal set; }

        /// <summary>
        /// Initialize a new instance of the WordPress Client class
        /// </summary>
        /// <param name="siteConfig">WordPress Site Config</param>
        public WordPressClient(WordPressSiteConfig siteConfig)
        {
            WordPressSiteConfig = siteConfig;

            WordPressService = (IWordPressService) XmlRpcProxyGen.Create(typeof (IWordPressService));
            WordPressService.Url = WordPressSiteConfig.FullUrl;
        }

        /// <summary>
        /// Gets a WordPress post by post_id
        /// </summary>
        /// <param name="postId">The Post Id</param>
        /// <returns>Post</returns>
        public Post GetPost(int postId)
        {
            return WordPressService.GetPost(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username, WordPressSiteConfig.Password, postId);
        }

        /// <summary>
        /// Gets a list of posts
        /// </summary>
        /// <param name="postFilter">A Post Filter</param>
        /// <returns></returns>
        public Post[] GetPosts(PostFilter postFilter)
        {
            return WordPressService.GetPosts(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                WordPressSiteConfig.Password, postFilter);
        }

        /// <summary>
        /// Creates a new entry in WordPress determined by Post.PostType to be a "Post", "Page", or custom post type
        /// </summary>
        /// <param name="post">The post to create</param>
        /// <returns></returns>
        public string NewPost(Post post)
        {
            return WordPressService.NewPost(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username, WordPressSiteConfig.Password, post);
        }

        public void Dispose()
        {
            WordPressService = null;
        }
    }
}

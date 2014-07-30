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
        /// <param name="filter">A Post Filter</param>
        /// <returns>Post[]</returns>
        public Post[] GetPosts(PostFilter filter)
        {
            return WordPressService.GetPosts(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                WordPressSiteConfig.Password, filter);
        }

        /// <summary>
        /// Gets a media item by attachment id
        /// </summary>
        /// <param name="attachmentId">Attachment Id</param>
        /// <returns>Media Item</returns>
        public MediaItem GetMediaItem(int attachmentId)
        {
            return WordPressService.GetMediaItem(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                WordPressSiteConfig.Password, attachmentId);
        }

        /// <summary>
        /// Gets a media library by Media Filter
        /// </summary>
        /// <param name="filter">Media Filter</param>
        /// <returns>Media Item Array</returns>
        public MediaItem[] GetMediaItems(MediaFilter filter)
        {
            return WordPressService.GetMediaLibrary(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                WordPressSiteConfig.Password, filter);
        }

        /// <summary>
        /// Gets a taxonomy by taxonomy name and term id
        /// </summary>
        /// <param name="taxonomy">Taxonomy</param>
        /// <param name="termId">Term Id</param>
        /// <returns>Taxonomy</returns>
        public Taxonomy GetTaxonomy(string taxonomy, int termId)
        {
            return WordPressService.GetTaxonomy(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                WordPressSiteConfig.Password, taxonomy, termId);
        }

        /// <summary>
        ///  Gets an array of taxonomies by taxonomy name and Term Filter
        /// </summary>
        /// <param name="taxonomy">Taxonomy</param>
        /// <param name="filter">Term Filter</param>
        /// <returns>Taxonomy Array</returns>
        public Taxonomy[] GetTaxonomies(string taxonomy, TermFilter filter)
        {
            return WordPressService.GetTaxonomies(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                WordPressSiteConfig.Password, taxonomy, filter);
        }

        public Term GetTerm(string taxonomy, int termId)
        {
            return WordPressService.GetTerm(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                WordPressSiteConfig.Password, taxonomy, termId);
        }

        public Term[] GetTerms(string taxonomy, TermFilter filter)
        {
            return WordPressService.GetTerms(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                WordPressSiteConfig.Password, taxonomy, filter);
        }

        public User GetUser(int userId)
        {
            return WordPressService.GetUser(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                WordPressSiteConfig.Password, userId);
        }

        public User[] GetUsers(UserFilter filter)
        {
            return WordPressService.GetUsers(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                WordPressSiteConfig.Password, filter);
        }

        public Comment GetComment(int commentId)
        {
            return WordPressService.GetComment(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                WordPressSiteConfig.Password, commentId);
        }

        public Comment[] GetComments(CommentFilter filter)
        {
            return WordPressService.GetComments(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                WordPressSiteConfig.Password, filter);
        }

        public PostCommentCount GetCommentCount(int postId)
        {
            return WordPressService.GetCommentCount(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                WordPressSiteConfig.Password, postId);
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

        public string NewTerm(Term term)
        {
            return WordPressService.NewTerm(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                WordPressSiteConfig.Password, term);
        }

        public bool DeleteTerm(int termId, string taxonomy)
        {
            return WordPressService.DeleteTerm(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                WordPressSiteConfig.Password, taxonomy, termId);
        }
        
        public void Dispose()
        {
            WordPressService = null;
        }
    }
}

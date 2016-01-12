using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
		/// Initializes a new instance of the <see cref="WordPressClient"/> class. It will use the default configuration based on app settings.
		/// </summary>
		public WordPressClient()
			: this(WordPressSiteConfig.Default)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="WordPressClient" /> class.
		/// </summary>
		/// <param name="siteConfig">The site configuration.</param>
        public WordPressClient(WordPressSiteConfig siteConfig)
        {
            WordPressSiteConfig = siteConfig;

            WordPressService = (IWordPressService)XmlRpcProxyGen.Create(typeof(IWordPressService));
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
        /// Upload a file
        /// </summary>
        /// <param name="upload">Upload data</param>
        /// <returns></returns>
        public UploadResult UploadFile(Data upload)
        {
            return WordPressService.UploadFile(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username, WordPressSiteConfig.Password, upload);
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
        public User GetProfile()
        {
            return WordPressService.GetProfile(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                WordPressSiteConfig.Password);
        }

        public Category[] GetCategories()
        {
            return WordPressService.GetAllCategories(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                WordPressSiteConfig.Password);
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
		/// Creates a new comment.
		/// </summary>
		/// <param name="comment">The comment.</param>
		/// <returns>The id of the newly created comment.</returns>
		public int NewComment(Comment comment)
		{
			var comment_put = new Comment_Put();
			CopyPropertyValues(comment, comment_put);

			return WordPressService.NewComment(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username, WordPressSiteConfig.Password, Convert.ToInt32(comment.PostId), comment_put);
		}


        /// <summary>
        /// Creates a new entry in WordPress determined by Post.PostType to be a "Post", "Page", or custom post type
        /// </summary>
        /// <param name="post">The post to create</param>
        /// <returns></returns>
        public string NewPost(Post post)    
        {
            var post_put = new Post_Put();
            CopyPropertyValues(post, post_put);

            var terms = new XmlRpcStruct();

            if (post.Terms != null)
            {
                var termTaxes = post.Terms.GroupBy(t => t.Taxonomy);
                foreach (var grp in termTaxes)
                {
                    var termIds = grp.Select(g => g.Id).ToArray();
                    terms.Add(grp.Key, termIds);
                }

                post_put.Terms = terms;
            }
            if (post_put.PostType == "post" && String.IsNullOrEmpty(post_put.CommentStatus))
			{
				post_put.CommentStatus = "open";
			}

            return WordPressService.NewPost(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username, WordPressSiteConfig.Password, post_put);
        }


        public bool EditPost(Post post)
        {
            var post_put = new Post_Put();
            CopyPropertyValues(post, post_put);

            var terms = new XmlRpcStruct();
            var termTaxes = post.Terms.GroupBy(t => t.Taxonomy);
            foreach (var grp in termTaxes)
            {
                var termIds = grp.Select(g => g.Id).ToArray();
                terms.Add(grp.Key, termIds);
            }

            
            post_put.Terms = terms;


            return WordPressService.EditPost(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username, WordPressSiteConfig.Password, int.Parse(post_put.Id), post_put);
        }

        public bool DeletePost(int postId)
        {
            return WordPressService.DeletePost(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                WordPressSiteConfig.Password, postId);
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


        Dictionary<string, Option_Get> ConvertOptionReturnValue(XmlRpcStruct options)
        {
            var result = new Dictionary<string, Option_Get>();

            foreach (DictionaryEntry option in options)
            {
                XmlRpcStruct optionStruct = (XmlRpcStruct)option.Value;

                var optionItem = new Option_Get();
                optionItem.Description = (string)optionStruct["desc"];

                var xmlRpcValue = optionStruct["value"];
                if (xmlRpcValue is string)
                {
                    optionItem.Value = (string)xmlRpcValue;
                }
                else
                {
                    optionItem.ValueObject = xmlRpcValue;
                }

                optionItem.ReadOnly = (bool)optionStruct["readonly"];

                result[(string)option.Key] = optionItem;
            }

            return result;
        }

        public Dictionary<string,Option_Get> GetOptions(IEnumerable<string> names)
        {
            XmlRpcStruct options;
            if (names == null)
            {
                options = WordPressService.GetAllOptions(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                    WordPressSiteConfig.Password);
            }
            else
            {
                options = WordPressService.GetOptions(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                    WordPressSiteConfig.Password, names.ToArray());
            }

            return ConvertOptionReturnValue(options);
        }

        public Dictionary<string, Option_Get> SetOptions(IEnumerable<Option> options)
        {
            XmlRpcStruct xmlRpcOption= new XmlRpcStruct();

            foreach (var option in options)
            {
                xmlRpcOption.Add( option.Name, option.Value );
            }

            var retOptions= WordPressService.SetOptios(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                WordPressSiteConfig.Password, xmlRpcOption);

            return ConvertOptionReturnValue(retOptions);
        }


        public void Dispose()
        {
            WordPressService = null;
        }

        public static void CopyPropertyValues(object source, object destination)
        {
            var destProperties = destination.GetType().GetProperties();

            foreach (var sourceProperty in source.GetType().GetProperties())
            {
                foreach (var destProperty in destProperties)
                {
                    if (destProperty.Name == sourceProperty.Name &&
                destProperty.PropertyType.IsAssignableFrom(sourceProperty.PropertyType))
                    {
                        destProperty.SetValue(destination, sourceProperty.GetValue(
                            source, new object[] { }), new object[] { });

                        break;
                    }
                }
            }
        }
    }
}

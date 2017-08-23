using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        /// Asynchronously gets a WordPress post by post_id
        /// </summary>
        /// <param name="postId">The Post Id</param>
        /// <returns>Post</returns>
        public async Task<Post> GetPostAsync(int postId)
        {
            return await Task.Factory.FromAsync
            (
                WordPressService.BeginGetPost(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username, WordPressSiteConfig.Password, postId),
                WordPressService.EndGetPost
            );
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
        /// Asynchronously gets a list of posts
        /// </summary>
        /// <param name="filter">A Post Filter</param>
        /// <returns>Post[]</returns>
        public async Task<Post[]> GetPostsAsync(PostFilter filter)
        {
            return await Task.Factory.FromAsync
            (
                WordPressService.BeginGetPosts(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                WordPressSiteConfig.Password, filter),
                WordPressService.EndGetPosts
            );
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
        /// Asynchronously gets a media item by attachment id
        /// </summary>
        /// <param name="attachmentId">Attachment Id</param>
        /// <returns>Media Item</returns>
        public async Task<MediaItem> GetMediaItemAsync(int attachmentId)
        {
            return await Task.Factory.FromAsync
            (
                WordPressService.BeginGetMediaItem(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username, WordPressSiteConfig.Password, attachmentId),
                WordPressService.EndGetMediaItem
            );
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
        /// Asynchronously upload a file
        /// </summary>
        /// <param name="upload">Upload data</param>
        /// <returns></returns>
        public async Task<UploadResult> UploadFileAsync(Data upload)
        {
            return await Task.Factory.FromAsync
            (
                WordPressService.BeginUploadFile(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username, WordPressSiteConfig.Password, upload),
                WordPressService.EndUploadFile
            );
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
        /// Asynchronously gets a media library by Media Filter
        /// </summary>
        /// <param name="filter">Media Filter</param>
        /// <returns>Media Item Array</returns>
        public async Task<MediaItem[]> GetMediaItemsAsync(MediaFilter filter)
        {
            return await Task.Factory.FromAsync
            (
                WordPressService.BeginGetMediaLibrary(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                WordPressSiteConfig.Password, filter),
                WordPressService.EndGetMediaLibrary
            );
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
        /// Asynchronously gets a taxonomy by taxonomy name and term id
        /// </summary>
        /// <param name="taxonomy">Taxonomy</param>
        /// <param name="termId">Term Id</param>
        /// <returns>Taxonomy</returns>
        public async Task<Taxonomy> GetTaxonomyAsync(string taxonomy, int termId)
        {
            return await Task.Factory.FromAsync
            (
                WordPressService.BeginGetTaxonomy(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                WordPressSiteConfig.Password, taxonomy, termId),
                WordPressService.EndGetTaxonomy
            );
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

        /// <summary>
        ///  Asynchronously gets an array of taxonomies by taxonomy name and Term Filter
        /// </summary>
        /// <param name="taxonomy">Taxonomy</param>
        /// <param name="filter">Term Filter</param>
        /// <returns>Taxonomy Array</returns>
        public async Task<Taxonomy[]> GetTaxonomiesAsync(string taxonomy, TermFilter filter)
        {
            return await Task.Factory.FromAsync
            (
                WordPressService.BeginGetTaxonomies(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                WordPressSiteConfig.Password, taxonomy, filter),
                WordPressService.EndGetTaxonomies
            );
        }

        public Term GetTerm(string taxonomy, int termId)
        {
            return WordPressService.GetTerm(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                WordPressSiteConfig.Password, taxonomy, termId);
        }

        public async Task<Term> GetTermAsync(string taxonomy, int termId)
        {
            return await Task.Factory.FromAsync
            (
                WordPressService.BeginGetTerm(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                WordPressSiteConfig.Password, taxonomy, termId),
                WordPressService.EndGetTerm
            );
        }

        public Term[] GetTerms(string taxonomy, TermFilter filter)
        {
            return WordPressService.GetTerms(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                WordPressSiteConfig.Password, taxonomy, filter);
        }

        public async Task<Term[]> GetTermsAsync(string taxonomy, TermFilter filter)
        {
            return await Task.Factory.FromAsync
            (
                WordPressService.BeginGetTerms(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                WordPressSiteConfig.Password, taxonomy, filter),
                WordPressService.EndGetTerms
            );
        }

        public User GetUser(int userId)
        {
            return WordPressService.GetUser(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                WordPressSiteConfig.Password, userId);
        }

        public async Task<User> GetUserAsync(int userId)
        {
            return await Task.Factory.FromAsync
            (
                WordPressService.BeginGetUser(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                WordPressSiteConfig.Password, userId),
                WordPressService.EndGetUser
            );
        }

        public User[] GetUsers(UserFilter filter)
        {
            return WordPressService.GetUsers(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                WordPressSiteConfig.Password, filter);
        }
        public async Task<User[]> GetUsersAsync(UserFilter filter)
        {
            return await Task.Factory.FromAsync
            (
                WordPressService.BeginGetUsers(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                WordPressSiteConfig.Password, filter),
                WordPressService.EndGetUsers
            );
        }
        public User GetProfile()
        {
            return WordPressService.GetProfile(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                WordPressSiteConfig.Password);
        }

        public async Task<User> GetProfileAsync()
        {
            return await Task.Factory.FromAsync
            (
                WordPressService.BeginGetProfile(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                WordPressSiteConfig.Password),
                WordPressService.EndGetProfile
            );
        }

        public Comment GetComment(int commentId)
        {
            return WordPressService.GetComment(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                WordPressSiteConfig.Password, commentId);
        }

        public async Task<Comment> GetCommentAsync(int commentId)
        {
            return await Task.Factory.FromAsync
            (
                WordPressService.BeginGetComment(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                WordPressSiteConfig.Password, commentId),
                WordPressService.EndGetComment
            );
        }

        public Comment[] GetComments(CommentFilter filter)
        {
            return WordPressService.GetComments(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                WordPressSiteConfig.Password, filter);
        }

        public async Task<Comment[]> GetCommentsAsync(CommentFilter filter)
        {
            return await Task.Factory.FromAsync
            (
                WordPressService.BeginGetComments(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                WordPressSiteConfig.Password, filter),
                WordPressService.EndGetComments
            );
        }

        public PostCommentCount GetCommentCount(int postId)
        {
            return WordPressService.GetCommentCount(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                WordPressSiteConfig.Password, postId);
        }

        public async Task<PostCommentCount> GetCommentCountAsync(int postId)
        {
            return await Task.Factory.FromAsync
            (
                WordPressService.BeginGetCommentCount(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                WordPressSiteConfig.Password, postId),
                WordPressService.EndGetCommentCount
            );
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
        /// Asynchronously creates a new comment.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <returns>The id of the newly created comment.</returns>
        public async Task<int> NewCommentAsync(Comment comment)
        {
            var comment_put = new Comment_Put();
            CopyPropertyValues(comment, comment_put);

            return await Task.Factory.FromAsync
            (
                WordPressService.BeginNewComment(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username, WordPressSiteConfig.Password, Convert.ToInt32(comment.PostId), comment_put),
                WordPressService.EndNewComment
            );
        }


        /// <summary>
        /// Creates a new entry in WordPress determined by Post.PostType to be a "Post", "Page", or custom post type
        /// </summary>
        /// <param name="post">The post to create</param>
        /// <returns></returns>
        public string NewPost(Post post)    
        {
            var post_put = NewPostPut(post);

            return WordPressService.NewPost(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username, WordPressSiteConfig.Password, post_put);
        }

        /// <summary>
        /// Asynchronously creates a new entry in WordPress determined by Post.PostType to be a "Post", "Page", or custom post type
        /// </summary>
        /// <param name="post">The post to create</param>
        /// <returns></returns>
        public async Task<string> NewPostAsync(Post post)
        {
            var post_put = NewPostPut(post);

            return await Task.Factory.FromAsync
            (
                WordPressService.BeginNewPost(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username, WordPressSiteConfig.Password, post_put),
                WordPressService.EndNewPost
            );
        }

        private Post_Put NewPostPut(Post post) {
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

            return post_put;
        }


        public bool EditPost(Post post)
        {
            var post_put = EditPostPut(post);

            return WordPressService.EditPost(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username, WordPressSiteConfig.Password, int.Parse(post_put.Id), post_put);
        }

        public async Task<bool> EditPostAsync(Post post)
        {
            var post_put = EditPostPut(post);

            return await Task.Factory.FromAsync
            (
                WordPressService.BeginEditPost(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username, WordPressSiteConfig.Password, int.Parse(post_put.Id), post_put),
                WordPressService.EndEditPost
            );
        }

        private Post_Put EditPostPut(Post post)
        {
            var post_put = new Post_Put();
            CopyPropertyValues(post, post_put);

            if (post.Terms != null)
            {
                var terms = new XmlRpcStruct();
                var termTaxes = post.Terms.GroupBy(t => t.Taxonomy);
                foreach (var grp in termTaxes)
                {
                    var termIds = grp.Select(g => g.Id).ToArray();
                    terms.Add(grp.Key, termIds);
                }


                post_put.Terms = terms;
            }

            return post_put;
        }

        public bool DeletePost(int postId)
        {
            return WordPressService.DeletePost(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                WordPressSiteConfig.Password, postId);
        }

        public async Task<bool> DeletePostAsync(int postId)
        {
            return await Task.Factory.FromAsync
            (
                WordPressService.BeginDeletePost(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                WordPressSiteConfig.Password, postId),
                WordPressService.EndDeletePost
            );
        }

        public string NewTerm(Term term)
        {
            return WordPressService.NewTerm(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                WordPressSiteConfig.Password, term);
        }

        public async Task<string> NewTermAsync(Term term)
        {
            return await Task.Factory.FromAsync
            (
                WordPressService.BeginNewTerm(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                WordPressSiteConfig.Password, term),
                WordPressService.EndNewTerm
            );
        }

        public bool DeleteTerm(int termId, string taxonomy)
        {
            return WordPressService.DeleteTerm(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                WordPressSiteConfig.Password, taxonomy, termId);
        }

        public async Task<bool> DeleteTermAsync(int termId, string taxonomy)
        {
            return await Task.Factory.FromAsync
            (
                WordPressService.BeginDeleteTerm(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                WordPressSiteConfig.Password, taxonomy, termId),
                WordPressService.EndDeleteTerm
            );
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

        public async Task<Dictionary<string, Option_Get>> GetOptionsAsync(IEnumerable<string> names)
        {
            XmlRpcStruct options;
            if (names == null)
            {
                options = await Task.Factory.FromAsync
                (
                    WordPressService.BeginGetAllOptions(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                    WordPressSiteConfig.Password),
                    WordPressService.EndGetAllOptions
                );
            }
            else
            {
                options = await Task.Factory.FromAsync
                (
                    WordPressService.BeginGetOptions(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                    WordPressSiteConfig.Password, names.ToArray()),
                    WordPressService.EndGetOptions
                );
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

        public async Task<Dictionary<string, Option_Get>> SetOptionsAsync(IEnumerable<Option> options)
        {
            XmlRpcStruct xmlRpcOption = new XmlRpcStruct();

            foreach (var option in options)
            {
                xmlRpcOption.Add(option.Name, option.Value);
            }

            var retOptions = await Task.Factory.FromAsync
            (
                WordPressService.BeginSetOptios(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                WordPressSiteConfig.Password, xmlRpcOption),
                WordPressService.EndSetOptios
            );

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

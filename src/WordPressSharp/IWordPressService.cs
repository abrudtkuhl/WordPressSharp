using System;
using CookComputing.XmlRpc;
using WordPressSharp.Models;

namespace WordPressSharp
{
    public interface IWordPressService : IXmlRpcProxy
    {
        // GET
        [XmlRpcMethod("wp.getPost")]
        Post GetPost(int blog_id, string username, string password, int post_id);

        [XmlRpcBegin("wp.getPost")]
        IAsyncResult BeginGetPost(int blog_id, string username, string password, int post_id);

        [XmlRpcEnd("wp.getPost")]
        Post EndGetPost(IAsyncResult iasr);

        [XmlRpcMethod("wp.getPosts")]
        Post[] GetPosts(int blog_id, string username, string password, PostFilter postFilter);

        [XmlRpcBegin("wp.getPosts")]
        IAsyncResult BeginGetPosts(int blog_id, string username, string password, PostFilter postFilter);

        [XmlRpcEnd("wp.getPosts")]
        Post[] EndGetPosts(IAsyncResult iasr);

        [XmlRpcMethod("wp.getMediaItem")]
        MediaItem GetMediaItem(int blog_id, string username, string password, int attachment_id);

        [XmlRpcBegin("wp.getMediaItem")]
        IAsyncResult BeginGetMediaItem(int blog_id, string username, string password, int attachment_id);
        
        [XmlRpcEnd("wp.getMediaItem")]
        MediaItem EndGetMediaItem(IAsyncResult iasr);

        [XmlRpcMethod("wp.getMediaLibrary")]
        MediaItem[] GetMediaLibrary(int blog_id, string username, string password, MediaFilter filter);

        [XmlRpcBegin("wp.getMediaLibrary")]
        IAsyncResult BeginGetMediaLibrary(int blog_id, string username, string password, MediaFilter filter);

        [XmlRpcEnd("wp.getMediaLibrary")]
        MediaItem[] EndGetMediaLibrary(IAsyncResult iasr);

        [XmlRpcMethod("wp.uploadFile")]
        UploadResult UploadFile(int blog_id, string username, string password, Data upload);

        [XmlRpcBegin("wp.uploadFile")]
        IAsyncResult BeginUploadFile(int blog_id, string username, string password, Data upload);

        [XmlRpcEnd("wp.uploadFile")]
        UploadResult EndUploadFile(IAsyncResult iasr);

        [XmlRpcMethod("wp.getTaxonomy")]
        Taxonomy GetTaxonomy(int blog_id, string username, string password, string taxonomy, int term_id);

        [XmlRpcBegin("wp.getTaxonomy")]
        IAsyncResult BeginGetTaxonomy(int blog_id, string username, string password, string taxonomy, int term_id);

        [XmlRpcEnd("wp.getTaxonomy")]
        Taxonomy EndGetTaxonomy(IAsyncResult iasr);

        [XmlRpcMethod("wp.getTaxonomies")]
        Taxonomy[] GetTaxonomies(int blog_id, string username, string password, string taxonomy, TermFilter filter);

        [XmlRpcBegin("wp.getTaxonomies")]
        IAsyncResult BeginGetTaxonomies(int blog_id, string username, string password, string taxonomy, TermFilter filter);

        [XmlRpcEnd("wp.getTaxonomies")]
        Taxonomy[] EndGetTaxonomies(IAsyncResult iasr);

        [XmlRpcMethod("wp.getTerm")]
        Term GetTerm(int blog_id, string username, string password, string taxonomy, int term_id);

        [XmlRpcBegin("wp.getTerm")]
        IAsyncResult BeginGetTerm(int blog_id, string username, string password, string taxonomy, int term_id);

        [XmlRpcEnd("wp.getTerm")]
        Term EndGetTerm(IAsyncResult iasr);

        [XmlRpcMethod("wp.getTerms")]
        Term[] GetTerms(int blog_id, string username, string password, string taxonomy, TermFilter filter);

        [XmlRpcBegin("wp.getTerms")]
        IAsyncResult BeginGetTerms(int blog_id, string username, string password, string taxonomy, TermFilter filter);

        [XmlRpcEnd("wp.getTerms")]
        Term[] EndGetTerms(IAsyncResult iasr);

        [XmlRpcMethod("wp.getUser")]
        User GetUser(int blog_id, string username, string password, int user_id);

        [XmlRpcBegin("wp.getUser")]
        IAsyncResult BeginGetUser(int blog_id, string username, string password, int user_id);

        [XmlRpcEnd("wp.getUser")]
        User EndGetUser(IAsyncResult iasr);

        [XmlRpcMethod("wp.getUsers")]
        User[] GetUsers(int blog_id, string username, string password, UserFilter filter);

        [XmlRpcBegin("wp.getUsers")]
        IAsyncResult BeginGetUsers(int blog_id, string username, string password, UserFilter filter);

        [XmlRpcEnd("wp.getUsers")]
        User[] EndGetUsers(IAsyncResult iasr);

        [XmlRpcMethod("wp.getProfile")]
        User GetProfile(int blog_id, string username, string password);

        [XmlRpcBegin("wp.getProfile")]
        IAsyncResult BeginGetProfile(int blog_id, string username, string password);

        [XmlRpcEnd("wp.getProfile")]
        User EndGetProfile(IAsyncResult iasr);

        [XmlRpcMethod("wp.getComment")]
        Comment GetComment(int blog_id, string username, string password, int comment_id);

        [XmlRpcBegin("wp.getComment")]
        IAsyncResult BeginGetComment(int blog_id, string username, string password, int comment_id);

        [XmlRpcEnd("wp.getComment")]
        Comment EndGetComment(IAsyncResult iasr);

        [XmlRpcMethod("wp.getComments")]
        Comment[] GetComments(int blog_id, string username, string password, CommentFilter filter);

        [XmlRpcBegin("wp.getComments")]
        IAsyncResult BeginGetComments(int blog_id, string username, string password, CommentFilter filter);

        [XmlRpcEnd("wp.getComments")]
        Comment[] EndGetComments(IAsyncResult iasr);

        [XmlRpcMethod("wp.getCommentCount")]
        PostCommentCount GetCommentCount(int blog_id, string username, string password, int post_id);

        [XmlRpcBegin("wp.getCommentCount")]
        IAsyncResult BeginGetCommentCount(int blog_id, string username, string password, int post_id);

        [XmlRpcEnd("wp.getCommentCount")]
        PostCommentCount EndGetCommentCount(IAsyncResult iasr);

        [XmlRpcMethod("wp.getOptions")]
        XmlRpcStruct GetOptions(int blog_id, string username, string password, string[] options);

        [XmlRpcBegin("wp.getOptions")]
        IAsyncResult BeginGetOptions(int blog_id, string username, string password, string[] options);

        [XmlRpcEnd("wp.getOptions")]
        XmlRpcStruct EndGetOptions(IAsyncResult iasr);

        [XmlRpcMethod("wp.getOptions")]
        XmlRpcStruct GetAllOptions(int blog_id, string username, string password);
        
        [XmlRpcBegin("wp.getOptions")]
        IAsyncResult BeginGetAllOptions(int blog_id, string username, string password);

        [XmlRpcEnd("wp.getOptions")]
        XmlRpcStruct EndGetAllOptions(IAsyncResult iasr);
        
        // PUT
        [XmlRpcMethod("wp.newPost")]
        string NewPost(int blog_id, string username, string password, Post_Put post);

        [XmlRpcBegin("wp.newPost")]
        IAsyncResult BeginNewPost(int blog_id, string username, string password, Post_Put post);

        [XmlRpcEnd("wp.newPost")]
        string EndNewPost(IAsyncResult iasr);

        [XmlRpcMethod("wp.editPost")]
        bool EditPost(int blog_id, string username, string password, int post_id, Post_Put post);

        [XmlRpcBegin("wp.editPost")]
        IAsyncResult BeginEditPost(int blog_id, string username, string password, int post_id, Post_Put post);

        [XmlRpcEnd("wp.editPost")]
        bool EndEditPost(IAsyncResult iasr);

        [XmlRpcMethod("wp.newTerm")]
        string NewTerm(int blog_id, string username, string password, Term term);

        [XmlRpcBegin("wp.newTerm")]
        IAsyncResult BeginNewTerm(int blog_id, string username, string password, Term term);

        [XmlRpcEnd("wp.newTerm")]
        string EndNewTerm(IAsyncResult iasr);

        [XmlRpcMethod("wp.setOptions")]
        XmlRpcStruct SetOptios(int blog_id, string username, string password, XmlRpcStruct options);

        [XmlRpcBegin("wp.setOptions")]
        IAsyncResult BeginSetOptios(int blog_id, string username, string password, XmlRpcStruct options);

        [XmlRpcEnd("wp.setOptions")]
        XmlRpcStruct EndSetOptios(IAsyncResult iasr);

        // DELETE
        [XmlRpcMethod("wp.deleteTerm")]
        bool DeleteTerm(int blog_id, string username, string password, string taxonomy, int term_id);

        [XmlRpcBegin("wp.deleteTerm")]
        IAsyncResult BeginDeleteTerm(int blog_id, string username, string password, string taxonomy, int term_id);

        [XmlRpcEnd("wp.deleteTerm")]
        bool EndDeleteTerm(IAsyncResult iasr);

        [XmlRpcMethod("wp.deletePost")]
        bool DeletePost(int blog_id, string username, string password, int post_id);

        [XmlRpcBegin("wp.deletePost")]
        IAsyncResult BeginDeletePost(int blog_id, string username, string password, int post_id);

        [XmlRpcEnd("wp.deletePost")]
        bool EndDeletePost(IAsyncResult iasr);

		/// <summary>
		/// Creates a new comment.
		/// </summary>
		/// <param name="blog_id">The blog id.</param>
		/// <param name="username">The username.</param>
		/// <param name="password">The password.</param>
		/// <param name="post_id">The post id.</param>
		/// <param name="comment">The comment.</param>
		/// <returns>The id of the newly created comment.</returns>
		[XmlRpcMethod("wp.newComment")]
		int NewComment(int blog_id, string username, string password, int post_id, Comment_Put comment);

        [XmlRpcBegin("wp.newComment")]
        IAsyncResult BeginNewComment(int blog_id, string username, string password, int post_id, Comment_Put comment);

        [XmlRpcEnd("wp.newComment")]
        int EndNewComment(IAsyncResult iasr);
    }
}

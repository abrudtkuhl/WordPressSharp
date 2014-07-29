using CookComputing.XmlRpc;
using WordPressSharp.Models;

namespace WordPressSharp
{
    public interface IWordPressService : IXmlRpcProxy
    {
        // GET
        [XmlRpcMethod("wp.getPost")]
        Post GetPost(int blog_id, string username, string password, int post_id);

        [XmlRpcMethod("wp.getPosts")]
        Post[] GetPosts(int blog_id, string username, string passwrod, PostFilter postFilter);

        [XmlRpcMethod("wp.getMediaItem")]
        MediaItem GetMediaItem(int blog_id, string username, string password, int attachment_id);

        [XmlRpcMethod("wp.getMediaLibrary")]
        MediaItem[] GetMediaLibrary(int blog_id, string username, string password, MediaFilter filter);

        [XmlRpcMethod("wp.getTaxonomy")]
        Taxonomy GetTaxonomy(int blog_id, string username, string password, string taxonomy, int term_id);

        [XmlRpcMethod("wp.getTaxonomies")]
        Taxonomy[] GetTaxonomies(int blog_id, string username, string password, string taxonomy, TermFilter filter);

        // PUT
        [XmlRpcMethod("wp.newPost")]
        string NewPost(int blog_id, string username, string password, Post post);

        
    }
}

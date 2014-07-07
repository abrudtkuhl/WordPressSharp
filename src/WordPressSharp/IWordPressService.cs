using CookComputing.XmlRpc;
using WordPressSharp.Models;

namespace WordPressSharp
{
    public interface IWordPressService : IXmlRpcProxy
    {
        // POSTS
        [XmlRpcMethod("wp.getPost")]
        Post GetPost(int blog_id, string username, string password, int post_id);

        [XmlRpcMethod("wp.getPosts")]
        Post[] GetPosts(int blog_id, string username, string passwrod, PostFilter postFilter);

        [XmlRpcMethod("wp.newPost")]
        string NewPost(int blog_id, string username, string password, Post post);
    }
}

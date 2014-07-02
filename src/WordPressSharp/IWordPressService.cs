using CookComputing.XmlRpc;
using WordPressSharp.Models;

namespace WordPressSharp
{
    public interface IWordPressService : IXmlRpcProxy
    {
        [XmlRpcMethod("wp.getPost")]
        Post GetPost(WordPressSiteConfig siteConfig, int postId);

        [XmlRpcMethod("wp.newPost")]
        Post NewPost(WordPressSiteConfig siteConfig, Post post);
    }
}

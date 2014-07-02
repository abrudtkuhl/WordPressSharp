using CookComputing.XmlRpc;
using WordPressSharp.Models;

namespace WordPressSharp
{
    public interface IWordPressService : IXmlRpcProxy
    {
        [XmlRpcMethod("wp.getPost")]
        Post GetPost(WordPressSiteCredentials wordpressSite, string postId);
    }
}

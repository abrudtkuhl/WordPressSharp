using System;
using CookComputing.XmlRpc;
using WordPressSharp.Models;

namespace WordPressSharp
{
    public interface IWordPressService : IXmlRpcProxy
    {
        [XmlRpcMethod("wp.getPost")]
        Post GetPost(int blog_id, string username, string password, int post_id);

        [XmlRpcMethod("wp.newPost")]
        int NewPost(int blog_id, string username, string password, string post_type, string post_title, string post_content, string post_status = "publish");
    }
}

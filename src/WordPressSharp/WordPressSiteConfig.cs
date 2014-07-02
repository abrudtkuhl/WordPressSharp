using System.ComponentModel;
using CookComputing.XmlRpc;

namespace WordPressSharp
{
    public class WordPressSiteConfig
    {
        [XmlRpcMember("blog_id")]
        [DefaultValue(1)]
        public int BlogId { get; set; }

        [XmlRpcMember("username")]
        public string Username { get; set; }

        [XmlRpcMember("password")]
        public string Password { get; set; }

        public string BaseUrl { get; set; }
        public string FullUrl { get { return string.Concat(BaseUrl, BaseUrl.EndsWith("/") ? "xmlrpc.php" : "/xmlrpc.php"); } }
    }
}

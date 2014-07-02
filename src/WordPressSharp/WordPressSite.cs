using CookComputing.XmlRpc;

namespace WordPressSharp
{
    public class WordPressSite
    {
        [XmlRpcMember("blog_id")]
        public string BlogId { get; set; }

        [XmlRpcMember("username")]
        public string Username { get; set; }

        [XmlRpcMember("password")]
        public string Password { get; set; }

        [XmlRpcMember("post_id")]
        public string PostId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookComputing.XmlRpc;

namespace WordPressSharp.Models
{
    public class Category
    {
        [XmlRpcMember("categoryId")]
        public string Id { get; set; }

        [XmlRpcMember("parentId")]
        public string ParentId { get; set; }

        [XmlRpcMember("categoryName")]
        public string CategoryName { get; set; }

        [XmlRpcMember("categoryDescription")]
        public string CategoryDescription { get; set; }

        [XmlRpcMember("description")]
        public string Description { get; set; }

        [XmlRpcMember("htmlUrl")]
        public string HtmlUrl { get; set; }

        [XmlRpcMember("rssUrl")]
        public string RssUrl { get; set; }
    }
}

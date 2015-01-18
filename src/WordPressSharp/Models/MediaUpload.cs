using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookComputing.XmlRpc;

namespace WordPressSharp.Models
{
    public class UploadResult
    {

        public string id { get; set; }        
        [XmlRpcMember("file")]
        public string file { get; set; }
        [XmlRpcMember("url")]
        public string url { get; set; }
        [XmlRpcMember("type")]
        public string type { get; set; }
    }

    public class Data {
        [XmlRpcMember("name")]
        public string Name { get; set; }
        [XmlRpcMember("type")]
        public string Type { get; set; }
        /// <summary>
        /// Pass an array of bytes IE File.ReadAllBytes(filepath)
        /// </summary>
        [XmlRpcMember("bits")]       
        public byte[] Bits { get; set; }
        [XmlRpcMember("overwrite")]
        public bool Overwrite { get; set; }
        [XmlRpcMember("post_id")]
        public int post_id { get; set; }
    }

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class MediaUpload
    {
        public Data data { get; set; }
    }
}

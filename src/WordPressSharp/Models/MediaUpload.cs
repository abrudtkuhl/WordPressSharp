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
		[XmlRpcMember("id")]
		public string Id { get; set; }

		[XmlRpcMember("file")]
		public string File { get; set; }

		[XmlRpcMember("url")]
		public string Url { get; set; }

		[XmlRpcMember("type")]
		public string Type { get; set; }

		#region obsoletes

		[Obsolete("Please use Id")]
		public string id { get { return Id; } set { Id = value; } }

		[Obsolete("Please use File")]
		public string file { get { return File; } set { File = value; } }

		[Obsolete("Please use Url")]
		public string url { get { return Url; } set { Url = value; } }

		[Obsolete("Please use Type")]
		public string type { get { return Type; } set { Type = value; } }

		#endregion
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

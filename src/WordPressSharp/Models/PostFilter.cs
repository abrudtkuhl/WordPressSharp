using CookComputing.XmlRpc;

namespace WordPressSharp.Models
{
	/// <summary>
	/// 
	/// </summary>
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class PostFilter
    {
		/// <summary>
		/// Gets or sets the type of the post. A constant from <see cref="WordPressSharp.Constants.PostType"/>.
		/// </summary>
		/// <value>
		/// The type of the post.
		/// </value>
        [XmlRpcMember("post_type")]
        public string PostType { get; set; }

		/// <summary>
		/// Gets or sets the post status. A constant from <see cref="WordPressSharp.Constants.PostStatus"/>.
		/// </summary>
		/// <value>
		/// The post status.
		/// </value>
        [XmlRpcMember("post_status")]
        public string PostStatus { get; set; }

		/// <summary>
		/// Gets or sets the offset.
		/// </summary>
		/// <value>
		/// The offset.
		/// </value>
        [XmlRpcMember("offset")]
        public int Offset { get; set; }

		/// <summary>
		/// Gets or sets a value by which the posts will be ordered. A constant from <see cref="WordPressSharp.Constants.PostOrderBy"/>.
		/// </summary>
		/// <value>
		/// The value by which the posts will be ordered.
		/// </value>
        [XmlRpcMember("orderby")]
        public string OrderBy { get; set; }

		/// <summary>
		/// Gets or sets the order. A constant from <see cref="WordPressSharp.Constants.Order"/>.
		/// </summary>
		/// <value>
		/// The order.
		/// </value>
        [XmlRpcMember("order")]
        public string Order { get; set; }

		/// <summary>
		/// Gets or sets the number.
		/// </summary>
		/// <value>
		/// The number.
		/// </value>
        [XmlRpcMember("number")]
        public int Number { get; set; }
    }
}

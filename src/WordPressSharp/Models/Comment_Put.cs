using CookComputing.XmlRpc;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPressSharp.Models
{	
	/// <summary>
	/// The comment model that is used to create new comments.
	/// </summary>
	[DebuggerDisplay("{GetType().Name,nq}: Author={Author}, Content={Content}")]
    [XmlRpcMissingMapping(MappingAction.Ignore)]
	public class Comment_Put
	{
		/// <summary>
		/// Gets or sets the comment parent.
		/// </summary>
		/// <value>
		/// The comment parent.
		/// </value>
		[XmlRpcMember("comment_parent")]
		public int CommentParent { get; set; }

		/// <summary>
		/// Gets or sets the content.
		/// </summary>
		/// <value>
		/// The content.
		/// </value>
		[XmlRpcMember("content")]
		public string Content { get; set; }

		/// <summary>
		/// Gets or sets the author.
		/// </summary>
		/// <value>
		/// The author.
		/// </value>
		[XmlRpcMember("author")]
		public string Author { get; set; }

		/// <summary>
		/// Gets or sets the author URL.
		/// </summary>
		/// <value>
		/// The author URL.
		/// </value>
		[XmlRpcMember("author_url")]
		public string AuthorUrl { get; set; }

		/// <summary>
		/// Gets or sets the author email.
		/// </summary>
		/// <value>
		/// The author email.
		/// </value>
		[XmlRpcMember("author_email")]
		public string AuthorEmail { get; set; }
	}
}

using CookComputing.XmlRpc;
using System;
using System.IO;
using System.Net;

namespace WordPressSharp.Models
{
	[XmlRpcMissingMapping(MappingAction.Ignore)]
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

	/// <summary>
	/// Data structure that is used for uploading. Data.CreateFromFilePath or Data.CreateFromUrl can be used to create a structure. 
	/// </summary>
	public class Data
	{
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		[XmlRpcMember("name")]
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the MIME type.
		/// </summary>
		/// <value>
		/// The type.
		/// </value>
		[XmlRpcMember("type")]
		public string Type { get; set; }

		/// <summary>
		/// The bits representing the upload. Pass an array of bytes IE File.ReadAllBytes(filepath)
		/// </summary>
		[XmlRpcMember("bits")]
		public byte[] Bits { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this to overwrite a media item with the same name.
		/// </summary>
		/// <value>
		///   <c>true</c> if the media item should be overwritten; otherwise, <c>false</c>.
		/// </value>
		[XmlRpcMember("overwrite")]
		public bool Overwrite { get; set; }

		/// <summary>
		/// Creates a data structure from the file path.
		/// </summary>
		/// <param name="path">The path.</param>
		/// <param name="mimeType">Type of the MIME.</param>
		/// <returns>
		/// The data structure.
		/// </returns>
		/// <exception cref="System.ArgumentException">Path is a required parameter.</exception>
		public static Data CreateFromFilePath(string path, string mimeType)
		{
			if (path == null)
			{
				throw new ArgumentException("Path is a required parameter.", "path");
			}

			Data data = new Data
			{
				Type = mimeType,
				Name = Path.GetFileName(path),
				Bits = File.ReadAllBytes(path)
			};

			return data;
		}

		/// <summary>
		/// Creates the data structure from the URL.
		/// </summary>
		/// <param name="url">The URL.</param>
		/// <param name="mimeType">Type of the MIME. If <c>null</c> the ContentType header of the url will be used.</param>
		/// <returns>
		/// The data structure.
		/// </returns>
		/// <exception cref="System.ArgumentException">Url is a required parameter.</exception>
		public static Data CreateFromUrl(string url, string mimeType = null)
		{
			if (url == null)
			{
				throw new ArgumentException("Url is a required parameter.", "url");
			}

			var bytes = new byte[0];

			using (WebClient wc = new WebClient())
			{
				Data data = new Data();
				data.Bits = wc.DownloadData(url);
				data.Name = Path.GetFileName(url);

				if (mimeType != null)
				{
					data.Type = mimeType;
				}
				else
				{
					data.Type = wc.ResponseHeaders["content-type"];
				}

				return data;
			}
		}

		#region obsoletes

		[Obsolete("Not used anymore.")]
		public int post_id { get; set; }

		#endregion

	}

	[XmlRpcMissingMapping(MappingAction.Ignore)]
	public class MediaUpload
	{
		[XmlRpcMember("data")]
		public Data Data { get; set; }

		#region obsoletes

		[Obsolete("Please use Data.")]
		public Data data
		{
			get { return Data; }
			set { Data = value; }
		}

		#endregion
	}
}

using System.ComponentModel;
using CookComputing.XmlRpc;
using System;
using System.Configuration;

namespace WordPressSharp
{
	/// <summary>
	/// Stores the configuration for the WordPressClient. Use Default to construct a configuration based on the following app settings: 
	/// WordPressUserName, WordPressPassword, WordPressBaseUrl and WordPressBlogId (optional).
	/// </summary>
	[XmlRpcMissingMapping(MappingAction.Ignore)]
	public class WordPressSiteConfig
	{
		/// <summary>
		/// Gets the default configuration. This configuration looks for the following app settings: 
		/// WordPressUserName, WordPressPassword, WordPressBaseUrl and WordPressBlogId (optional).
		/// </summary>
		/// <value>
		/// The default.
		/// </value>
		public static WordPressSiteConfig Default { get { return _defaultConfig.Value; } }

		[XmlRpcMember("blog_id")]
		public int BlogId { get; set; }

		[XmlRpcMember("username")]
		public string Username { get; set; }

		[XmlRpcMember("password")]
		public string Password { get; set; }

		public string BaseUrl { get; set; }

		public string FullUrl { get { return string.Concat(BaseUrl, BaseUrl.EndsWith("/") ? "xmlrpc.php" : "/xmlrpc.php"); } }

		#region Create default configuration from app settings (WordPressUsername, WordPressPassword, WordPressBaseUrl, WordPressBlogId

		/// <summary>
		/// Creates the default configuration.
		/// </summary>
		private static readonly Lazy<WordPressSiteConfig> _defaultConfig = new Lazy<WordPressSiteConfig>(() =>
		{
			var config = new WordPressSiteConfig
			{
				Username = ConfigurationManager.AppSettings["WordPressUsername"],
				Password = ConfigurationManager.AppSettings["WordPressPassword"],
				BaseUrl = ConfigurationManager.AppSettings["WordPressBaseUrl"]
			};

			int blogId = 0;
			if (Int32.TryParse(ConfigurationManager.AppSettings["WordPressBlogId"], out blogId))
			{
				config.BlogId = blogId;
			}

			if (String.IsNullOrEmpty(config.Username))
			{
				throw new ConfigurationException("Missing WordPressUsername. Please add it to your .config file.");
			}
			if (String.IsNullOrEmpty(config.Password))
			{
				throw new ConfigurationException("Missing WordPressPassword. Please add it to your .config file.");
			}
			if (String.IsNullOrEmpty(config.BaseUrl))
			{
				throw new ConfigurationException("Missing WordPressBaseUrl. Please add it to your .config file.");
			}

			return config;
		});

		#endregion
	}
}
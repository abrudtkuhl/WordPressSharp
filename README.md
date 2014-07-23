#WordPressSharp#
A C# client to interact with the WordPress XML-RPC API

#Examples#
**Create Post**  
    var post = new Post {
        PostType = "post",
        Title = "My Awesome Post",
        Content = "<p>This is the content</p>",
        PublishDateTime = DateTime.Now
    }
    using (var client = new WordPresClient(new WordPressSiteConfig {
        BaseUrl = "http://mywordpress.com",
        Username = "admin",
        Password = "password",
        BlogId = 1
    })) 
    {
        var id = Convert.ToInt32(client.NewPost(post));
    }


#Dependencies#
[XML-RPC.net](http://xml-rpc.net/)

#Resources#
[WordPress XML-RPC API](http://codex.wordpress.org/XML-RPC_WordPress_API)

#Notes#
Inspired by the [POSSIBLE.WordPress.XmlRpcClient](https://github.com/markeverard/POSSIBLE.WordPress.XmlRpcClient) by [markeverard](https://github.com/markeverard)

#WordPressSharp#
A C# client to interact with the WordPress XML-RPC API

#Install#
I'm working on a Nuget package once I'm done mapping all the WP XML-RPC endpoints.

In the meantime, you'll have to clone, build, and add the DLL the ole fashioned way

#Examples#
**Create Post**  

    var post = new Post {
        PostType = "post",
        Title = "My Awesome Post",
        Content = "<p>This is the content</p>",
        PublishDateTime = DateTime.Now
    };

    using (var client = new WordPressClient(new WordPressSiteConfig {
        BaseUrl = "http://mywordpress.com",
        Username = "admin",
        Password = "password",
        BlogId = 1
    })) 
    {
        var id = Convert.ToInt32(client.NewPost(post));
    }

##Create Post Tag##

    var config = new WordPressSiteConfig { ... }

    using (var client = new WordPressClient(config))
    {
        var termId = client.NewTerm(new Term
        {
            Name = "term test",
            Description = "term description",
            Slug = "term_test",
            Taxonomy = "post_tag"
        });
    }

#Dependencies#
[XML-RPC.net](http://xml-rpc.net/)

#Resources#
[WordPress XML-RPC API](http://codex.wordpress.org/XML-RPC_WordPress_API)

#Notes#
Inspired by the [POSSIBLE.WordPress.XmlRpcClient](https://github.com/markeverard/POSSIBLE.WordPress.XmlRpcClient) by [markeverard](https://github.com/markeverard)

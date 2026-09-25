# WordPressSharp

WordPressSharp 2.x is an asynchronous .NET 10 client for the WordPress REST API. It supports typed methods for common WordPress core resources and generic requests for plugin and custom endpoints discovered from a site's REST API index.

> **Version 2 is a breaking change.** The old XML-RPC API (`WordPressClient`, `WordPressSiteConfig`, and `WordPressSharp.Models.Post`) was replaced by a REST API client. XML-RPC is no longer included.

## Requirements

- .NET 10
- A WordPress site with the REST API available
- For authenticated server-to-server access, a WordPress Application Password (WordPress 5.6+) and HTTPS

Install from NuGet after publishing:

```sh
dotnet add package WordPressSharp --version 2.0.0
```

## Create a client

```csharp
using WordPressSharp;

using var client = new WordPressClient(new WordPressClientOptions
{
    SiteUri = new Uri("https://example.com/"),
    Username = "api-user",
    ApplicationPassword = Environment.GetEnvironmentVariable("WORDPRESS_APP_PASSWORD")!
});

var api = await client.DiscoverAsync();
Console.WriteLine($"{api.Name}: {api.Namespaces?.Length ?? 0} namespaces");
```

Application Password credentials are sent using HTTP Basic authentication only to HTTPS URLs on the configured site's host and port. To use custom authentication, construct the client with an `HttpClient` configured with your own authentication handler:

```csharp
var httpClient = new HttpClient(myAuthenticationHandler);
var client = new WordPressClient(new WordPressClientOptions
{
    SiteUri = new Uri("https://example.com/")
}, httpClient);
```

When you inject `HttpClient`, its lifetime and timeout remain caller-managed; the client does not dispose it.

## Core endpoint examples

### List and create posts

```csharp
var posts = await client.GetPostsAsync(new WordPressListOptions
{
    Page = 1,
    PerPage = 20,
    Search = "launch",
    Status = "publish"
});

Console.WriteLine($"Page contains {posts.Items.Count} of {posts.TotalItems} posts");

var created = await client.CreatePostAsync(WordPressPayload.Create(new
{
    title = "Hello from WordPressSharp",
    content = "<p>Posted through the REST API.</p>",
    status = "draft",
    categories = new[] { 4 },
    featured_media = 27
}));
```

### Upload media

```csharp
await using var stream = File.OpenRead("image.jpg");
var media = await client.UploadMediaAsync("image.jpg", "image/jpeg", stream, title: "Site image");
```

### Use a custom or plugin route

```csharp
var routes = await client.GetRoutesAsync();
var customResult = await client.SendJsonAsync(
    HttpMethod.Get,
    "my-plugin/v1/items",
    query: new[] { new KeyValuePair<string, string?>("per_page", "10") });
```

Inspect a specific endpoint's accepted methods and schema:

```csharp
var schema = await client.GetEndpointSchemaAsync("my-plugin/v1/items");
```

Requests accept relative REST routes with or without a leading slash. Use `JsonElement` or your own DTO with `GetAsync<T>` when an endpoint has a custom response shape.

## Typed core operations

The client currently provides typed models and methods for:

- Posts and pages, create/update/delete, revisions, and autosaves
- Media, including binary upload
- Comments
- Users
- Categories and tags
- Post types, taxonomies, statuses, and settings
- Search, blocks, block types/rendering, themes, and plugins
- REST API discovery, route listing, endpoint schemas, and generic JSON requests

WordPress REST endpoints and permissions vary by installed WordPress version, user role, and plugins. Custom post types and taxonomies must be registered with REST support on the site. Use the REST index and `OPTIONS` schema response to determine what a particular site exposes.

All network methods are asynchronous and accept an optional `CancellationToken`. Collection methods return `WordPressPage<T>` with WordPress pagination headers when available. API errors throw `WordPressApiException`, including the HTTP status, WordPress error code, and optional error data.

## Build and test

```sh
dotnet test src/WordPressSharpTest/WordPressSharpTest.csproj
```

The test suite uses a fake HTTP handler and does not require a WordPress server or credentials.

## Publish to NuGet

Releases are published through GitHub Actions using NuGet Trusted Publishing (OIDC), without a long-lived NuGet API key. Configure a NuGet.org Trusted Publishing policy with:

- Repository owner: `abrudtkuhl`
- Repository: `WordPressSharp`
- Workflow file: `publish-nuget.yml`
- Environment: leave unset unless the workflow is updated to use a GitHub environment

Add a GitHub Actions repository variable named `NUGET_USER` containing your NuGet.org profile name (not your email address). Publishing happens when a GitHub release is published. To publish an existing release, run **Publish NuGet package** from the Actions tab and enter its release tag, such as `v2.0.0`.

## Security note

Create an Application Password for a dedicated WordPress user with only the capabilities it needs. Store it in a secret store or environment variable, not in source control. WordPress Application Passwords are intended for HTTPS connections.

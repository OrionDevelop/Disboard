Disboard.Mastodon
----

[![License](https://img.shields.io/github/license/mika-f/Disboard.svg?style=flat-square)](../../LICENSE)
[![Disboard.Mastodon](https://img.shields.io/nuget/v/Disboard.Mastodon.svg?style=flat-square)](https://nuget.org/packages/Disboard.Mastodon)


Mastodon API wrapper for .NET Standard 2.0.  
Based on Mastodon 2.7.x.


## Note

Disboard is based on [Mastodon's documentation](https://docs.joinmastodon.org/).  
If there is something that not mentioned in the document, Disboard does not support it.  

**This is a generic Mastodon API wrapper**, we do not implement features unique to the instance.  
For example, pixiv's instance "pawoo.net" implements unique features, we do not support one.


## Usage

Note: If some requests retuens 403, please check instance's configuration.


```csharp
var mastodon = new MastodonClient("mastodon.cloud");

// register app
var scopes = AccessScope.Read | AccessScope.Write | AccessScope.Follow;
await mastodon.Apps.RegisterAsync("Orion", Constants.RedirectUriForClient, scopes);

// auth
Process.Start(mastodon.Auth.AuthorizeUrl(Constants.RedirectUriForClient, scopes));

var code = Console.ReadLine();
await mastodon.Auth.AccessTokenAsync(Constants.RedirectUriForClient, code);

// send new status
await mastodon.Statuses.UpdateAsync("Hello, Mastodon!");

// get timeline using streaming api (needs System.Reactive)
var disposable = mastodon.Streaming.PublicAsObservable(false).Subscribe((w) => {
	w.Dump();
});

await Task.Delay(1000 * 60);
disposable.Dispose();
```


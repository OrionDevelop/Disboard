Disboard.GnuSocial
----

[![License](https://img.shields.io/github/license/mika-f/Disboard.svg?style=flat-square)](../../LICENSE)
[![Disboard.Mastodon](https://img.shields.io/nuget/v/Disboard.GnuSocial.svg?style=flat-square)](https://nuget.org/packages/Disboard.GnuSocial)


GnuSocial API wrapper for .NET Standard 2.0.  
Based on GnuSocial 1.2.x.


## Note

**This is a generic GnuSocial API wrapper**, we do not implement features unique to the instance.  


## Usage


```csharp
var gs = new GnuSocialClient("mastodon.cloud");

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


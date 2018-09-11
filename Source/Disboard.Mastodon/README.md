Disboard.Mastodon
----

[![License](https://img.shields.io/github/license/mika-f/Disboard.svg?style=flat-square)](../../LICENSE)
[![Disboard.Mastodon](https://img.shields.io/nuget/v/Disboard.Mastodon.svg?style=flat-square)](https://nuget.org/packages/Disboard.Mastodon)


Mastodon API wrapper for .NET Standard 2.0.  
Based on Mastodon 2.5.0.


## Note

[Mastodon's documentation](https://github.com/tootsuite/documentation) is not trustworthy.  
If you want to contribute to this library, you SHOULD read [Mastodon's source code implementation](https://github.com/tootsuite/mastodon).


## Usage

```csharp
var mastodon = new MastodonClient("mastodon.cloud");

// register app
var scopes = AccessScope.Read | AccessScope.Write | AccessScope.Follow;
await mastodon.Apps.RegisterAsync("Orion", Constants.RedirectUriForClient, scopes);

// auth
Process.Start(mastodon.Auth.AuthorizeUrl(Constants.RedirectUriForClient, scopes));

var code = Console.ReadLine();
await mastodon.Auth.AccessTokenAsync(Constants.RedirectUriForClient, code);
```

Note: If some requests retuens 403, please check instance's configuration.
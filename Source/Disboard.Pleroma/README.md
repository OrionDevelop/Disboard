Disboard.Pleroma
----

[![License](https://img.shields.io/github/license/mika-f/Disboard.svg?style=flat-square)](../../LICENSE)
[![Disboard.Pleroma](https://img.shields.io/nuget/v/Disboard.Pleroma.svg?style=flat-square)](https://nuget.org/packages/Disboard.Pleroma)


Pleroma API wrapper for .NET Standard 2.0.  


## Note

Pleroma API is compatible with Mastodon API, you can use this library as Disboard.Mastodon.  

**This is a generic Pleroma API wrapper**, we do not implement features unique to the instance.  


## Usage

Note: If some requests retuens 403, please check instance's configuration.


```csharp
var pleroma = new PleromaClient("pl.smuglo.li");

// register app
var scopes = AccessScope.Read | AccessScope.Write | AccessScope.Follow;
await pleroma.Apps.RegisterAsync("Orion", Constants.RedirectUriForClient, scopes);

// auth
Process.Start(pleroma.Auth.AuthorizeUrl(Constants.RedirectUriForClient, scopes));

var code = Console.ReadLine();
await pleroma.Auth.AccessTokenAsync(Constants.RedirectUriForClient, code);

// send new status
await pleroma.Statuses.UpdateAsync("Hello, Pleroma!");

// Pleroma only API
var emojis = await pleroma.Pleroma.EmojiAsync();

// Streaming API
var disposable = pleroma.Streaming.PublicAsObservable().Subscribe((w) => {
	w.Dump();
});

await Task.Delay(1000 * 60);
disposable.Dispose();
```


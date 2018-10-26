Disboard.Misskey
----

[![License](https://img.shields.io/github/license/mika-f/Disboard.svg?style=flat-square)](../../LICENSE)
[![Disboard.Misskey](https://img.shields.io/nuget/v/Disboard.Misskey.svg?style=flat-square)](https://nuget.org/packages/Disboard.Misskey)


Misskey API wrapper for .NET Standard 2.0.  
Based on Misskey 10.x.


## Note

[Misskey's documentation](https://misskey.xyz/docs/ja-JP/about) is not trustworthy.  
If you want to contribute to this library, you SHOULD read [Misskey's source code implementation](https://github.com/syuilo/misskey).

**This is a generic Misskey API wrapper**, we do not implement features unique to the instance.  

Some Misskey endpoints require privilege permission (`secure: true`).  
Disboard does not support these APIs.


## Usage

```csharp
var misskey = new MisskeyClient("misskey.xyz");

// register app
var permissions = new string[] {"account-read", "account-write", "note-write", "reaction-write", "following-write", "drive-read", "drive-write", "notification-write", "notification-read"};
await misskey.App.CreateAsync("Orion", "Orion is generic microblogging client", permissions, "https://static.mochizuki.moe/callback.html");

// auth
var session = await misskey.Auth.Session.Generate();
Process.Start(session.Url);

// Wait for user accepts client that access to your info
Console.ReadLine();
await misskey.Auth.Session.UserKeyAsync(session.Token);

// If you want to call REST API, please use method that has "Async()" suffix.
await misskey.I.VerifyAsync();

// Streaming API
var disposable = misskey.Streaming.LocalTimelineAsObservable().Subscrive(w => {
	w.Dump();
});

await Task.Delay(1000 * 60);
disposable.Dispose();
```


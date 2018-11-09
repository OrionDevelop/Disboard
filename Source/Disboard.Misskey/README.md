﻿Disboard.Misskey
----

[![License](https://img.shields.io/github/license/mika-f/Disboard.svg?style=flat-square)](../../LICENSE)
[![Disboard.Misskey](https://img.shields.io/nuget/v/Disboard.Misskey.svg?style=flat-square)](https://nuget.org/packages/Disboard.Misskey)


Misskey API wrapper for .NET Standard 2.0.  
Based on Misskey 10.28.x.


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
var permissions = new List<Permission> {
    Permission.AccountRead, Permission.AccountRead2, 
    Permission.AccountWrite, Permission.AccountWrite2,
    Permission.DriveRead, Permission.DriveWrite,
    Permission.FavoritesRead, Permission.FavoriteWrite,
    Permission.FollowingRead, Permission.FollowingWrite,
    Permission.MessagingRead, Permission.MessagingWrite,
    Permission.NoteWrite,
    Permission.NotificationWrite,
    Permission.ReactionWrite,
    Permission.VoteWrite,
};
// permission is "string[]", because Misskey's permission is very flexible and possibility that it will increase in the future.
await misskey.App.CreateAsync("Orion", "Orion is generic microblogging client", permissions.Select(w => w.ToStr()).ToArray(), "https://static.mochizuki.moe/callback.html");

// auth
var session = await misskey.Auth.Session.Generate();
Process.Start(session.Url);

// Wait for user accepts client that access to your info
Console.ReadLine();
await misskey.Auth.Session.UserKeyAsync(session.Token);

// If you want to call REST API, please use method that has "Async()" suffix.
await misskey.IAsync();

// Streaming API
await misskey.Streaming.ConnectAsync();

var disposable = misskey.Streaming.LocalTimelineAsObservable().Subscrive(w => {
    w.Dump();
});

await Task.Delay(1000 * 60);
disposable.Dispose();

// If you want to call REST API using WebSocket connection, please use method that has "WsAsync()" suffix.
await misskey.IWsAsync();

misskey.Streaming.Disconnect();
```


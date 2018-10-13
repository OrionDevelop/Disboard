Disboard.Misskey
----

[![License](https://img.shields.io/github/license/mika-f/Disboard.svg?style=flat-square)](../../LICENSE)
[![Disboard.Misskey](https://img.shields.io/nuget/v/Disboard.Misskey.svg?style=flat-square)](https://nuget.org/packages/Disboard.Misskey)


Misskey API wrapper for .NET Standard 2.0.  
Based on Misskey 8.x.


## Caution

**This is a generic Misskey API wrapper**, We do not implement features unique to the instance.  


## Usage

```csharp
var misskey = new MisskeyClient("misskey.xyz", "YOUR_CLIENT_SECRET");

// Authentication process
var session = await misskey.Auth.Session.Generate();
Process.Start(session.Url);

// Wait for user accepts client that access to your info
Console.ReadLine();

var tokens = await misskey.Auth.Session.UserKeyAsync(session.Token);
```


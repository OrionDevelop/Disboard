# Disboard.Misskey

Disboard.Misskey は、 Disboard の Misskey 拡張です。  
REST 形式 API と Streaming (WebSocket) 形式 API の両方をサポートしています。

なお、一部の特権権限な必要な API と、リバーシ (およびゲーム) の API には対応していません。


## REST 形式 API

Disboard では、 Streaming を除く全ての API に対して、 REST での呼び出しが可能です。  
REST 形式の API は、`~Async()` なメソッドで提供しており、認証情報さえあれば呼び出しが可能です。


## Streaming (WebSocket) 形式 API

Misskey では、 REST の他に、すでに接続している WebSocket にリクエストをのせて API の呼び出しが可能です。  
Disboard ではこの形式の API 呼び出しにも対応しています。

Streaming (WebSocket) 形式での呼び出しには、予め WebSocket コネクションを開いておく必要があります。

```csharp
await misskey.Streaming.ConnectAsync();
```

コネクションを開いたら、 `~WsAsync()` なメソッドを呼び出すことで、 WebSocket コネクションを使ってリクエストを行えます。  
ただし、全ての API がサポートされているわけではなく、一部対象外となっている API もあります。

WebSocket コネクションを閉じるには、 `Disconnect()` を呼び出します。

```csharp
misskey.Disconnect();
```

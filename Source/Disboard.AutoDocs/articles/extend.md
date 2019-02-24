# Disboard を拡張する

Disboard は、標準では本家の実装にのみ追従して更新しています。  
そのため、例えば Pawoo や friends.nico などで独自の拡張実装が行われているインスタンスでは、全ての API およびレスポンスをカバーできていません。

しかしながら、 Disboard では拡張されたインスタンスのことも考えられているため、簡単に対応できます。
例えば、 [OrionDevelop/Disboard](https://github.com/OrionDevelop/Disboard) で提供している `Disboard.Pleroma` は、 `Disboard.Mastodon` を拡張したものです。


## 対応していないレスポンスにアクセスする

Disboard はレスポンスをクラスで提供しているため、通常はデシリアライズされないプロパティはアクセス出来ません。  
しかしながら、 `Extends` プロパティ経由でアクセスすることで、デシリアライズされなかったプロパティにアクセスすることが出来ます。

```cs
// pawoo.net の `pixiv_card` にアクセスしたい場合
status.Extends["pixiv_card"].ToObject<PixivCard>();
```


## 対応していない API にアクセスする

Pleroma のように、 Mastodon 互換ではあるが、一部で互換がない、もしくは API が追加されている場合、ベースの実装を継承することで拡張できます。  
例えば、 Disboard.Pleroma の実装は下記のようになっています。

```cs
using System.Net.Http;

using Disboard.Mastodon;
using Disboard.Models;
using Disboard.Pleroma.Clients;

using PleromaApi = Disboard.Pleroma.Clients.PleromaClient;

namespace Disboard.Pleroma
{
    public class PleromaClient : MastodonClient
    {
        public PleromaApi Pleroma { get; }
        public new StreamingClient Streaming { get; }

        public PleromaClient(string domain, HttpClientHandler innerHandler = null) : this(new Credential {Domain = domain}, innerHandler) { }

        public PleromaClient(Credential credential, HttpClientHandler innerHandler = null) : base(credential, innerHandler)
        {
            Pleroma = new PleromaApi(this);
            Streaming = new StreamingClient(this);
        }
    }
}
```

もしくは、各クライアントインスタンスから直接コールすることも可能です。

```cs
mastodon.GetAsync("ENDPOINT", parameters);
```
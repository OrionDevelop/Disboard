# Disboard

Disboard は、 Fediverse (ActivityPub) に対応している Web アプリケーションのクライアント API ラッパーライブラリです。  
パッケージはサービス毎に分かれており、例えばあなたのアプリケーションで Mastodon をサポートしたい場合は、  `Disboard.Mastodon` パッケージをインストールすることで、
Mastodon の API が使えます。


## Getting Started

Disboard は簡単に使えます。  
ここでは、 Mastodon 対応を例にしていますが、[OrionDevelop/Disboard](https://github.com/OrionDevelop/Disboard) にてサポートされているサービスの場合、同様の操作で使用できます。


### Step. 1

NuGet 経由で、 Disboard、Disboard.Mastodon およびその依存ライブラリをインストールします。  
インストール方法については、[公式ドキュメント](https://docs.microsoft.com/ja-jp/nuget/quickstart/install-and-use-a-package-using-the-dotnet-cli) を参照してください。


### Step. 2

インストールを終えたら、下記の `using` ステートメントを、コードの上部に追加します。

```cs
using Disboard;
using Disboard.Mastodon;
```


### Step. 3

ドメイン名を引数として、 `MastodonClient` インスタンスを作成することで、 API をコールできます。
例えば、 mastodon.cloud の API を呼び出す場合は、

```cs
var mastodon = new MastodonClient("mastodon.cloud");
```

とします。

Disboard の提供する API は、各サービスの API のエンドポイントと同様の形です。  
例えば、 `/api/v1/statuses/update` を呼び出したい場合、 `mastodon.Statuses.UpdateAsync` を呼び出します。


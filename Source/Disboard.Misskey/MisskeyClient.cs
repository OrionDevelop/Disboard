namespace Disboard.Misskey
{
    public class MisskeyClient : AppClient
    {
        protected MisskeyClient(string baseUrl) : base(baseUrl, "2.0") { }
    }
}
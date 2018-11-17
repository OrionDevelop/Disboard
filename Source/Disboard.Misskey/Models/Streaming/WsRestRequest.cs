namespace Disboard.Misskey.Models.Streaming
{
    public class WsRestRequest : WsRequest
    {
        public WsRestRequest()
        {
            Type = "api";
        }
    }
}
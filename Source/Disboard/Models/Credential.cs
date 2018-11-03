namespace Disboard.Models
{
    public class Credential
    {
        /// <summary>
        ///     Instance domain (e.g. mastodon.cloud)
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        ///     Client ID for Consumer Key
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        ///     Client Secret or Consumer Secret
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        ///     Access Token
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        ///     Access Token Secret
        /// </summary>
        public string AccessTokenSecret { get; set; }

        /// <summary>
        ///     Refresh Token (OAuth 2.0 only)
        /// </summary>
        public string RefreshToken { get; set; }
    }
}
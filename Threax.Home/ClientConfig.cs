using HtmlRapier.TagHelpers;

namespace Threax.Home
{
    /// <summary>
    /// Client side configuration, copied onto pages returned to client, so don't include secrets.
    /// </summary>
    public class ClientConfig : ClientConfigBase
    {
        /// <summary>
        /// The url of the app's service, likely the same as the app itself.
        /// </summary>
        public string ServiceUrl { get; set; }

        /// <summary>
        /// The url of the user directory.
        /// </summary>
        public string UserDirectoryUrl { get; set; }
    }
}
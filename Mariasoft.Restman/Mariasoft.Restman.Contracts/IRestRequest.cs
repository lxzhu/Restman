using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;

namespace Mariasoft.Restman.Contracts
{
    public interface IRestRequest
    {
        string HttpClientName { get; }

        HttpMethod HttpMethod { get; }

        string UrlTemplate { get; }

        string RelativeUrl { get; }

        MethodInfo MethodInfo { get; }

        object[] ArgumentValues { get; }

        /// <summary>
        ///     
        /// </summary>
        object RequestBody { get; set; }
    }
}

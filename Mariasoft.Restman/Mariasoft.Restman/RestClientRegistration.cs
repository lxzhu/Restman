using Mariasoft.Restman.Contracts;

namespace Mariasoft.Restman
{
    public class RestClientRegistration
    {
        /// <summary>
        /// 
        /// </summary>
        public string HttpClientName { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public Func<IRequestFactory> GetRequestFactory { get; set; } = () => NoOp.RequestFactory;

        /// <summary>
        /// 
        /// </summary>
        public Func<IResponseFactory> GetResponseFactory { get; set; } = () => NoOp.ResponseFactory;
    }
}
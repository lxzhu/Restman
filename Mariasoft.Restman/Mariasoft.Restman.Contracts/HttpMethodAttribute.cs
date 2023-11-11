using System.Net.Http;

namespace Mariasoft.Restman.Contracts
{
    public class HttpMethodAttribute : HttpRouteAttribute
    {
        public HttpMethodAttribute(HttpMethod method, string template) : base(template)
        {
            Method = method;
        }
        public HttpMethod Method { get; private set; }
    }
}

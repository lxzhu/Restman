using System.Net.Http;

namespace Mariasoft.Restman.Contracts
{
    public class HttpGetAttribute : HttpMethodAttribute
    {
        public HttpGetAttribute(string template):base(HttpMethod.Get, template) { }
    }
}

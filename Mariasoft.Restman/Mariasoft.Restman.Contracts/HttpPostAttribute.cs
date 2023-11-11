using System.Net.Http;

namespace Mariasoft.Restman.Contracts
{
    public class HttpPostAttribute : HttpMethodAttribute
    {
        public HttpPostAttribute(string template) : base(HttpMethod.Post, template) { }
    }
}

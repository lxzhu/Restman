using Castle.DynamicProxy;
using Mariasoft.Restman.Contracts;
using System.Net.Http;

namespace Mariasoft.Restman
{
    public class RestClientFactory : IRestClientFactory
    {
        private readonly IHttpClientFactory _httpClientFactory;
        
        private readonly IEnumerable<RestClientRegistration> _registrations;

        public RestClientFactory(
            IHttpClientFactory httpClientFactory,            
            IEnumerable<RestClientRegistration> registrations)
        {
            _httpClientFactory = httpClientFactory;            
            _registrations = registrations;
        }

        public TRestClient CreateClient<TRestClient>(string httpClientName = "") where TRestClient:class
        {
            var registration = _registrations.FirstOrDefault(r => r.HttpClientName == httpClientName)!;
            var interceptor = new RestClientInterceptor(_httpClientFactory,  registration);
            var generator = new ProxyGenerator();
            return generator.CreateInterfaceProxyWithoutTarget<TRestClient>(interceptor);
        }
    }
}
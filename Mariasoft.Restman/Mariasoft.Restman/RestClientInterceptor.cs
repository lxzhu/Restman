using Castle.DynamicProxy;
using Mariasoft.Restman.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mariasoft.Restman
{
    public class RestClientInterceptor : IInterceptor
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly RestClientRegistration _registration;

        public RestClientInterceptor(IHttpClientFactory httpClientFactory, RestClientRegistration registration)
        {
            _httpClientFactory = httpClientFactory;
            _registration = registration;
        }

        public void Intercept(IInvocation invocation)
        {
            var responseType = GetResponseType(invocation.Method);
            var methodName = responseType == typeof(Void) ? nameof(ExecuteNoReturn) : nameof(Execute);
            var executeMethod = this.GetType().GetMethod(methodName)!;
            invocation.ReturnValue = executeMethod
                .MakeGenericMethod(responseType)
                .Invoke(this, new object[] { invocation });
        }

        private static Type GetResponseType(MethodInfo method)
        {
            static bool isTask(Type t) => t == typeof(Task);

            static bool isTaskT(Type t) => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Task<>);

            static Type getRealType(Type t) => t.GetGenericArguments()[0];

            string message = $"Return type must be Task or Task<TResponse>,but is {method.ReturnType.Name}";

            return isTaskT(method.ReturnType)
                ? getRealType(method.ReturnType)
                : isTask(method.ReturnType)
                    ? typeof(Void)
                    : throw new NotSupportedException(message);
        }

        private async Task<TResponse> Execute<TResponse>(IInvocation invocation)
        {
            var endpoint = GetRestRequest(invocation);
            var httpClient = _httpClientFactory.CreateClient(_registration.HttpClientName);
            var requestMessage = new HttpRequestMessage();
            var requestFactory = _registration.GetRequestFactory();
            await requestFactory.CreateRequest(endpoint, requestMessage);
            var responseMessage = await httpClient.SendAsync(requestMessage);
            var responseFactory = _registration.GetResponseFactory();
            return await responseFactory.CreateResponse<TResponse>(endpoint, responseMessage);
        }

        private async Task ExecuteNoReturn<TResponse>(IInvocation invocation)
        {
            await Execute<TResponse>(invocation);
        }

        private static RestRequest GetRestRequest(IInvocation invocation)
        {
            return null;
        }
    }
}

using Mariasoft.Restman.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mariasoft.Restman
{
    internal class NoOp
    {
        public static readonly IRequestFactory RequestFactory = new NoOpRequestFactory();
        public static readonly IResponseFactory ResponseFactory = new NoOpResponseFactory();



        internal class NoOpRequestFactory : IRequestFactory
        {
            public async Task CreateRequest(IRestRequest endpoint, HttpRequestMessage request)
            {
                await Task.CompletedTask;
            }
        }

        internal class NoOpResponseFactory : IResponseFactory
        {
            public async Task<TResponse> CreateResponse<TResponse>(IRestRequest endpoint, HttpResponseMessage response)
            {
                var result = default(TResponse) ?? Activator.CreateInstance(typeof(TResponse))!;
                return await Task.FromResult((TResponse)result);
            }

        }
    }
}

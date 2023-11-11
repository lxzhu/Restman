using Mariasoft.Restman.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mariasoft.Restman.Formats
{
    public class JsonRequestFactory : IRequestFactory
    {
        private readonly IJsonSerializer _serializer;

        public JsonRequestFactory(IJsonSerializer serializer) { _serializer = serializer; }

        public async Task CreateRequest(IRestRequest request, HttpRequestMessage message)
        {
            if (request.RequestBody != null)
            {
                var requestBodyJson = _serializer.SerializeObject(request.RequestBody);
                message.Content = new StringContent(requestBodyJson, Encoding.UTF8,ContentFormats.Json);
            }
            await Task.CompletedTask;
        }
    }
}

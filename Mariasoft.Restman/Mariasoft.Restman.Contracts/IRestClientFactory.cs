using System;

namespace Mariasoft.Restman.Contracts
{
    public interface IRestClientFactory
    {
        TRestClient CreateClient<TRestClient>(string httpClientName = "") where TRestClient : class;
    }
}

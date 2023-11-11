using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mariasoft.Restman.Contracts
{
    public interface IRequestFactory
    {
        Task CreateRequest(IRestRequest request, HttpRequestMessage message);
    }
}

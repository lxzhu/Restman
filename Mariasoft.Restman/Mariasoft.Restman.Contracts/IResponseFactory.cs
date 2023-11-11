using System.Net.Http;
using System.Threading.Tasks;

namespace Mariasoft.Restman.Contracts
{
    public interface IResponseFactory
    {
        Task<TResponse> CreateResponse<TResponse>(IRestRequest request, HttpResponseMessage message);
    }
}

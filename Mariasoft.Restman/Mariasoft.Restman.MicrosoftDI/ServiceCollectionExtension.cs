using Mariasoft.Restman.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Mariasoft.Restman.MicrosoftDI
{
    public static class ServiceCollectionExtension
    {
        public static RestmanBuilder AddRestman(this IServiceCollection services)
        {
            services.AddTransient<IRestClientFactory, RestClientFactory>();
            return new RestmanBuilder(services);
        }

        public static IServiceCollection RegisterRestClient<TRestClient, TRestRequestFactory, TRestResponseFactory>(this IServiceCollection services, string httpClientName="")
            where TRestClient:class
            where TRestRequestFactory : class,IRequestFactory
            where TRestResponseFactory : class,IResponseFactory
        {
            services.AddTransient<TRestRequestFactory>();
            services.AddTransient<TRestResponseFactory>();

            services.AddTransient(sp => new RestClientRegistration()
            {
                HttpClientName = httpClientName,
                GetRequestFactory = () => sp.GetRequiredService<TRestRequestFactory>(),
                GetResponseFactory = () => sp.GetRequiredService<TRestResponseFactory>(),
            });

            services.AddTransient<TRestClient>(sp =>
            {
                var factory=sp.GetRequiredService<IRestClientFactory>();
                return factory.CreateClient<TRestClient>(httpClientName);
            });
            return services;
        }
    }
}
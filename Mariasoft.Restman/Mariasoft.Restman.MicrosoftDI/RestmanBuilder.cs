using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mariasoft.Restman.MicrosoftDI
{
    public class RestmanBuilder
    {
        public IServiceCollection Services { get; private set; }
        public RestmanBuilder(IServiceCollection services)
        {
            Services = services;
        }
    }
}

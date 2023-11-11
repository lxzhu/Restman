using System;
using System.Collections.Generic;
using System.Text;

namespace Mariasoft.Restman.Contracts
{
    public class HttpRouteAttribute
    {
        public string Template { get; private set; }
        public HttpRouteAttribute(string template)
        {
            Template = template;
        }
    }
}

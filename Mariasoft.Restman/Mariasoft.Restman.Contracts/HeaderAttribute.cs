using System;
using System.Collections.Generic;
using System.Text;

namespace Mariasoft.Restman.Contracts
{

    public class HeaderAttribute:ParameterAttribute
    {
        public HeaderAttribute(string name=null) : base(ParameterIn.Header,name) { }
    }
}

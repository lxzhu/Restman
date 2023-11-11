using System;
using System.Collections.Generic;
using System.Text;

namespace Mariasoft.Restman.Contracts
{

    public class ContentFormatAttribute:Attribute
    {
        public ContentFormatAttribute(string format= ContentFormats.Json) { }

        public string Format { get; private set; }
    }
}

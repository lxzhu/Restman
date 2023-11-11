using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mariasoft.Restman
{
    public class UrlTemplate
    {
        public string Template { get;  set; }

        public UrlTemplate() : this(string.Empty) { }
        public UrlTemplate(string template) { }

        public string Evaluate(IEnumerable<KeyValuePair<string,object>> arguments)
        {
            return Template;
        }
    }
}

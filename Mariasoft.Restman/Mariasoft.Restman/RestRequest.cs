using Mariasoft.Restman.Contracts;
using System.Reflection;

namespace Mariasoft.Restman
{
    public class RestRequest : IRestRequest
    {
        public string HttpClientName { get; set; } = string.Empty;

        public HttpMethod HttpMethod { get; set; } = HttpMethod.Get;

        public string UrlTemplate { get; set; } = string.Empty;

        public string RelativeUrl
        {
            get => new UrlTemplate(this.UrlTemplate)
                .Evaluate(Arguments);
        }

        public IEnumerable<KeyValuePair<string, object?>> Arguments
        {
            get
            {
                var allParams = this.MethodInfo!.GetParameters();
                for (var index = 0;
                    index < allParams.Length;
                    index++)
                {
                    var name = GetParameterName(allParams[index]);
                    var value = this.ArgumentValues[index];
                    yield return new(name, value);
                }
            }
        }
        private static string GetParameterName(ParameterInfo parameterInfo)
        {
            return parameterInfo.Name!;
        }

        public MethodInfo? MethodInfo { get; set; }

        public object?[] ArgumentValues { get; set; }
            = new object?[] { };

        public object? RequestBody { get; set; }
    }


}

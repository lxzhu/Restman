namespace Mariasoft.Restman.Contracts
{
    public class QueryAttribute : ParameterAttribute
    {
        public QueryAttribute(string name = null) : base( ParameterIn.Query, name) { }
    }
}

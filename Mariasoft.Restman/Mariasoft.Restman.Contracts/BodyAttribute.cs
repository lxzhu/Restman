namespace Mariasoft.Restman.Contracts
{
    public class BodyAttribute : ParameterAttribute
    {
        public BodyAttribute(string name = null) : base(ParameterIn.Body, name) { }
    }
}

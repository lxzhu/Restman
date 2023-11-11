namespace Mariasoft.Restman.Contracts
{
    public class ParameterAttribute
    {
        public ParameterAttribute(ParameterIn @in, string name = null)
        {
            this.Name = name;
            In = @in;
        }

        public ParameterIn In { get; private set; }
        public string Name { get; private set; }
    }
}

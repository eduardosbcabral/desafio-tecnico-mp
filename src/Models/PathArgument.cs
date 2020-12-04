namespace DesafioTecnicoMP.Models
{
    public class PathArgument : ApplicationArgument<string>
    {
        public PathArgument(string value)
            : base("Path", "-p", value, true)
        {
            Validate();
        }

        public override string GetValue()
        {
            if (_value == null)
                return null;

            return _value.ToString();
        }

        public void Validate()
        {
            if (string.IsNullOrEmpty(GetValue()) && Required)
            {
                throw new ApplicationArgumentException($"The argument {Argument} ({Name}) is required.");
            }
        }
    }
}

namespace DesafioTecnicoMP.Models
{
    public class PathArgument : ApplicationArgument<string>
    {
        public PathArgument(string value)
            : base("Path", "-p", value, true)
        {
            Validate();
        }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Value) && Required)
            {
                throw new ApplicationArgumentException($"The argument {Argument} ({Name}) is required.");
            }
        }
    }
}

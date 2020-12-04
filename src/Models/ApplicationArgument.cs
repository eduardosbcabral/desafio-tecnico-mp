namespace DesafioTecnicoMP.Models
{
    public abstract class ApplicationArgument<T>
    {
        public string Name { get; private set; }
        public string Argument { get; private set; }
        public T Value { get; private set; }
        public bool Required { get; private set; }

        public ApplicationArgument(string name, string argument, T value, bool required)
        {
            Name = name;
            Argument = argument;
            Value = value;
            Required = required;
        }
    }
}

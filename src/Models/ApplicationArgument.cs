using DesafioTecnicoMP.Interfaces;

namespace DesafioTecnicoMP.Models
{
    public abstract class ApplicationArgument<T> : IApplicationArgument
    {
        public string Name { get; private set; }
        public string Argument { get; private set; }
        public bool Required { get; private set; }

        protected readonly object _value;

        public ApplicationArgument(string name, string argument, object value, bool required)
        {
            Name = name;
            Argument = argument;
            Required = required;

            _value = value;
        }

        public abstract T GetValue();

        object IApplicationArgument.GetValue()
        {
            return GetValue();
        }

        public abstract T GetRawValue();

        object IApplicationArgument.GetRawValue()
        {
            return GetRawValue();
        }
    }
}

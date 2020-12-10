using DesafioTecnicoMP.Exceptions;
using DesafioTecnicoMP.Services;

namespace DesafioTecnicoMP.Models
{
    public class BufferLengthArgument : ApplicationArgument<long>
    {
        public BufferLengthArgument(string value = null)
            : base("Buffer Length", 
                  ArgumentsConstants.BUFFER_LENGTH_ARGUMENT, 
                  ConvertArgValue(value) == 0 
                  ? 1L 
                  : ConvertArgValue(value), false)
        {
            Validate();
        }

        public override long GetValue()
        {
            return BytesService.ConvertMegabytesToBytes((long)_value);
        }

        public override long GetRawValue()
        {
            return (long)_value;
        }

        protected void Validate()
        {
            if (GetRawValue() <= 0)
            {
                throw new ApplicationArgumentException($"[ERROR] The argument {Argument} ({Name}) is invalid, should be higher than zero.");
            }
        }
    }
}

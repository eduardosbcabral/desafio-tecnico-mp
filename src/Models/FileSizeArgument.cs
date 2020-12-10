using DesafioTecnicoMP.Exceptions;
using DesafioTecnicoMP.Services;

namespace DesafioTecnicoMP.Models
{
    public class FileSizeArgument : ApplicationArgument<long>
    {
        public FileSizeArgument(string value = null)
            : base("File Size", 
                  ArgumentsConstants.FILE_SIZE_ARGUMENT, 
                  ConvertArgValue(value) == 0 
                  ? 100L 
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

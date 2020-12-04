namespace DesafioTecnicoMP.Models
{
    public class FileSizeArgument : ApplicationArgument<long>
    {
        public FileSizeArgument(long value = 104857600L)
            : base("File Size", "-f", value, false)
        {
            Validate();
        }

        public override long GetValue()
        {
            return BytesService.ConvertMegabytesToBytes((long)_value);
        }

        protected void Validate()
        {
            if (GetValue() <= 0)
            {
                throw new ApplicationArgumentException($"[ERROR] The argument {Argument} ({Name}) is invalid, should be higher than zero.");
            }
        }
    }
}

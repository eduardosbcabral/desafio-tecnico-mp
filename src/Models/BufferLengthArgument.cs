namespace DesafioTecnicoMP.Models
{
    public class BufferLengthArgument : ApplicationArgument<long>
    {
        public BufferLengthArgument(long value = 1L)
            : base("Buffer Length", "-b", value, false)
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

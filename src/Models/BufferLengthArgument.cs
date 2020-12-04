namespace DesafioTecnicoMP.Models
{
    public class BufferLengthArgument : ApplicationArgument<long>
    {
        public BufferLengthArgument(long value = 1048576L)
            : base("Buffer Length", "-b", value, false)
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

namespace DesafioTecnicoMP.Models
{
    public class BufferLengthArgument : ApplicationArgument<long>
    {
        public BufferLengthArgument(long value = 1048576L)
            : base("Buffer Length", "-b", value, false)
        {
            Validate();
        }

        protected void Validate()
        {
            if (Value <= 0)
            {
                throw new ApplicationArgumentException($"[ERROR] The argument {Argument} ({Name}) is invalid, should be higher than zero.");
            }
        }
    }
}

using System;

namespace DesafioTecnicoMP.Exceptions
{
    public class ApplicationArgumentException : Exception
    {
        public ApplicationArgumentException(string message)
            : base(message)
        {

        }
    }
}

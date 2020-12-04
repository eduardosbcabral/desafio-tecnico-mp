
using System;

namespace DesafioTecnicoMP
{
    public class ApplicationArgumentException : Exception
    {
        public ApplicationArgumentException(string message)
            : base(message)
        {

        }
    }
}

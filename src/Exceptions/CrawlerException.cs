using System;

namespace DesafioTecnicoMP.Exceptions
{
    public class CrawlerException : Exception
    {
        public CrawlerException(string message)
            : base(message)
        {
        }
    }
}

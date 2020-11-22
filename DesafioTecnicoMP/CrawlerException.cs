using System;

namespace DesafioTecnicoMP
{
    public class CrawlerException : Exception
    {
        public CrawlerException(string message)
            : base(message)
        {
        }
    }
}

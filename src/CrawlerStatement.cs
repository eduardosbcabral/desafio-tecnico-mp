using DesafioTecnicoMP.Exceptions;
using DesafioTecnicoMP.Interfaces;
using DesafioTecnicoMP.Services;
using System;

namespace DesafioTecnicoMP
{
    public class CrawlerStatement
    {
        private const string FIRST_CRAWLER_URL = @"https://lerolero.com/";
        private const string SECOND_CRAWLER_URL = @"https://mothereff.in/byte-counter#";

        private readonly ICrawlerService _crawlerService;

        public CrawlerStatement(ICrawlerService crawlerService)
        {
            _crawlerService = crawlerService;
        }

        public string GetSentence()
        {
            string sentence;

            try
            {
                Console.WriteLine("Starting first crawler...");
                sentence = _crawlerService
                    .GoToUrl(FIRST_CRAWLER_URL)
                    .GetTextContentFromElement(".sentence");
                Console.WriteLine("First crawler successfully completed...");
            }
            catch (CrawlerException ex)
            {
                Console.WriteLine("[ERROR] " + ex.Message);
                Console.ReadLine();
                throw ex;
            }

            return sentence;
        }

        public int GetBytesCount(string sentence)
        {
            int bytesCount;

            try
            {
                Console.WriteLine("Starting second crawler...");
                var bytesFromPage = _crawlerService
                    .GoToUrl(SECOND_CRAWLER_URL + sentence)
                    .GetTextContentFromElement("#bytes");

                bytesCount = int.Parse(bytesFromPage.Split(" ")[0]);
                Console.WriteLine("Second crawler successfully completed...");
            }
            catch (CrawlerException)
            {
                bytesCount = BytesService.CountFromString(sentence);
            }
            finally
            {
                _crawlerService.Quit();
            }

            return bytesCount;
        }
    }
}

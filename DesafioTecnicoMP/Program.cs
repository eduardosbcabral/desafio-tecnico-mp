using System;

namespace DesafioTecnicoMP
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = @"https://lerolero.com/";
            var url2 = @"https://mothereff.in/byte-counter#";

            CrawlerService crawler = new CrawlerService(url);

            var sentence = string.Empty;

            try
            {
                sentence = crawler
                    .GoToUrl(url)
                    .GetTextContentFromElement(".sentence");
            } 
            catch(CrawlerException ex)
            {
                Console.WriteLine(ex.Message);
            }

            var bytesCount = 0;

            try
            {
                var bytesFromPage = crawler
                    .GoToUrl(url2+sentence)
                    .GetTextContentFromElement("#bytes");

                bytesCount = int.Parse(bytesFromPage.Split(" ")[0]);
            }
            catch (CrawlerException ex)
            {
                bytesCount = BytesService.CountFromString(sentence); 
            }
            finally
            {
                crawler.Quit();
            }


            Console.ReadLine();
        }
    }
}

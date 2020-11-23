using System;
using System.IO;

namespace DesafioTecnicoMP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando a aplicação...");

            var firstCrawlerUrl = @"https://lerolero.com/";
            var secondCrawlerUrl = @"https://mothereff.in/byte-counter#";

            var crawler = new CrawlerService();

            var sentence = string.Empty;

            try
            {
                Console.WriteLine("Iniciando o crawler do primeiro site...");
                sentence = crawler
                    .GoToUrl(firstCrawlerUrl)
                    .GetTextContentFromElement(".sentence");
                Console.WriteLine("Crawler do primeiro site finalizado com sucesso...");
            }
            catch (CrawlerException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            var bytesCount = 0;

            try
            {
                Console.WriteLine("Iniciando o crawler do segundo site...");
                var bytesFromPage = crawler
                    .GoToUrl(secondCrawlerUrl + sentence)
                    .GetTextContentFromElement("#bytes");

                bytesCount = int.Parse(bytesFromPage.Split(" ")[0]);
                Console.WriteLine("Crawler do segundo site finalizado com sucesso...");
            }
            catch (CrawlerException)
            {
                bytesCount = BytesService.CountFromString(sentence);
            }
            finally
            {
                crawler.Quit();
            }

            //var sentence = "O empenho em analisar a mobilidade dos capitais internacionais auxilia a preparação e a composição das condições inegavelmente apropriadas.";
            //var bytesCount = 145;
            var fileSize = 3565158; // 3.482MB
            var bufferLength = 1048576;

            Console.WriteLine("Iniciando a escrita do texto no arquivo utilizando buffer...");

            var path = Path.Join(@"D:", @"dev");

            var writeBuffer = new WriteBuffer(bufferLength)
                .StringInput(sentence)
                .BytesCount(bytesCount);

            var report = new FileService(path, fileSize)
                .WriteUsingBufferUntilEnd(writeBuffer)
                .Report();

            //Console.Clear();
            Console.WriteLine("Escrita do texto no arquivo finalizada com sucesso...");

            var consoleTable = new ConsoleTable(200);
            consoleTable.PrintLine();
            consoleTable.PrintRow("Nome", "Tamanho", "Path", "Iterações", "Tempo Total", "Tempo Médio");
            consoleTable.PrintLine();
            consoleTable.PrintRow(report.FileName, report.FileSize.ToString(), report.Path, report.Iterations.ToString(), "0", "0");
            consoleTable.PrintLine();
            Console.ReadLine();
        }
    }
}

using DesafioTecnicoMP.Models;
using System;

namespace DesafioTecnicoMP
{
    class Program
    {
        private const string FIRST_CRAWLER_URL = @"https://lerolero.com/";
        private const string SECOND_CRAWLER_URL = @"https://mothereff.in/byte-counter#";

        private const string FILE_SIZE_ARGUMENT = "-f";
        private const string BUFFER_LENGTH_ARGUMENT = "-b";
        private const string PATH_ARGUMENT = "-p";

        static void Main(string[] args)
        {
            var argumentsFactory = new ArgumentsFactory(args, FILE_SIZE_ARGUMENT, BUFFER_LENGTH_ARGUMENT, PATH_ARGUMENT);

            var fileSizeArgument = (FileSizeArgument)argumentsFactory.GetArgument(FILE_SIZE_ARGUMENT);
            var bufferLengthArgument = (BufferLengthArgument)argumentsFactory.GetArgument(BUFFER_LENGTH_ARGUMENT);
            var pathArgument = (PathArgument)argumentsFactory.GetArgument(PATH_ARGUMENT);

            //Console.WriteLine("Starting application...");

            //var crawler = new CrawlerService();

            //string sentence;

            //try
            //{
            //    Console.WriteLine("Starting first crawler...");
            //    sentence = crawler
            //        .GoToUrl(FIRST_CRAWLER_URL)
            //        .GetTextContentFromElement(".sentence");
            //    Console.WriteLine("First crawler successfully completed...");
            //}
            //catch (CrawlerException ex)
            //{
            //    Console.WriteLine("[ERROR] " + ex.Message);
            //    Console.ReadLine();
            //    return;
            //}

            //var bytesCount = 0;

            //try
            //{
            //    Console.WriteLine("Starting second crawler...");
            //    var bytesFromPage = crawler
            //        .GoToUrl(SECOND_CRAWLER_URL + sentence)
            //        .GetTextContentFromElement("#bytes");

            //    bytesCount = int.Parse(bytesFromPage.Split(" ")[0]);
            //    Console.WriteLine("Second crawler successfully completed...");
            //}
            //catch (CrawlerException)
            //{
            //    bytesCount = BytesService.CountFromString(sentence);
            //}
            //finally
            //{
            //    crawler.Quit();
            //}

            //Console.WriteLine("Starting to write in the file using buffer...");

            //var writeBuffer = new WriteBuffer(bufferLength)
            //    .StringInput(sentence)
            //    .BytesCount(bytesCount);

            //var report = new FileService(path, fileSize)
            //    .WriteUsingBufferUntilEnd(writeBuffer)
            //    .Report();

            //Console.WriteLine("Writing to file successfully completed...");

            //PrintReport(report);
        }

        static void PrintReport(Report report)
        {
            var consoleTable = new ConsoleTable(200);
            consoleTable.PrintLine();
            consoleTable.PrintRow("Nome", "Tamanho", "Path", "Iterações", "Tempo Total", "Tempo Médio");
            consoleTable.PrintLine();
            consoleTable.PrintRow(
                report.FileName,
                report.FileSize.ToString(),
                report.Path,
                report.Iterations.ToString(),
                report.TotalTime.ToString(),
                report.AverageTime.ToString());
            consoleTable.PrintLine();
            Console.ReadLine();
        }
    }
}

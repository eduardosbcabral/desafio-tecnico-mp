using System;

namespace DesafioTecnicoMP
{
    class Program
    {
        private const long DEFAULT_FILE_SIZE = 104857600;
        private const long DEFAULT_BUFFER_LENGTH = 1048576;
        private const string FIRST_CRAWLER_URL = @"https://lerolero.com/";
        private const string SECOND_CRAWLER_URL = @"https://mothereff.in/byte-counter#";

        static void Main(string[] args)
        {
            var fileSizeArg = GetArgValue<long>(args, "-f");
            var bufferLengthArg = GetArgValue<long>(args, "-b");
            var path = GetArgValue<string>(args, "-p");

            if (string.IsNullOrEmpty(path))
            {
                Console.WriteLine("The argument -p (Path) is required.");
                return;
            }

            if (fileSizeArg <= 0)
            {
                Console.WriteLine("The argument -f (File Size) is invalid, should be higher than zero.");
                return;
            }

            long fileSize;

            if (fileSizeArg == 0)
            {
                fileSize = DEFAULT_FILE_SIZE;
            }
            else
            {
                fileSize = BytesService.ConvertMegabytesToBytes(fileSizeArg);
            }

            if (bufferLengthArg < 0)
            {
                Console.WriteLine("The argument -b (Buffer Length) is invalid, should be higher than zero.");
                return;
            }

            long bufferLength;

            if (bufferLengthArg == 0)
            {
                bufferLength = DEFAULT_BUFFER_LENGTH;
            }
            else
            {
                bufferLength = BytesService.ConvertMegabytesToBytes(bufferLengthArg);
            }

            Console.WriteLine("Starting application...");

            var crawler = new CrawlerService();

            string sentence;

            try
            {
                Console.WriteLine("Starting first crawler...");
                sentence = crawler
                    .GoToUrl(FIRST_CRAWLER_URL)
                    .GetTextContentFromElement(".sentence");
                Console.WriteLine("First crawler successfully completed...");
            }
            catch (CrawlerException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            var bytesCount = 0;

            try
            {
                Console.WriteLine("Starting second crawler...");
                var bytesFromPage = crawler
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
                crawler.Quit();
            }

            Console.WriteLine("Starting to write in the file using buffer...");

            var writeBuffer = new WriteBuffer(bufferLength)
                .StringInput(sentence)
                .BytesCount(bytesCount);

            var report = new FileService(path, fileSize)
                .WriteUsingBufferUntilEnd(writeBuffer)
                .Report();

            Console.WriteLine("Writing to file successfully completed...");

            PrintReport(report);
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

        static T GetArgValue<T>(string[] args, string argName)
        {
            T argValue = default;
            for(var i = 0; i < args.Length; i++)
            {
                if(args[i] == argName)
                {
                    try
                    {
                        argValue = (T)Convert.ChangeType(args[i + 1], typeof(T));
                    }
                    catch (Exception)
                    {
                        throw new ArgumentException("An error occurred while running the application with the parameters.");
                    }
                }
            }
            return argValue;
        }
    }
}

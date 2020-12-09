using DesafioTecnicoMP.Exceptions;
using DesafioTecnicoMP.Models;
using DesafioTecnicoMP.Services;
using System;

namespace DesafioTecnicoMP
{
    class Program
    {
        private const string FILE_SIZE_ARGUMENT = "-f";
        private const string BUFFER_LENGTH_ARGUMENT = "-b";
        private const string PATH_ARGUMENT = "-p";

        static void Main(string[] args)
        {
            var argumentsFactory = new ArgumentsFactory(args, FILE_SIZE_ARGUMENT, BUFFER_LENGTH_ARGUMENT, PATH_ARGUMENT);

            var fileSizeArgument = (FileSizeArgument)argumentsFactory.GetArgument(FILE_SIZE_ARGUMENT);
            var bufferLengthArgument = (BufferLengthArgument)argumentsFactory.GetArgument(BUFFER_LENGTH_ARGUMENT);
            var pathArgument = (PathArgument)argumentsFactory.GetArgument(PATH_ARGUMENT);

            Console.WriteLine("Starting application...");

            var crawler = new CrawlerService(new SeleniumService())
                .Setup();

            var crawlerStatement = new CrawlerStatement(crawler);

            var sentence = crawlerStatement.GetSentence();
            var bytesCount = crawlerStatement.GetBytesCount(sentence);

            Console.WriteLine("Starting to write in the file using buffer...");

            var writeBuffer = new WriteBuffer(bufferLengthArgument.GetValue())
                .StringInput(sentence)
                .BytesCount(bytesCount);

            var report = new FileService(pathArgument.GetValue(), fileSizeArgument.GetValue())
                .WriteUsingBufferUntilEnd(writeBuffer)
                .Report();

            Console.WriteLine("Writing to file successfully completed...");

            report.Print();
        }
    }
}

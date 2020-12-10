using DesafioTecnicoMP.Exceptions;
using DesafioTecnicoMP.Models;
using DesafioTecnicoMP.Services;
using System;

namespace DesafioTecnicoMP
{
    class Program
    {
        static void Main(string[] args)
        {
            var argumentsFactory = new ArgumentsFactory(args, 
                ArgumentsConstants.FILE_SIZE_ARGUMENT,
                ArgumentsConstants.BUFFER_LENGTH_ARGUMENT,
                ArgumentsConstants.PATH_ARGUMENT);

            var fileSizeArgument = argumentsFactory.CreateArgument<FileSizeArgument>(ArgumentsConstants.FILE_SIZE_ARGUMENT);
            var bufferLengthArgument = argumentsFactory.CreateArgument<BufferLengthArgument>(ArgumentsConstants.BUFFER_LENGTH_ARGUMENT);
            var pathArgument = argumentsFactory.CreateArgument<PathArgument>(ArgumentsConstants.PATH_ARGUMENT);

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

using System;
using System.IO;

namespace DesafioTecnicoMP
{
    class Program
    {
        static void Main(string[] args)
        {
            //var url = @"https://lerolero.com/";
            //var url2 = @"https://mothereff.in/byte-counter#";

            //CrawlerService crawler = new CrawlerService(url);

            //var sentence = string.Empty;

            //try
            //{
            //    sentence = crawler
            //        .GoToUrl(url)
            //        .GetTextContentFromElement(".sentence");
            //} 
            //catch(CrawlerException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //var bytesCount = 0;

            //try
            //{
            //    var bytesFromPage = crawler
            //        .GoToUrl(url2+sentence)
            //        .GetTextContentFromElement("#bytes");

            //    bytesCount = int.Parse(bytesFromPage.Split(" ")[0]);
            //}
            //catch (CrawlerException)
            //{
            //    bytesCount = BytesService.CountFromString(sentence); 
            //}
            //finally
            //{
            //    crawler.Quit();
            //}

            var sentence = "O empenho em analisar a mobilidade dos capitais internacionais auxilia a preparação e a composição das condições inegavelmente apropriadas.";
            var bytesCount = BytesService.CountFromString(sentence);

            var sentenceInBytes = BytesService.StringToBytes(sentence);

            var path = @"D:\dev\desafio.txt";
            int bufferSize = 1048576;
            var buffer = new byte[bufferSize];

            for (var i = 0; i < bufferSize && (bytesCount + i < bufferSize); i+=bytesCount)
            {
                for(var j = 0; j < bytesCount; j++)
                {
                    buffer[i+j] = sentenceInBytes[j];
                }
            }

            var isEqual = true;
            for (var i = 0; i < bufferSize && (bytesCount+ i < bufferSize); i+=bytesCount)
            {
                for (var j = 0; j < bytesCount; j++)
                {
                    if(buffer[i + j] != sentenceInBytes[j])
                    {
                        throw new Exception("O buffer não está preenchido corretamente.");
                    }
                }
            }

            for (var i = bufferSize-1; i > 0; i--)
            {
                var a = buffer[i];
                if(a != 0)
                {
                    var t = $"Mudou o valor no indice {i} {bufferSize-i}";
                }
            }

            //if (!File.Exists(path)) File.Create(path);

            //Stream dest = null;
            //using var source = File.OpenRead(path);
            //var buffer = new byte[bufferSize];
            //int bytesRead;
            //while ((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0)
            //{
            //    dest.Write(buffer, 0, bytesRead);
            //}

            Console.ReadLine();
        }
    }
}

using System;

namespace DesafioTecnicoMP
{
    public class Report
    {
        public string FileName { get; private set; }
        public string FileSize { get; private set; }
        public string Path { get; private set; }
        public int Iterations { get; private set; }
        public TimeSpan TotalTime { get; private set; }
        public TimeSpan AverageTime { get; private set; }

        public Report(string fileName, long fileSize, string path, int iterations, TimeSpan totalTime, TimeSpan averageTime)
        {
            FileName = fileName;
            FileSize = BytesService.ConvertBytesToMegabytes(fileSize) + "mb";
            Path = path;
            Iterations = iterations;
            TotalTime = totalTime;
            AverageTime = averageTime;
        }

        public void Print()
        {
            var consoleTable = new ConsoleTable(200);
            consoleTable.PrintLine();
            consoleTable.PrintRow("Nome", "Tamanho", "Path", "Iterações", "Tempo Total", "Tempo Médio");
            consoleTable.PrintLine();
            consoleTable.PrintRow(
                FileName,
                FileSize.ToString(),
                Path,
                Iterations.ToString(),
                TotalTime.ToString(),
                AverageTime.ToString());
            consoleTable.PrintLine();
            Console.ReadLine();
        }
    }
}

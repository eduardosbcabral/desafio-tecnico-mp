using System;
using System.Diagnostics;

namespace DesafioTecnicoMP
{
    public class Report
    {
        public string FileName { get; private set; }
        public int FileSize { get; private set; }
        public string Path { get; private set; }
        public int Iterations { get; private set; }
        public TimeSpan TotalTime { get; private set; }
        public TimeSpan AverageTime { get; private set; }

        public Report(string fileName, int fileSize, string path, int iterations, TimeSpan totalTime, TimeSpan averageTime)
        {
            FileName = fileName;
            FileSize = fileSize;
            Path = path;
            Iterations = iterations;
            TotalTime = totalTime;
            AverageTime = averageTime;
        }
    }
}

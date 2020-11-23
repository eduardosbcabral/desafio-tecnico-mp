using System;
using System.Diagnostics;
using System.IO;

namespace DesafioTecnicoMP
{
    public class FileService
    {
        private readonly string _path;
        private readonly string _fileName;
        private readonly string _fullPath;

        private readonly long _fileSize;

        private int _iterations = 0;

        private readonly Stopwatch _stopWatch;

        public FileService(string path, long fileSize)
        {
            _path = Path.Join(@"D:", @"dev");
            _fileName = $"{DateTime.Now:yyyy-MM-dd-HHmmss}-desafio.txt";
            _fullPath = Path.Combine(path, _fileName);

            _fileSize = fileSize;

            _stopWatch = new Stopwatch();
        }

        public FileService WriteUsingBufferUntilEnd(WriteBuffer writeBuffer)
        {
            var bufferLength = writeBuffer.BufferLength();

            _stopWatch.Start();

            using FileStream fs = File.OpenWrite(_fullPath);

            for (var i = 0d; i < _fileSize; i += bufferLength)
            {
                var buffer = writeBuffer
                    .WriteUntilEnd()
                    .Buffer();

                var writeLength = bufferLength;

                if ((i + bufferLength) > _fileSize)
                {
                    writeLength = (long)(_fileSize - i);
                }

                fs.Write(buffer, 0, (int)writeLength);

                writeBuffer.Clear();

                _iterations++;
            }

            Close();

            _stopWatch.Stop();

            return this;
        }

        public Report Report()
        {
            return new Report(_fileName, _fileSize, _path, _iterations, _stopWatch.Elapsed, _stopWatch.Elapsed/_iterations);
        }

        private FileService Close()
        {
            return this;
        }
    }
}

using DesafioTecnicoMP.Interfaces;
using DesafioTecnicoMP.Models;
using System;
using System.Diagnostics;
using System.IO;

namespace DesafioTecnicoMP.Services
{
    public class FileService : IFileService
    {
        public string Path { get; private set; }
        public string FileName { get; private set; }
        public string FullPath { get; private set; }

        private readonly long _fileSize;

        private int _iterations = 0;

        private readonly Stopwatch _stopWatch;

        public FileService(string path, long fileSize)
        {
            Path = path;
            FileName = $"{DateTime.Now:yyyy-MM-dd-HHmmss}-desafio.txt";
            FullPath = System.IO.Path.Combine(path, FileName);

            _fileSize = fileSize;

            _stopWatch = new Stopwatch();
        }

        public FileService WriteUsingBufferUntilEnd(IWriteBuffer writeBuffer)
        {
            var bufferLength = writeBuffer.BufferLength();

            _stopWatch.Start();

            using FileStream fs = File.OpenWrite(FullPath);

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
            return new Report(FileName, _fileSize, Path, _iterations, _stopWatch.Elapsed, _stopWatch.Elapsed/_iterations);
        }

        private FileService Close()
        {
            return this;
        }
    }
}

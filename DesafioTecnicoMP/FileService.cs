using System;
using System.IO;

namespace DesafioTecnicoMP
{
    public class FileService
    {
        private readonly string _path;
        private readonly string _fileName;
        private readonly string _fullPath;

        private readonly int _fileSize;

        private int _iterations = 0;

        public FileService(string path, int fileSize)
        {
            _path = Path.Join(@"D:", @"dev");
            _fileName = $"{DateTime.Now:yyyy-MM-dd-HHmmss}-desafio.txt";
            _fullPath = Path.Combine(path, _fileName);

            _fileSize = fileSize;
        }

        public FileService WriteUsingBufferUntilEnd(WriteBuffer writeBuffer)
        {
            using FileStream fs = File.OpenWrite(_fullPath);

            var bufferLength = writeBuffer.BufferLength();

            for (var i = 0; i < _fileSize; i += bufferLength)
            {
                var buffer = writeBuffer
                    .WriteUntilEnd()
                    .Buffer();

                var writeLenth = bufferLength;

                if ((i + bufferLength) > _fileSize)
                {
                    writeLenth = _fileSize - i;
                }

                fs.Write(buffer, 0, writeLenth);

                writeBuffer.Clear();

                _iterations++;
            }

            Close();

            return this;
        }

        public Report Report()
        {
            return new Report(_fileName, _fileSize, _path, _iterations, DateTime.Now, DateTime.Now);
        }

        private FileService Close()
        {
            return this;
        }
    }
}

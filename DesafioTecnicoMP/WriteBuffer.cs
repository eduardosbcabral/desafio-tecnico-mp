using System;

namespace DesafioTecnicoMP
{
    public class WriteBuffer
    {
        private readonly byte[] _buffer;

        private readonly int _bufferLength;

        private string _str;
        private int _bytesCount;
        private byte[] _strInBytes;

        public WriteBuffer(int bufferLength = 1048576)
        {
            _bufferLength = bufferLength;
            _buffer = new byte[_bufferLength];
        }

        public WriteBuffer StringInput(string str)
        {
            _str = str;
            _strInBytes = BytesService.StringToBytes(_str);
            return this;
        }

        public WriteBuffer BytesCount(int bytesCount)
        {
            Validate();
            _bytesCount = bytesCount;
            return this;
        }

        public int BufferLength()
        {
            return _bufferLength;
        }

        public byte[] Buffer()
        {
            return _buffer;
        }

        public WriteBuffer Clear()
        {
            Array.Clear(_buffer, 0, _bufferLength);
            return this;
        }

        public WriteBuffer WriteUntilEnd()
        {
            Validate();

            for (var i = 0; i < _bufferLength; i += _bytesCount)
            {
                for (var j = 0; j < _bytesCount; j++)
                {
                    if ((i + j) >= _bufferLength) break;

                    _buffer[i + j] = _strInBytes[j];
                }
            }

            if (!CheckBufferIntegrity())
            {
                throw new Exception("Buffer não está íntegro.");
            }

            return this;
        }

        public bool CheckBufferIntegrity()
        {
            Validate();

            var integrity = true;
            for (var i = 0; i < _bufferLength && (_bytesCount + i < _bufferLength); i += _bytesCount)
            {
                for (var j = 0; j < _bytesCount; j++)
                {
                    if (_buffer[i + j] != _strInBytes[j])
                    {
                        integrity = false;
                    }
                }
            }

            return integrity;
        }

        private void Validate()
        {
            if (string.IsNullOrEmpty(_str))
            {
                throw new ArgumentNullException("Defina o valor da string para utilizar o buffer de escrita.");
            }
        }
    }
}

using DesafioTecnicoMP.Interfaces;
using System;

namespace DesafioTecnicoMP.Services
{
    public class WriteBuffer : IWriteBuffer
    {
        private readonly byte[] _buffer;

        private readonly long _bufferLength;

        private string _str;
        private int _bytesCount;
        private byte[] _strInBytes;

        private readonly bool _integrityCheck;

        public WriteBuffer(long bufferLength, bool integrityCheck = false)
        {
            _bufferLength = bufferLength;
            _buffer = new byte[_bufferLength];

            _integrityCheck = integrityCheck;
        }

        public IWriteBuffer StringInput(string str)
        {
            _str = str;

            Validate();

            _strInBytes = BytesService.StringToBytes(_str);
            return this;
        }

        public IWriteBuffer BytesCount(int bytesCount)
        {
            Validate();
            _bytesCount = bytesCount;
            return this;
        }

        public long BufferLength()
        {
            return _bufferLength;
        }

        public byte[] Buffer()
        {
            return _buffer;
        }

        public IWriteBuffer Clear()
        {
            Array.Clear(_buffer, 0, (int)_bufferLength);
            return this;
        }

        public IWriteBuffer WriteUntilEnd()
        {
            Validate();

            if(_bytesCount == 0)
            {
                _bytesCount = BytesService.CountFromString(_str);
            }

            for (var i = 0L; i < _bufferLength; i += _bytesCount)
            {
                for (var j = 0; j < _bytesCount; j++)
                {
                    if ((i + j) >= _bufferLength) break;

                    _buffer[i + j] = _strInBytes[j];
                }
            }

            if (_integrityCheck && !CheckBufferIntegrity())
            {
                throw new Exception("Buffer não está íntegro.");
            }

            return this;
        }

        private bool CheckBufferIntegrity()
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

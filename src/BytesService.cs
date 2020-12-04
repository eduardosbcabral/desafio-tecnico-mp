using System;
using System.Text;

namespace DesafioTecnicoMP
{
    public class BytesService
    {
        public static int CountFromString(string str)
        {
            if (string.IsNullOrEmpty(str))
                throw new ArgumentException(nameof(str), "Argument cannot be null.");

            return Encoding.UTF8.GetByteCount(str);
        }

        public static byte[] StringToBytes(string str)
        {
            if (string.IsNullOrEmpty(str))
                throw new ArgumentException(nameof(str), "Argument cannot be null.");

            return Encoding.UTF8.GetBytes(str);
        }

        public static long ConvertMegabytesToBytes(long megabytes)
        {
            if (megabytes <= 0)
                throw new ArgumentException(nameof(megabytes), "Argument cannot be zero or lesser.");

            return megabytes * 1048576;
        }

        public static long ConvertBytesToMegabytes(long bytes)
        {
            if (bytes <= 0)
                throw new ArgumentException(nameof(bytes), "Argument cannot be zero or lesser.");

            return bytes / 1024 / 1024;
        }
    }
}

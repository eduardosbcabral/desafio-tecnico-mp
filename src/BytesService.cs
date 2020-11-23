using System.Text;

namespace DesafioTecnicoMP
{
    public class BytesService
    {
        public static int CountFromString(string str)
        {
            return Encoding.UTF8.GetByteCount(str);
        }

        public static byte[] StringToBytes(string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }

        public static long ConvertMegabytesToBytes(long mb)
        {
            return mb * 1048576;
        }

        public static long ConvertBytesToMegabytes(long bytes)
        {
            return bytes / 1024 / 1024;
        }
    }
}

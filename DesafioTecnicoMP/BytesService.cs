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
    }
}

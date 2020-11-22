using System.Text;

namespace DesafioTecnicoMP
{
    public class BytesService
    {
        public static int CountFromString(string str)
        {
            return Encoding.UTF8.GetByteCount(str);
        }
    }
}

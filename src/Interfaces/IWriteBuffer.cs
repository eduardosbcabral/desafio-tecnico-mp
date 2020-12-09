namespace DesafioTecnicoMP.Interfaces
{
    public interface IWriteBuffer
    {
        IWriteBuffer StringInput(string str);
        IWriteBuffer BytesCount(int bytesCount);
        IWriteBuffer Clear();
        IWriteBuffer WriteUntilEnd();

        long BufferLength();
        byte[] Buffer();
    }
}

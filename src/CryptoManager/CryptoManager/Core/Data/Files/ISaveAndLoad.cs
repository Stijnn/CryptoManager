namespace CryptoManager
{
    public interface ISaveAndLoad
    {
        void SaveFile(string filename, string text);
        string LoadFile(string filename);
    }
}

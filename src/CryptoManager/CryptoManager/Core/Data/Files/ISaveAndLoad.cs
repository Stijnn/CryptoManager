using System.Threading.Tasks;

namespace CryptoManager
{
    public interface ISaveAndLoad
    {
        void SaveFile(string filename, string text);
        Task<string> LoadFile(string filename);
        bool Exists(string filename);
    }
}

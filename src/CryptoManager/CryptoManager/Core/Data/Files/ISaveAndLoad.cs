using System.Threading.Tasks;

namespace CryptoManager
{
    public interface ISaveAndLoad
    {
        void SaveFile(string filename, string text);
        void DeleteFile(string filename);
        Task<string> LoadFile(string filename);
        bool Exists(string filename);
        Task<T> GetSingleJsonValue<T>(string filename, string name);
        Task<T> GetSingleJsonValue<T>(string filename, string name, int index);
    }
}

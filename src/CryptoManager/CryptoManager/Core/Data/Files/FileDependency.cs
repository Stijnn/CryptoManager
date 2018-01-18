using System.Threading.Tasks;
using Xamarin.Forms;

namespace CryptoManager.Files
{
    public static class FileDependency
    {
        public static async Task<string> LoadFile(string filename)
        {
            return await DependencyService.Get<ISaveAndLoad>().LoadFile(filename);
        }

        public static void SaveFile(string filename, string text)
        {
            DependencyService.Get<ISaveAndLoad>().SaveFile(filename, text);
        }

        public static bool Exists(string filename)
        {
            return DependencyService.Get<ISaveAndLoad>().Exists(filename);
        }
    }
}

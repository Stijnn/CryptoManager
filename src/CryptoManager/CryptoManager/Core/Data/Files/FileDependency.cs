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

        public static void DeleteFile(string filename)
        {
            DependencyService.Get<ISaveAndLoad>().DeleteFile(filename);
        }

        public static bool Exists(string filename)
        {
            return DependencyService.Get<ISaveAndLoad>().Exists(filename);
        }

        /// <summary>
        /// For non JSON arrays
        /// </summary>
        public static async Task<T> GetSingleJsonValue<T>(string filename, string name)
        {
            return await DependencyService.Get<ISaveAndLoad>().GetSingleJsonValue<T>(filename, name);
        }

        /// <summary>
        /// For JSON arrays
        /// </summary>
        public static async Task<T> GetSingleJsonValue<T>(string filename, string name, int index)
        {
            return await DependencyService.Get<ISaveAndLoad>().GetSingleJsonValue<T>(filename, name, index);
        }
    }
}

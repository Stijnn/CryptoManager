using Xamarin.Forms;

namespace CryptoManager.Files
{
    public static class FileDependency
    {
        public static string LoadFile(string filename)
        {
            return DependencyService.Get<ISaveAndLoad>().LoadFile(filename);
        }

        public static void SaveFile(string filename, string text)
        {
            DependencyService.Get<ISaveAndLoad>().SaveFile(filename, text);
        }
    }
}

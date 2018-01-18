using System;
using System.IO;
using Newtonsoft.Json;
using Environment = System.Environment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoManager.Droid
{
    class SaveAndLoad : ISaveAndLoad
    {
        public async Task<string> LoadFile(string filename)
        {
            string saveFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string savePath = Path.Combine(saveFolder, filename);
            using (StreamReader reader = File.OpenText(savePath))
            {
                return await reader.ReadToEndAsync();
            }
        }

        public void SaveFile(string filename, string text)
        {
            string saveFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string savePath = Path.Combine(saveFolder, filename);
            File.WriteAllText(savePath, text);
        }

        public bool Exists(string filename)
        {
            string saveFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string savePath = Path.Combine(saveFolder, filename);
            return File.Exists(savePath);
        }
    }
}
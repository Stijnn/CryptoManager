using System;
using System.IO;
using Newtonsoft.Json;
using Environment = System.Environment;
using System.Collections.Generic;

using Foundation;
using UIKit;
using System.Threading.Tasks;

namespace CryptoManager.iOS
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

        public void DeleteFile(string filename)
        {
            string saveFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string savePath = Path.Combine(saveFolder, filename);
            File.Delete(savePath);
        }

        public bool Exists(string filename)
        {
            string saveFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string savePath = Path.Combine(saveFolder, filename);
            return File.Exists(savePath);
        }

        public async Task<T> GetSingleJsonValue<T>(string filename, string name)
        {
            string file = await LoadFile(filename);
            dynamic data = await Task.Run(() => JsonConvert.DeserializeObject(file));
            return (T)data[name];
        }

        public async Task<T> GetSingleJsonValue<T>(string filename, string name, int index)
        {
            string file = await LoadFile(filename);
            dynamic data = await Task.Run(() => JsonConvert.DeserializeObject(filename));
            return (T)data[index][name];
        }
    }
}
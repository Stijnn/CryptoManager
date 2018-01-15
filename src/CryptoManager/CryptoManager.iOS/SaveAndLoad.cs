using System;
using System.IO;
using Newtonsoft.Json;
using Environment = System.Environment;
using System.Collections.Generic;

using Foundation;
using UIKit;

namespace CryptoManager.iOS
{
    class SaveAndLoad : ISaveAndLoad
    {
        public string LoadFile(string filename)
        {
            string saveFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string savePath = Path.Combine(saveFolder, filename);
            return File.ReadAllText(savePath);
        }

        public void SaveFile(string filename, string text)
        {
            string saveFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string savePath = Path.Combine(saveFolder, filename);
            File.WriteAllText(savePath, text);
        }
    }
}
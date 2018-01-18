using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CryptoManager.Core
{
    class Fetcher
    {
        public static async Task<dynamic> FetchJson()
        {
            if (!Files.FileDependency.Exists("test.json"))
            {
                HttpClient client = new HttpClient();
                var response = await client.GetAsync("https://api.coinmarketcap.com/v1/ticker/?limit=0");
                dynamic data = null;
                if (response != null)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    data = await Task.Run(() => JsonConvert.DeserializeObject(json));
                    Files.FileDependency.SaveFile("test.json", json);
                }
                return data;
            }
            else
            {
                dynamic data = null;
                string json = await Files.FileDependency.LoadFile("test.json");
                data = await Task.Run(() => JsonConvert.DeserializeObject(json));
                return data;
            }
        }
    }
}

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CryptoManager.Core
{
    class Fetcher
    {
        private static bool _firstTimeSetup = false;
        public static async Task<dynamic> FetchCoinData()
        {
            string target = await TargetLoad();
            if (target == "Server")
            {
                HttpClient client = new HttpClient();
                var response = await client.GetAsync("https://api.coinmarketcap.com/v1/ticker/?limit=0");
                dynamic data = null;
                if (response != null)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    data = await Task.Run(() => JsonConvert.DeserializeObject(json));
                    Files.FileDependency.SaveFile("coinData.json", json);
                    SaveLastSyncDate();
                    _firstTimeSetup = false;
                }
                return data;
            }
            else if (target == "Local")
            {
                dynamic data = null;
                string json = await Files.FileDependency.LoadFile("coinData.json");
                data = await Task.Run(() => JsonConvert.DeserializeObject(json));
                return data;
            }
            else
                return null;
        }

        public static void FirstBootCheck()
        {
            //Files.FileDependency.DeleteFile("settings.json");
            if (!Files.FileDependency.Exists("settings.json"))
            {
                SaveLastSyncDate();
                _firstTimeSetup = true;
            }
        }

        public static void SaveLastSyncDate()
        {
            dynamic jsonObject = new JObject();
            DateTime date = DateTime.Now;
            jsonObject.lastSyncDate = date;
            Files.FileDependency.SaveFile("settings.json", jsonObject.ToString());
        }

        public static async Task<string> TargetLoad()
        {
            FirstBootCheck();

            string lastSyncDate = await Files.FileDependency.GetSingleJsonValue<string>("settings.json", "lastSyncDate");
            TimeSpan t1 = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"));
            TimeSpan t2 = TimeSpan.Parse(DateTime.Parse(lastSyncDate).ToString("HH:mm:ss"));
            TimeSpan t3 = t1.Subtract(t2);

            if (_firstTimeSetup)
                return "Server";

            if (!Files.FileDependency.Exists("coinData.json"))
                return "Server";
            else
            {
                if (t3.TotalMinutes > 5)
                    return "Server";
                else
                    return "Local";
            }
        }
    }
}

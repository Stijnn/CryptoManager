using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace CryptoManager
{
    class Service
    {
        public static async Task<dynamic> getData(string query)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(query);
            dynamic data = null;
            if (response != null)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject(json);
            }
            return data;
        }
    }
}

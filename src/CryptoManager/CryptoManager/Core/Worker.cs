using CryptoManager.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoManager.Core
{
    class Worker
    {
        public static async Task<Currency> GetCurrency(string coinId)
        {
            string query = $"https://api.coinmarketcap.com/v1/ticker/{coinId}/";
            dynamic results = await Service.getData(query).ConfigureAwait(false);

        }
    }
}

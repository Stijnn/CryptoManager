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
            dynamic results = await Service.getData(query).ConfigureAwait(true);
            if (results["id"] != null)
            {
                Currency cur = new Currency();
                cur.ID = results["id"];
                cur.Title = results["name"];
                cur.Symbol = results["symbol"];
                cur.CMCRank = results["rank"];
                cur.Price_USD = results["price_usd"];
                cur.Price_BTC = results["price_btc"];
                cur.Volume = results["24h_volume_usd"];
                cur.MCUsd = results["market_cap_usd"];
                cur.Available = results["available_supply"];
                cur.Total = results["total_supply"];
                cur.Max = results["max_supply"];
                cur.PercChangeHour = results["percent_change_1h"];
                cur.PercChangeDay = results["percent_change_24h"];
                cur.PercChangeWeek = results["percent_change_7d"];
                cur.LastUpdate = results["last_updated"];

                return cur;
            }
            else
            {
                return null;
            }
        }
    }
}

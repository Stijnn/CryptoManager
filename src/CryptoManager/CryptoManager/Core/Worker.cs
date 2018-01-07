using CryptoManager.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CryptoManager.Core
{
    class Worker
    {
        public static async Task<Currency> GetCurrency(string coinId)
        {
            string query = $"https://api.coinmarketcap.com/v1/ticker/{coinId}/";
            dynamic results = await Service.getData(query).ConfigureAwait(false);
            if (results != null)
            {
                Currency cur = new Currency();
                cur.ID = results[0]["id"];
                cur.Title = results[0]["name"];
                cur.Symbol = results[0]["symbol"];
                cur.CMCRank = results[0]["rank"];
                cur.Price_USD = results[0]["price_usd"];
                cur.Price_BTC = results[0]["price_btc"];
                cur.Volume = results[0]["24h_volume_usd"];
                cur.MCUsd = results[0]["market_cap_usd"];
                cur.Available = results[0]["available_supply"];
                cur.Total = results[0]["total_supply"];
                cur.Max = results[0]["max_supply"];
                cur.PercChangeHour = results[0]["percent_change_1h"];
                cur.PercChangeDay = results[0]["percent_change_24h"];
                cur.PercChangeWeek = results[0]["percent_change_7d"];
                cur.LastUpdate = results[0]["last_updated"];

                return cur;
            }
            else
            {
                return null;
            }
        }
    }
}

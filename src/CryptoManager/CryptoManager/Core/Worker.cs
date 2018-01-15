using CryptoManager.Core.Data;
using System;
using System.Threading.Tasks;

namespace CryptoManager.Core
{
    class Worker
    {
        public static async Task<Currency> GetCurrency(string coinId, string currency)
        {
            string query = $"https://api.coinmarketcap.com/v1/ticker/{coinId}/?convert={currency}";
            dynamic results = await Service.getData(query).ConfigureAwait(false);
            Currency cur = new Currency();

            if (results != null)
            {
                cur.ID = results[0].id;
                cur.Title = results[0].name;
                cur.Symbol = results[0].symbol;
                cur.CMCRank = results[0].rank;
                cur.Price_USD = results[0].price_usd;
                cur.Price_BTC = results[0].price_btc;
                cur.Volume = results[0]["24h_volume_usd"];
                cur.MCUsd = results[0].market_cap_usd;
                cur.Available = results[0].available_supply;
                cur.Total = results[0].total_supply;
                cur.Max = results[0].max_supply;
                cur.PercChangeHour = results[0].percent_change_1h;
                cur.PercChangeDay = results[0].percent_change_24h;
                cur.PercChangeWeek = results[0].percent_change_7d;
                cur.LastUpdate = Epoch.Timestamp(results[0].last_updated.Value.ToString());

                if (currency != "USD")
                {
                    BaseCurrency baseCur = await GetBaseCurrency(currency);
                    cur.Price_USD = (Decimal.Parse(cur.Price_USD) * Decimal.Parse(baseCur.Rates)).ToString();
                    return cur;
                }
                else
                    return cur;
            }
            else
            {
                return cur;
            }
        }
        public static async Task<BaseCurrency> GetBaseCurrency(string convert)
        {
            string query = $"https://api.fixer.io/latest?base=USD&symbols={convert}";
            dynamic results = await Service.getData(query).ConfigureAwait(false);
            BaseCurrency cur = new BaseCurrency();

            if (results != null)
            {
                cur.Base = results["base"];
                cur.Date = results.date;
                cur.Rates = results.rates[convert];
                return cur;
            }
            else
            {
                return cur;
            }
        }
    }
}
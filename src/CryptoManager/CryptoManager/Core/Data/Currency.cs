using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoManager.Core.Data
{
    class Currency
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public string Symbol { get; set; }
        public string CMCRank { get; set; }
        public string Price_USD { get; set; }
        public string Price_BTC { get; set; }
        public string Volume { get; set; }
        public string MCUsd { get; set; }
        public string Available { get; set; }
        public string Total { get; set; }
        public string Max { get; set; }
        public string PercChangeHour { get; set; }
        public string PercChangeDay { get; set; }
        public string PercChangeWeek { get; set; }
        public string LastUpdate { get; set; }

        public Currency()
        {
            ID = "-";
            Title = "-";
            Symbol = "-";
            CMCRank = "-";
            Price_USD = "-";
            Price_BTC = "-";
            Volume = "-";
            MCUsd = "-";
            Available = "-";
            Total = "-";
            Max = "-";
            PercChangeHour = "-";
            PercChangeDay = "-";
            PercChangeWeek = "-";
            LastUpdate = "-";
        }
    }
}

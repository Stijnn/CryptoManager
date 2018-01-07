using System;
using System.Threading.Tasks;

namespace CryptoManager.Core.Data
{
    class Epoch
    {
        public static async Task<string> Timestamp(double unixSec)
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unixSec);
            return $"{epoch.ToLongTimeString()} {epoch.ToLongDateString()}";
        }
    }
}

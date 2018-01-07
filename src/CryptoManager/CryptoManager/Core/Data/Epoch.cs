using System;
using System.Threading.Tasks;

namespace CryptoManager.Core.Data
{
    class Epoch
    {
        public static string Timestamp(string unixSec)
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Local).AddSeconds(Convert.ToDouble(unixSec));
            return $"{epoch.ToLongTimeString()} {epoch.ToLongDateString()}";
        }
    }
}

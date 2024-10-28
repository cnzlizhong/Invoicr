using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicrApp.constants
{
    internal class RegionTaxRates
    {
        public static readonly string NZ = "NZ";
        public static readonly string AU = "AU";
        public static readonly string UK = "UK";

        public static Dictionary<string, decimal> RegionTaxRatesDictionary = new Dictionary<string, decimal> {
            { NZ, 0.15m },
            { AU, 0.1m },
            { UK, 0.2m }
        };
    }
}

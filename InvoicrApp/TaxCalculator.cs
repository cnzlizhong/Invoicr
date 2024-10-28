using InvoicrApp.constants;
using InvoicrApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicrApp
{
    internal class TaxCalculator
    {
        public List<string> GenerateTaxLines(Invoice invoice)
        {
            var totalIncludingTax = invoice.LineItems.Sum(item => item.LineItemTotalCost);

            if (!RegionTaxRates.RegionTaxRatesDictionary.ContainsKey(invoice.Region))
            {
                throw new Exception($"Invalid region: {invoice.Region}");
            }

            var taxRate = RegionTaxRates.RegionTaxRatesDictionary[invoice.Region];
            var totalExcludingTax = decimal.Round(totalIncludingTax / (1 + taxRate), 2, MidpointRounding.AwayFromZero);
            var totalTax = decimal.Round(totalIncludingTax - totalExcludingTax, 2, MidpointRounding.AwayFromZero);
            var lines = new List<string>() { $"Total amount excluding tax: {totalExcludingTax}",
                $"Total tax amount: {totalTax}",
                $"Total amount including tax: {totalIncludingTax}", Environment.NewLine};
            return lines;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxes.Core
{
    public static class Helpers
    {
        public static decimal RoundUpToNearestFiveHundredths(decimal value)
        {
            return Math.Ceiling(value * 20) / 20;
        }

        public static decimal GetAmountOfTax(decimal priceWithoutTax, decimal taxInPercent)
        {
            return priceWithoutTax * taxInPercent / 100;
        }
    }
}

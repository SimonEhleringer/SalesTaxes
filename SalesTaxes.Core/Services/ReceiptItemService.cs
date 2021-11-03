using SalesTaxes.Core.Enums;
using SalesTaxes.Core.Models;
using SalesTaxes.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxes.Core.Services
{
    public class ReceiptItemService : IReceiptItemService
    {
        public ReceiptItem Create(Item item)
        {
            var receiptItem = new ReceiptItem()
            {
                Name = item.Name,
                PriceWithTax = GetPriceWithTax(item)
            };

            return receiptItem;
        }

        private static int GetTaxForItemInPercent(Item item)
        {
            var taxInPercent = 0;

            if (item.Category != Category.Books &&
                item.Category != Category.Food &&
                item.Category != Category.MedicalProducts)
            {
                taxInPercent += 10;
            }

            if (item.IsImported)
            {
                taxInPercent += 5;
            }

            return taxInPercent;
        }

        private static decimal GetPriceWithTax(Item item)
        {
            var taxInPercent = GetTaxForItemInPercent(item);

            var amountOfTax = Helpers.GetAmountOfTax(item.PriceWithoutTax, taxInPercent);

            var roundedAmountOfTax = Helpers.RoundUpToNearestFiveHundredths(amountOfTax);

            var priceWithTax = item.PriceWithoutTax + roundedAmountOfTax;

            return priceWithTax;
        }
    }
}

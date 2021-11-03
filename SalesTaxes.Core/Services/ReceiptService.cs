using SalesTaxes.Core.Models;
using SalesTaxes.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxes.Core.Services
{
    public class ReceiptService : IReceiptService
    {
        private readonly IReceiptItemService _receiptItemService;

        public ReceiptService(IReceiptItemService receiptItemService)
        {
            _receiptItemService = receiptItemService;
        }

        public Receipt Create(IList<Item> items)
        {
            decimal totalPrice = 0;
            decimal salesTaxes = 0;
            var receiptItems = new List<ReceiptItem>();

            foreach (var item in items)
            {
                var receiptItem = _receiptItemService.Create(item);
                receiptItems.Add(receiptItem);

                totalPrice += receiptItem.PriceWithTax;
                salesTaxes += receiptItem.PriceWithTax - item.PriceWithoutTax;
            }

            var receipt = new Receipt()
            {
                ReceiptItems = receiptItems,
                TotalPrice = totalPrice,
                SalesTaxes = salesTaxes
            };

            return receipt;
        }
    }
}

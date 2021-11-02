using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxes.Core.Models
{
    public class ReceiptItem
    {
        public string Name { get; set; }

        public decimal PriceWithTax { get; set; }
    }
}

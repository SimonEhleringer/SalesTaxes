using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxes.Core.Models
{
    public class Receipt
    {
        public IList<ReceiptItem> ReceiptItems { get; set; }

        public decimal SalesTaxes { get; set; }

        public decimal TotalPrice { get; set; }
    }
}

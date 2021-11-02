using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxes.Core.Models
{
    public class Receipt
    {
        public IList<ReceiptItem> receiptItems { get; set; }

        public double SalesTaxes { get; set; }

        public double TotalPrice { get; set; }
    }
}

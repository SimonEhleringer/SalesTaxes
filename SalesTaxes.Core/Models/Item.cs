using SalesTaxes.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxes.Core.Models
{
    public class Item
    {
        public string Name { get; set; }

        public decimal PriceWithoutTax { get; set; }

        public Category Category { get; set; }

        public bool IsImported { get; set; }
    }
}

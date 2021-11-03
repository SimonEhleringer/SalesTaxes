using SalesTaxes.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxes.Core.Services.Interfaces
{
    public interface IReceiptService
    {
        public Receipt Create(IList<Item> items);
    }
}

using SalesTaxes.Core.Enums;
using SalesTaxes.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxes.ConsoleApp
{
    public static class ItemGenerator
    {
        public static IList<Item> GetFirstItems()
        {
            var item1 = new Item()
            {
                Category = Category.Books,
                IsImported = false,
                Name = "Book",
                PriceWithoutTax = 12.49M
            };

            var item2 = new Item()
            {
                Category = Category.ElectronicProducts,
                IsImported = false,
                Name = "Music CD",
                PriceWithoutTax = 14.99M
            };

            var item3 = new Item()
            {
                Category = Category.Food,
                IsImported = false,
                Name = "Chocolate bar",
                PriceWithoutTax = 0.85M
            };

            var items = new List<Item>
            {
                item1,
                item2,
                item3
            };

            return items;
        }

        public static IList<Item> GetSecondItems()
        {
            var item1 = new Item()
            {
                Category = Category.Food,
                IsImported = true,
                Name = "Imported box of chocolates",
                PriceWithoutTax = 10.00M
            };

            var item2 = new Item()
            {
                Category = Category.CosmeticProducts,
                IsImported = true,
                Name = "Imported bottle of perfume",
                PriceWithoutTax = 47.50M
            };

            var items = new List<Item>
            {
                item1,
                item2
            };

            return items;
        }

        public static IList<Item> GetThirdItems()
        {
            var item1 = new Item()
            {
                Category = Category.CosmeticProducts,
                IsImported = true,
                Name = "Imported bottle of perfume",
                PriceWithoutTax = 27.99M
            };

            var item2 = new Item()
            {
                Category = Category.CosmeticProducts,
                IsImported = false,
                Name = "Bottle of perfume",
                PriceWithoutTax = 18.99M
            };

            var item3 = new Item()
            {
                Category = Category.MedicalProducts,
                IsImported = false,
                Name = "Packet of headache pills",
                PriceWithoutTax = 9.75M
            };

            var item4 = new Item()
            {
                Category = Category.Food,
                IsImported = true,
                Name = "Imported box of chocolates",
                PriceWithoutTax = 11.25M
            };

            var items = new List<Item>
            {
                item1,
                item2,
                item3,
                item4
            };

            return items;
        }
    }
}

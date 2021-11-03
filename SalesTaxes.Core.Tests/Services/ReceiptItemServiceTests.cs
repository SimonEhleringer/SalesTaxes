using SalesTaxes.Core.Enums;
using SalesTaxes.Core.Models;
using SalesTaxes.Core.Services;
using SalesTaxes.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SalesTaxes.Core.Tests.Services
{
    
    public class ReceiptItemServiceTests
    {
        private readonly IReceiptItemService _receiptItemService = new ReceiptItemService();

        [Theory]
        [InlineData(Category.Books, false, 12.49, 12.49)]
        [InlineData(Category.ElectronicProducts, false, 14.99, 16.49)]
        [InlineData(Category.Food, false, 0.85, 0.85)]
        [InlineData(Category.Food, true, 10.00, 10.50)]
        [InlineData(Category.CosmeticProducts, true, 47.50, 54.65)]
        [InlineData(Category.CosmeticProducts, true, 27.99, 32.19)]
        [InlineData(Category.CosmeticProducts, false, 18.99, 20.89)]
        [InlineData(Category.MedicalProducts, false, 9.75, 9.75)]
        [InlineData(Category.Food, true, 11.25, 11.85)]
        public void Create_ShouldGenerateCorrectTax(Category category, bool isImported, decimal priceWithoutTax, decimal ExpectedPriceWithTax)
        {
            // Arrange
            var item = new Item()
            {
                Category = category,
                IsImported = isImported,
                PriceWithoutTax = priceWithoutTax,
                Name = "Some test item"
            };

            // Act
            var receiptItem = _receiptItemService.Create(item);

            // Assert
            Assert.Equal(ExpectedPriceWithTax, receiptItem.PriceWithTax);
        }

        [Fact]
        public void Create_ShouldGenerateNameFromItem()
        {
            const string name = "Some test item";

            // Arrange
            var item = new Item()
            {
                Name = name
            };

            // Act
            var receiptItem = _receiptItemService.Create(item);

            // Assert
            Assert.Equal(name, receiptItem.Name);
        }
    }
}

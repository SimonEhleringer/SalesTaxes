using Moq;
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
    public class ReceiptServiceTests
    {
        private readonly Mock<IReceiptItemService> _receiptItemsServiceMock;
        private readonly IReceiptService _receiptService;

        public ReceiptServiceTests()
        {
            _receiptItemsServiceMock = new Mock<IReceiptItemService>();
            _receiptService = new ReceiptService(_receiptItemsServiceMock.Object);
        }

        [Fact]
        public void Create_ShouldGenerateReceipt()
        {
            // Arrange
            var item1 = new Item()
            {
                Category = Category.Books,
                IsImported = false,
                Name = "Item 1",
                PriceWithoutTax = 12.49M
            };

            var item2 = new Item()
            {
                Category = Category.ElectronicProducts,
                IsImported = false,
                Name = "Item 2",
                PriceWithoutTax = 14.99M
            };

            var item3 = new Item()
            {
                Category = Category.Food,
                IsImported = false,
                Name = "Item 3",
                PriceWithoutTax = 0.85M
            };

            var items = new List<Item>
            {
                item1,
                item2,
                item3
            };

            var receiptItem1 = new ReceiptItem()
            {
                Name = "ReceiptItem 1",
                PriceWithTax = 12.49M
            };

            var receiptItem2 = new ReceiptItem()
            {
                Name = "ReceiptItem 2",
                PriceWithTax = 16.49M
            };

            var receiptItem3 = new ReceiptItem()
            {
                Name = "ReceiptItem 3",
                PriceWithTax = 0.85M
            };

            _receiptItemsServiceMock.Setup(r => r.Create(item1)).Returns(receiptItem1);
            _receiptItemsServiceMock.Setup(r => r.Create(item2)).Returns(receiptItem2);
            _receiptItemsServiceMock.Setup(r => r.Create(item3)).Returns(receiptItem3);

            var expectedSalesTaxes = 1.5M;
            var expectedTotalPrice = 29.83M; 

            // Act
            var receipt = _receiptService.Create(items);

            // Assert
            Assert.Equal(expectedSalesTaxes, receipt.SalesTaxes);
            Assert.Equal(expectedTotalPrice, receipt.TotalPrice);

            Assert.Equal(items.Count, receipt.ReceiptItems.Count);
            Assert.Equal(receiptItem1, receipt.ReceiptItems[0]);
            Assert.Equal(receiptItem2, receipt.ReceiptItems[1]);
            Assert.Equal(receiptItem3, receipt.ReceiptItems[2]);
        }
    }
}

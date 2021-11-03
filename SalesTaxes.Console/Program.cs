using Microsoft.Extensions.Hosting;
using System;
using Microsoft.Extensions.DependencyInjection;
using SalesTaxes.Core.Services.Interfaces;
using SalesTaxes.Core.Services;
using SalesTaxes.Core.Models;
using SalesTaxes.Core.Enums;
using System.Collections.Generic;

namespace SalesTaxes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var receiptService = host.Services.GetService<IReceiptService>();

            var firstReceipt = receiptService.Create(ItemGenerator.GetFirstItems());
            PrintReceipt(1, firstReceipt);

            var secondReceipt = receiptService.Create(ItemGenerator.GetSecondItems());
            PrintReceipt(2, secondReceipt);

            var thirdReceipt = receiptService.Create(ItemGenerator.GetThirdItems());
            PrintReceipt(3, thirdReceipt);
        }

        private static void PrintReceipt(int caseNo, Receipt receipt)
        {
            Console.WriteLine($"Case {caseNo}");

            foreach (var receiptItem in receipt.ReceiptItems)
            {
                Console.WriteLine($"{receiptItem.Name}: {receiptItem.PriceWithTax}");
            };

            Console.WriteLine($"Sales Taxes: {receipt.SalesTaxes}");
            Console.WriteLine($"Total: {receipt.TotalPrice}");

            Console.WriteLine(string.Empty);
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddSingleton<IReceiptItemService, ReceiptItemService>();
                    services.AddSingleton<IReceiptService, ReceiptService>();
                });
        }
    }
}

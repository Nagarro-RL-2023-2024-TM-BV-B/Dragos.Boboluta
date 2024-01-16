using Nagarro.VendingMachine.UseCases.Payment;
using System;
using System.Collections.Generic;

namespace Nagarro.VendingMachine.PresentationLayer
{
    internal class BuyView : DisplayBase
    {
        public int RequestProduct()
        {
            Console.WriteLine();
            Display("Choose a product (Enter to cancel): ", ConsoleColor.Cyan);

            string rawValue = Console.ReadLine();
            Console.WriteLine();

            if (string.IsNullOrEmpty(rawValue))
                throw new CancelException();

            return int.Parse(rawValue);
        }

        public void DispenseProduct(string productName)
        {
            DisplayLine($"Pick up the product: {productName}", ConsoleColor.Yellow);
        }
        public int? AskForPaymentMethod(IEnumerable<PaymentMethod> paymentMethods)
        {
            return 1; 
        }
    }
}
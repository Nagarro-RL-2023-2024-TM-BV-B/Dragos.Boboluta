using Nagarro.VendingMachine.UseCases.Payment;
using System;
using System.Collections.Generic;
using System.Linq;

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
            Console.WriteLine();
            foreach (PaymentMethod paymentMethod in paymentMethods)
            {
                DisplayLine($"Available options : {paymentMethod.Name} ", ConsoleColor.White);
                Console.WriteLine();
            }
            Display("Choose a payment method (Enter to cancel): ", ConsoleColor.Cyan);

            string inputValue = Console.ReadLine();
            Console.WriteLine();

            if (string.IsNullOrEmpty(inputValue))
                throw new CancelException();

            var paymentId = paymentMethods.Where(x => x.Name == inputValue).First().Id;

            return paymentId != 0 ? paymentId : throw new CancelException();
        }
    }
}
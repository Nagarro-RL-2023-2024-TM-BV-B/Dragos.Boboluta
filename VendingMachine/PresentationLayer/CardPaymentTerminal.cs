using System;

namespace Nagarro.VendingMachine.PresentationLayer
{
    internal class CardPaymentTerminal : DisplayBase
    {
        public string AskForCardNumber()
        {
            Console.WriteLine();
            Display("Enter a credit card number (Enter to cancel): ", ConsoleColor.Cyan);

            string creditCardNumber = Console.ReadLine();
            Console.WriteLine();
            if (string.IsNullOrEmpty(creditCardNumber))
            {
                throw new CancelException();
            }

            return creditCardNumber;
        }
    }
}

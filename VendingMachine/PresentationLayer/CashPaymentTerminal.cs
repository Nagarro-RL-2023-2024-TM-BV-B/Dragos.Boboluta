using System;

namespace Nagarro.VendingMachine.PresentationLayer
{
    internal class CashPaymentTerminal : DisplayBase
    {
        public float? AskForMoney()
        {
            Console.WriteLine();
            Display("Enter money (Enter to cancel) in Ron : ", ConsoleColor.Cyan);

            string balance = Console.ReadLine();
            Console.WriteLine();

            if (string.IsNullOrEmpty(balance))
                throw new CancelException();
            return float.Parse(balance);
        }
        public void GiveBackChange(float balance)
        {
            Console.WriteLine();
            DisplayLine($"You received change : {balance} Ron ", ConsoleColor.Cyan);
            Console.WriteLine();
        }
    }
}

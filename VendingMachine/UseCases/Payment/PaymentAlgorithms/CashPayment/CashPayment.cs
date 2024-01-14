
using Nagarro.VendingMachine.PresentationLayer;
using System;

namespace Nagarro.VendingMachine.UseCases.Payment.PaymentAlgorithms.CashPayment
{
    public class CashPayment : IPaymenthAlgorithm
    {
        public string Name { get ; set ; }
        public CashPayment(string name)
        {
            Name = name;
        }

        public void Run(float price)
        {
            var terminal = new CashPaymentTerminal();

            float? balance = 0;
            float? value;
            while (price > 0)
            {
                try
                {
                    value = terminal.AskForMoney();
                    balance += value;

                    if (IsMonetaryValue(value.Value * 100))
                    {
                        price -= value.Value;
                        if (price > 0)
                        {
                            Console.WriteLine($"Remainding price : {price} Ron");
                        }
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Enter a valid monetary value ");
                        Console.WriteLine();
                    }
                }
                catch (Exception ex)
                {
                    terminal.GiveBackChange(balance.Value);
                    throw;
                }
            }
            if (price < 0)
            {
                float change = -price;
                float truncatedchange = (float)(Math.Floor(change * 1000) / 1000);
                terminal.GiveBackChange(truncatedchange);
            }
        }
        private static bool IsMonetaryValue(float price)
        {
            bool isValid = Enum.IsDefined(typeof(MonetaryValue), (int)price);
            return isValid ? true : false;
        }
        private enum MonetaryValue
        {
            UnBan = 1,
            CinciBani = 5,
            ZeceBani = 10,
            CincizeciBani = 50,
            UnLeu = 100,
            CinciLei = 500,
            ZeceLei = 1000,
            CincizecDeiLei = 5000,
            OSutadeLei = 10000,
            DouaSuteDeLei = 20000,
            CinciSuteDeLei = 50000
        }
    }
}


using Nagarro.VendingMachine.PresentationLayer;
using System;

namespace Nagarro.VendingMachine.UseCases.Payment.PaymentAlgorithms.CashPayment
{
    public class CashPayment : IPaymenthAlgorithm
    {
        public string Name { get; set; }
        public CashPayment(string name)
        {
            Name = name;
        }

        public void Run(float price)
        {
            CashPaymentTerminal terminal = new CashPaymentTerminal();

            float? balance = 0;
            float? value;
            while (price > 0)
            {
                try
                {
                    value = terminal.AskForMoney();
                    balance += value;

                    if ((value.Value * 100).IsValidMonetary())
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
    }
}

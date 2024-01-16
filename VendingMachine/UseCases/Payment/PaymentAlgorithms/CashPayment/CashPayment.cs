
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
            var terminal = new CashPaymentTerminal();

            float? balance = 0;
            float? value;
            while (price > 0)
            {
                try
                {
                    value = terminal.AskForMoney();
                    balance += value;

                   
                        price -= value.Value;
                        if (price > 0)
                        {
                            Console.WriteLine($"Remainding price : {price} Ron");
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
                terminal.GiveBackChange(price);
            }
        }
    }
}

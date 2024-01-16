
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

        }
    }
}

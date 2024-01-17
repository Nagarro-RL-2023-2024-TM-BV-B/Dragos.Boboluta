using Nagarro.VendingMachine.UseCases.Payment.PaymentAlgorithms;
using Nagarro.VendingMachine.UseCases.Payment.PaymentAlgorithms.CardPayment;
using Nagarro.VendingMachine.UseCases.Payment.PaymentAlgorithms.CashPayment;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Nagarro.VendingMachine.UseCases.PaymentUse
{
    public class PaymentUseCase
    {
        private List<IPaymenthAlgorithm> paymentAlgorithms = new List<IPaymenthAlgorithm> { new CashPayment("cash"), new CardPayment("card") };
        public string Name { get; set; }
        public string Description { get; set; }
        public bool CanExecute { get; set; }
        public void Execute(float price)
        {
            if (CanExecute && Name != null)
            {
                try
                {
                    IPaymenthAlgorithm algorithm = paymentAlgorithms.First(x => x.Name.Equals(Name));
                    if (algorithm != null)
                    {
                        algorithm.Run(price);
                    }
                }
                catch (InvalidOperationException ex )
                {
                    Console.WriteLine("Error : bad algorithm for payment , payment can not be completed ;");
                }
            }
        }
    }
}

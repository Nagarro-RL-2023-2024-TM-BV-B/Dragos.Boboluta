﻿using Nagarro.VendingMachine.UseCases.Payment.PaymentAlgorithms;
using Nagarro.VendingMachine.UseCases.Payment.PaymentAlgorithms.CardPayment;
using Nagarro.VendingMachine.UseCases.Payment.PaymentAlgorithms.CashPayment;
using System.Collections.Generic;

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
           
        }
    }
}

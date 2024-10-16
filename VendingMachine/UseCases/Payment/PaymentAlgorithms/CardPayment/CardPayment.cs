﻿
using Nagarro.VendingMachine.PresentationLayer;
using System;

namespace Nagarro.VendingMachine.UseCases.Payment.PaymentAlgorithms.CardPayment
{
    public class CardPayment : IPaymenthAlgorithm
    {
        public string Name { get; set; }

        public CardPayment(string name)
        {
            Name = name;
        }

        public void Run(float price)
        {
            CardPaymentTerminal terminal = new CardPaymentTerminal();
            string response = terminal.AskForCardNumber();
            bool isValid = response.IsValidLuhn();
            if (!isValid)
            {
                throw new Exception("Bad card number");
                throw new CancelException();
            }
        }
    }
}

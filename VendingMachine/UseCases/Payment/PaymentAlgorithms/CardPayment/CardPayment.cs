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
            var terminal = new CardPaymentTerminal();
            string response = terminal.AskForCardNumber();
            bool isValid = response.IsValidCreditCardLuhn();
            if (!isValid)
            {
                throw new Exception("Bad card number");
                throw new CancelException();
            }
        }
    }
}

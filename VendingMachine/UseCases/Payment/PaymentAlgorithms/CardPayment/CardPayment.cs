
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
            bool isValid = IsValidLuhn(response) ;
            if (!isValid)
            {
                throw new Exception("Bad card number");
                throw new CancelException();
            }
        }
        private static bool IsValidLuhn(string cardNumber)
        {
            char[] charArray = cardNumber.ToCharArray();

            Array.Reverse(charArray);

            string reversedCardNumber = new string(charArray);

            int sum = 0;
            bool doubleDigit = false;

            foreach (char digit in reversedCardNumber)
            {
                if (char.IsDigit(digit))
                {
                    int digitValue = digit - '0';

                    if (doubleDigit)
                    {
                        digitValue *= 2;

                        if (digitValue > 9)
                        {
                            digitValue -= 9;
                        }
                    }
                    sum += digitValue;
                    doubleDigit = !doubleDigit;
                }
            }
            return sum % 10 == 0;
        }

    }

}

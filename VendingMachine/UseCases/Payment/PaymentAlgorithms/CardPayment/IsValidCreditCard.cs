using System;
namespace Nagarro.VendingMachine.UseCases.Payment.PaymentAlgorithms.CardPayment
{
    public static class IsValidCreditCard
    {
        public static bool IsValidLuhn(this string cardNumber)
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

using System;
namespace Nagarro.VendingMachine.UseCases.Payment.PaymentAlgorithms.CardPayment
{
    public static class IsValidCreditCard
    {
        public static bool IsValidLuhn(this string cardNumber)
        {
            char[] reversedCardNumber = ReverseString(cardNumber);

            int sum = CalculateLuhnSum(reversedCardNumber);

            return sum % 10 == 0;
        }

        private static char[] ReverseString(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return charArray;
        }

        private static int CalculateLuhnSum(char[] reversedCardNumber)
        {
            int sum = 0;
            bool doubleDigit = false;

            foreach (char digit in reversedCardNumber)
            {
                if (char.IsDigit(digit))
                {
                    int digitValue = digit - '0';
                    digitValue = ApplyLuhnAlgorithm(digitValue, doubleDigit);

                    sum += digitValue;
                    doubleDigit = !doubleDigit;
                }
            }

            return sum;
        }

        private static int ApplyLuhnAlgorithm(int digitValue, bool doubleDigit)
        {
            if (doubleDigit)
            {
                digitValue *= 2;

                if (digitValue > 9)
                {
                    digitValue -= 9;
                }
            }
            return digitValue;
        }

    }
}

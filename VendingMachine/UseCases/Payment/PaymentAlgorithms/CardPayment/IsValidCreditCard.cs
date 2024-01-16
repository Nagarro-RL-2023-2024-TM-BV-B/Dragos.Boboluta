using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.VendingMachine.UseCases.Payment.PaymentAlgorithms.CardPayment
{
    internal  static class IsValidCreditCard
    {
       public static  bool IsValidCreditCardLuhn(this string cardNumber)
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

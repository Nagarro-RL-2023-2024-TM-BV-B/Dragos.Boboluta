using System;
namespace Nagarro.VendingMachine.UseCases.Payment.PaymentAlgorithms.CashPayment
{
    public static class IsValidMonetaryValue
    {
        public static bool IsValidMonetary(this float price)
        {
            bool isValid = Enum.IsDefined(typeof(MonetaryValues), (int)price);
            return isValid ? true : false;
        }
    }
}

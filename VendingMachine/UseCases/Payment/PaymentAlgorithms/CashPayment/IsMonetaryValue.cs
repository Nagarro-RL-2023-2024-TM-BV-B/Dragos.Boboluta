using System;
namespace Nagarro.VendingMachine.UseCases.Payment.PaymentAlgorithms.CashPayment
{
    public static class IsMonetaryValue
    {
        public static bool IsMonetaryValueCheck(this float price)
        {
            bool isValid = Enum.IsDefined(typeof(MonetaryValues), (int)price);
            return isValid ? true : false;
        }
    }
}

using System;

namespace Nagarro.VendingMachine
{
    internal class InsufficientStockException : Exception
    {
        private const string MessageTemplate = "There is not enough quantity for product {0}.";

        public InsufficientStockException(string productName)
            : base(string.Format(MessageTemplate, productName))
        {
        }
    }
}
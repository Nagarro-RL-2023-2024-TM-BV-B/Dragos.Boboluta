using System;

namespace Nagarro.VendingMachine
{
    internal class CancelException : Exception
    {
        private const string MessageTemplate = "The operation was canceled by user.";

        public CancelException()
            : base(MessageTemplate)
        {
        }
    }
}
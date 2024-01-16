using System;

namespace Nagarro.VendingMachine
{
    internal class InvalidColumnException : Exception
    {
        private const string MessageTemplate = "There is no column with id {0}.";

        public InvalidColumnException(int columnId)
            : base(string.Format(MessageTemplate, columnId))
        {
        }
    }
}
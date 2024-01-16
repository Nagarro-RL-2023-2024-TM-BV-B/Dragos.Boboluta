using System;

namespace Nagarro.VendingMachine.PresentationLayer
{
    internal class CashPaymentTerminal : DisplayBase
    {
        public float? AskForMoney()
        {
            return 200;
        }
        public void GiveBackChange(float balance)
        {
           
        }
    }
}

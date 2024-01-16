using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.VendingMachine.PresentationLayer
{
    internal class CashPaymentTerminal : DisplayBase
    {
        public float? AskForMoney()
        {
            
            return 2000;
        }
        public void GiveBackChange(float balance)
        {
           
        }
    }
}

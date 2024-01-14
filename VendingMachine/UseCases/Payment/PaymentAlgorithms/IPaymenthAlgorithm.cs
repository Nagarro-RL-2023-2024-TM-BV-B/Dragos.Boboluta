using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.VendingMachine.UseCases.Payment.PaymentAlgorithms
{
    public interface IPaymenthAlgorithm
    {
        public string Name { get; set; }
        public void Run(float price);
    }
}

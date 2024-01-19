using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.VendingMachine.UseCases
{
    internal class AddProductUseCase : IUseCase
    {
        public string Name => "Add";

        public string Description => "Add new product use case";

        public bool CanExecute => true;

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}

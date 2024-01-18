using System.Collections.Generic;

namespace Nagarro.VendingMachine.DataAccess
{
    internal interface IProductRepository
    {
         List<Product> GetAll();
         Product GetByColumn(int columnId);

    }
}

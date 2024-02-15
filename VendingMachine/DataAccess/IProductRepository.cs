using System.Collections.Generic;
using Nagarro.VendingMachine.Models.ProductModel;

namespace Nagarro.VendingMachine.DataAccess
{
    internal interface IProductRepository
    {
         List<Product> GetAll();
         Product GetByColumn(int columnId);
         void DispenseProduct(Product product);
         void AddProduct(ProductDto product);
    }
}

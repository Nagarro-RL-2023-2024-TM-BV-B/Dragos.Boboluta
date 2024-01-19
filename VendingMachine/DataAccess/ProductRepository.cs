using System.Collections.Generic;

namespace Nagarro.VendingMachine.DataAccess
{
    internal class ProductRepository : IProductRepository
    {
        private static readonly ICollection<Product> Products = new List<Product>
        {
            new Product
            {
                Name = "Chocolate",
                Price = 9,
                Quantity = 20,
                ColumnId = 1
            },
            new Product
            {
                Name = "Chips",
                Price = 5,
                Quantity = 7,
                ColumnId = 2
            },
            new Product
            {
                Name = "Still Water",
                Price = 2,
                Quantity = 10,
                ColumnId = 3
            }


        };
        public ProductRepository() 
        
        { 
        
        
        
        }

        public void DispenseProduct(Product product)
        {
            product.Quantity--;
        }

        public List<Product> GetAll()
        {
            List<Product> list = new List<Product>();

            foreach (Product product in Products)
                list.Add(product);

            return list;
        }

        public Product GetByColumn(int columnId)
        {
            foreach (Product x in Products)
            {
                if (x.ColumnId == columnId)
                    return x;
            }

            return null;
        }

    }
}
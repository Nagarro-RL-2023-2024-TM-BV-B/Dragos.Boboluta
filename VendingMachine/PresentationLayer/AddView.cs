using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using Nagarro.VendingMachine.Models.ProductModel;

namespace Nagarro.VendingMachine.PresentationLayer
{
    internal class AddView : DisplayBase
    {
        public ProductDto RequestProduct()
        {
            try
            {
                string Name = RequestProductName();
                decimal Price = RequestProductPrice();
                int Quantity = RequestProductQuantity();

                ProductDto productDto = new ProductDto()
                {
                    Name = Name,
                    Price = Price,
                    Quantity = Quantity,
                };
                return productDto;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private string RequestProductName()
        {
            Console.WriteLine();
            Display("Enter a product name (Enter to cancel): ", ConsoleColor.Cyan);

            string productName = Console.ReadLine();
            Console.WriteLine();

            if (string.IsNullOrEmpty(productName))
                throw new CancelException();

            return productName;
        }
        private decimal RequestProductPrice()
        {
            Console.WriteLine();
            Display("Enter a product price (Enter to cancel): ", ConsoleColor.Cyan);

            string productPrice = Console.ReadLine();
            Console.WriteLine();

            if (string.IsNullOrEmpty(productPrice))
                throw new CancelException();

            return decimal.Parse(productPrice);
        }
        private int RequestProductQuantity()
        {
            Console.WriteLine();
            Display("Enter quantity of the product (Enter to cancel): ", ConsoleColor.Cyan);

            string productQuantity = Console.ReadLine();
            Console.WriteLine();

            if (string.IsNullOrEmpty(productQuantity))
                throw new CancelException();

            return int.Parse(productQuantity);
        }

    }
}

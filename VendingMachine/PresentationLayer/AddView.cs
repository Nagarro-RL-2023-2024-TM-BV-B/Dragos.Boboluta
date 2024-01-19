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
          string Name =   RequestProductName();
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
        private string RequestProductName()
        {
            return "milk";
        }
        private decimal RequestProductPrice()
        {
            return 30;
        }
        private  int  RequestProductQuantity()
        {
            return 10;
        }
        
    }
}

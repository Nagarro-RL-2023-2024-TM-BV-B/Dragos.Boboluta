using Nagarro.VendingMachine.Authentication;
using Nagarro.VendingMachine.DataAccess;
using Nagarro.VendingMachine.Models.ProductModel;
using Nagarro.VendingMachine.PresentationLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.VendingMachine.UseCases
{
    internal class AddProductUseCase : IUseCase
    {
        AddView addView;
        IProductRepository productRepository;
        AuthenticationService authenticationService;
        public string Name => "add";

        public string Description => "Add new product ";

        public bool CanExecute => authenticationService.IsUserAuthenticated;

        internal AddProductUseCase(AddView addView, IProductRepository productRepository, AuthenticationService authenticationService)
        {
            this.addView = addView ?? throw new ArgumentNullException(nameof(addView));
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        }
        public void Execute()
        {
            ProductDto product = addView.RequestProduct();
            if(product != null)
            {
                productRepository.AddProduct(product);
            }
        }
    }
}

using System;
using Nagarro.VendingMachine.Authentication;
using Nagarro.VendingMachine.DataAccess;
using Nagarro.VendingMachine.PresentationLayer;

namespace Nagarro.VendingMachine.UseCases
{
    internal class BuyUseCase : IUseCase
    {
        private readonly AuthenticationService authenticationService;
        private readonly BuyView buyView;
        private readonly ProductRepository productRepository;

        public string Name => "buy";

        public string Description => "Activate the numeric keyboard to buy a product.";

        public bool CanExecute => !authenticationService.IsUserAuthenticated;

        public BuyUseCase(AuthenticationService authenticationService, BuyView buyView, ProductRepository productRepository)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public void Execute()
        {
            int columnId = buyView.RequestProduct();

            Product product = productRepository.GetByColumn(columnId);

            if (product == null)
                throw new InvalidColumnException(columnId);

            if (product.Quantity < 1)
                throw new InsufficientStockException(product.Name);

            // todo: do the payment
            // For now, we consider the payment successful.

            product.Quantity--;

            buyView.DispenseProduct(product.Name);
        }
    }
}
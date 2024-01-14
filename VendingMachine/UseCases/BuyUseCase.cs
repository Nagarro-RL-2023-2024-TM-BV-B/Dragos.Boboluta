using System;
using System.Collections.Generic;
using System.Linq;
using Nagarro.VendingMachine.Authentication;
using Nagarro.VendingMachine.DataAccess;
using Nagarro.VendingMachine.PresentationLayer;
using Nagarro.VendingMachine.UseCases.Payment;
using Nagarro.VendingMachine.UseCases.PaymentUse;

namespace Nagarro.VendingMachine.UseCases
{
    internal class BuyUseCase : IUseCase
    {
        private readonly AuthenticationService authenticationService;
        private readonly BuyView buyView;
        private readonly ProductRepository productRepository;
        private readonly PaymentUseCase paymentUseCase = new PaymentUseCase();
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
            int? paymentId;

            PaymentMethod paymentWithCard = new PaymentMethod { Id = 1, Name = "card" };
            PaymentMethod paymentWithCash = new PaymentMethod { Id = 2, Name = "cash" };

            List<PaymentMethod> paymentMethods = new List<PaymentMethod> { paymentWithCard, paymentWithCash };

            Product product = productRepository.GetByColumn(columnId);

            if (product == null)
                throw new InvalidColumnException(columnId);

            if (product.Quantity < 1)
                throw new InsufficientStockException(product.Name);

            paymentId = buyView.AskForPaymentMethod(paymentMethods);

            string paymentName = paymentMethods.Where(x => x.Id == paymentId).Select(x => x.Name).FirstOrDefault();

            paymentUseCase.Name = paymentName;

            paymentUseCase.CanExecute = true;

            paymentUseCase.Execute((float)product.Price);

            product.Quantity--;

            buyView.DispenseProduct(product.Name);
        }
    }
}
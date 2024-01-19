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
        private readonly IProductRepository productRepository;
        private readonly PaymentUseCase paymentUseCase;

        public string Name => "buy";

        public string Description => "Activate the numeric keyboard to buy a product.";

        public bool CanExecute => !authenticationService.IsUserAuthenticated;

        public BuyUseCase(AuthenticationService authenticationService, BuyView buyView, IProductRepository productRepository, PaymentUseCase paymentUseCase)

        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this.paymentUseCase = paymentUseCase ?? throw new ArgumentNullException(nameof(paymentUseCase));   
        }

        public void Execute()
        {
            int columnId = buyView.RequestProduct();

            Product product = productRepository.GetByColumn(columnId);
            int? paymentId;

            PaymentMethod paymentWithCard = new PaymentMethod { Id = 1, Name = "card" };
            PaymentMethod paymentWithCash = new PaymentMethod { Id = 2, Name = "cash" };

            List<PaymentMethod> paymentMethods = new List<PaymentMethod> { paymentWithCard, paymentWithCash };
            if (product == null)
                throw new InvalidColumnException(columnId);

            if (product.Quantity < 1)
                throw new InsufficientStockException(product.Name);
            paymentId = buyView.AskForPaymentMethod(paymentMethods);

            string paymentName = paymentMethods.Where(x => x.Id == paymentId).Select(x => x.Name).FirstOrDefault();
            paymentUseCase.Name = paymentName;

            paymentUseCase.CanExecute = true;

            paymentUseCase.Execute((float)product.Price);

            productRepository.DispenseProduct(product);

            buyView.DispenseProduct(product.Name);
        }
    }
}
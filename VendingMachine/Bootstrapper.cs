using System.Collections.Generic;
using Nagarro.VendingMachine.Authentication;
using Nagarro.VendingMachine.DataAccess;
using Nagarro.VendingMachine.PresentationLayer;
using Nagarro.VendingMachine.UseCases;
using Nagarro.VendingMachine.UseCases.PaymentUse;

namespace Nagarro.VendingMachine
{
    internal class Bootstrapper
    {
        public void Run()
        {
            VendingMachineApplication vendingMachineApplication = BuildApplication();
            vendingMachineApplication.Run();
        }

        private static VendingMachineApplication BuildApplication()
        {
            // --------------------------------------------------------------------------------
            // Configure presentation
            // --------------------------------------------------------------------------------

            MainView mainView = new MainView();
            LoginView loginView = new LoginView();
            BuyView buyView = new BuyView();
            ShelfView shelfView = new ShelfView();

            // --------------------------------------------------------------------------------
            // Configure data access
            // --------------------------------------------------------------------------------

            ProductRepository productRepository = new ProductRepository();

            // --------------------------------------------------------------------------------
            // Configure use cases
            // --------------------------------------------------------------------------------

            AuthenticationService authenticationService = new AuthenticationService();
            PaymentUseCase paymentUseCase = new PaymentUseCase();
            List<IUseCase> useCases = new List<IUseCase>
            {
                new LookUseCase(productRepository, shelfView),
                new BuyUseCase(authenticationService, buyView, productRepository,paymentUseCase),
                new LoginUseCase(authenticationService, loginView),
                new LogoutUseCase(authenticationService),
            };

            return new VendingMachineApplication(useCases, mainView);
        }
    }
}
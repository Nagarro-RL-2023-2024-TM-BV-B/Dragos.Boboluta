﻿using System.Collections.Generic;
using Nagarro.VendingMachine.Authentication;
using Nagarro.VendingMachine.DataAccess;
using Nagarro.VendingMachine.DataAccess.SQLiteRepository;
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

            IProductRepository productRepository = new SQLiteProductRepository("Data Source=C:\\Users\\drago\\source\\repos\\SQLiteDB\\vendingdb.db;Version=3;");

            // --------------------------------------------------------------------------------
            // Configure use cases
            // --------------------------------------------------------------------------------

            AuthenticationService authenticationService = new AuthenticationService();
            PaymentUseCase paymentUseCase = new PaymentUseCase();
            AddView addView = new AddView();
            List<IUseCase> useCases = new List<IUseCase>
            {
                new AddProductUseCase(addView,productRepository,authenticationService),
                new LookUseCase(productRepository, shelfView),
                new BuyUseCase(authenticationService, buyView, productRepository,paymentUseCase),
                new LoginUseCase(authenticationService, loginView),
                new LogoutUseCase(authenticationService),
            };

            return new VendingMachineApplication(useCases, mainView);
        }
    }
}
using System;
using System.Collections.Generic;
using Nagarro.VendingMachine.DataAccess;
using Nagarro.VendingMachine.PresentationLayer;

namespace Nagarro.VendingMachine.UseCases
{
    internal class LookUseCase : IUseCase
    {
        private readonly ProductRepository productRepository;
        private readonly ShelfView shelfView;

        public string Name => "look";

        public string Description => "View available products.";

        public bool CanExecute => true;

        public LookUseCase(ProductRepository productRepository, ShelfView shelfView)
        {
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this.shelfView = shelfView ?? throw new ArgumentNullException(nameof(shelfView));
        }

        public void Execute()
        {
            List<Product> allProducts = productRepository.GetAll();

            List<Product> productsToDisplay = new List<Product>();

            foreach (Product product in allProducts)
            {
                if (product.Quantity > 0)
                    productsToDisplay.Add(product);
            }

            shelfView.DisplayProducts(productsToDisplay);
        }
    }
}
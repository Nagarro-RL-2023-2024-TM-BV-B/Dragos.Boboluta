﻿namespace Nagarro.VendingMachine.Models.ProductModel
{
    internal class Product
    {
        public int ColumnId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
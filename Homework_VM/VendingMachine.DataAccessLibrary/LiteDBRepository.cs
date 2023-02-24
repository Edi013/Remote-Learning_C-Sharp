﻿using System.Configuration;
using iQuest.VendingMachine.Business;
using LiteDB;

namespace iQuest.VendingMachine.DataAcces
{
    public class LiteDBRepository : IProductRepository
    {
        private string _connectionString;
        public LiteDBRepository(string connectionString)
        {
            _connectionString = connectionString;

           /* var products = new List<Product>() {
                new Product(1, "7Days", 4.99F, 10),
                new Product(2, "Rolls", 3.99F, 7),
                new Product(3, "Napoleon", 2.99F, 1),
                new Product(4, "Ice coffee", 9.99F, 12)
            };

            using (var database = new LiteDatabase(
                        _connectionString))
            {
                var collection = database.GetCollection<Product>("Products");
                collection.InsertBulk(products);
            }*/
        }

        public void DecreaseQuantity(Product product)
        {
            product.Quantity--;

            using (var database = new LiteDatabase(
                        Directory.GetCurrentDirectory()))
            {
                var collection = database.GetCollection<Product>("Products");
                collection.Update(product);
            }
        }

        public Product? GetProductByColumnId(int columnId)
        {
            Product toFind = null;

            using (var database = new LiteDatabase(
                        _connectionString))
            {
                var collection = database.GetCollection<Product>("Products");
                toFind = collection.FindById(columnId);
            }

            return toFind;
        }

        public List<Product> GetProducts()
        {
            var products = new List<Product>();

            using (var database = new LiteDatabase(
                        _connectionString))
            {
                var collection = database.GetCollection<Product>("Products");
                products = collection.FindAll().ToList();
            }

            return products;
        }
    }
}

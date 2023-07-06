﻿using iQuest.VendingMachine.Business;

namespace iQuest.VendingMachine.DataAccess
{
    public class EfUnitOfWork : IProductAndSalesUnitOfWork
    {
        private EfDbContext _context;
        public IProductRepository ProductRepository { get; }
        public ISaleRepository SaleRepository { get; }

        public EfUnitOfWork(IProductRepository productRepository, ISaleRepository saleRepository, EfDbContext context)
        {
            ProductRepository = productRepository;
            SaleRepository = saleRepository;
            _context = context;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

using iQuest.VendingMachine.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iQuest.VendingMachine.DataLayer
{
    internal interface IProductRepository
    {
        private static List<Product> products;
        public List<Product> GetAll();
        public Product? GetProductByColumnId(int columnId);

    }
}

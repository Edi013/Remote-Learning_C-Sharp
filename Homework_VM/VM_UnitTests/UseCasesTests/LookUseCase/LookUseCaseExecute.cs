using iQuest.VendingMachine.DataLayer;
using iQuest.VendingMachine.PresentationLayer;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iQuest.VendingMachine.UseCases;
using Xunit.Abstractions;

namespace VM_UnitTests.UseCasesTests
{
    public class LookUseCaseExecuteTests
    {
        private readonly Mock<IProductRepository> productRepository;
        private readonly ShelfView shelfView;

        private string expectedMessage = "A list of all products will be displayed as:\n" + "Product number, name, price, quantity ";


        public LookUseCaseExecuteTests()
        {
            productRepository = new Mock<IProductRepository>();
            shelfView = new ShelfView();
        }

        [Fact]
        public void HavingProductsInRepository_ThanOutputsProducts()
        {
          
        }

        [Fact]
        public void HavingNoProductsInRepository_ThanCanExecuteIsFalse()
        {
          
        }
    }
}

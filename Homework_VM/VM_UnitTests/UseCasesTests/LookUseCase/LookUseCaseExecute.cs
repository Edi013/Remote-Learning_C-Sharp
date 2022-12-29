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
    public class LookUseCaseExecute
    {
        private readonly Mock<IProductRepository> productRepository;
        private readonly Mock<IShelfView> shelfView;

        private readonly ITestOutputHelper output;
        private string expectedMessage = "A list of all products will be displayed as:\n" + "Product number, name, price, quantity ";


        public LookUseCaseExecute(ITestOutputHelper output)
        {
            productRepository = new Mock<IProductRepository>();
            shelfView = new Mock<IShelfView>();

            this.output = output;
        }

        [Fact]
        public void HavingProductsInRepository_ThanOutputsProducts()
        {
            List<Product> products = new List<Product>()
            {
                new Product(1, "testProduct", 3.33f, 3)
            };

            productRepository
                .Setup(x => x.GetAll())
                .Returns(products);

            LookUseCase lookUseCase = new LookUseCase(productRepository.Object, shelfView.Object);

            Assert.Equal(1, 2);
        }

        [Fact]
        public void HavingNoProductsInRepository_ThanCanExecuteIsFalse()
        {
            List<Product> products = new List<Product>()
            {
            };

            productRepository
                .Setup(x => x.GetAll())
                .Returns(products);

            LookUseCase lookUseCase = new LookUseCase(productRepository.Object, shelfView.Object);

            Assert.Equal(1, 2);
        }
    }
}

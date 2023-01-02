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
           /* List<Product> products = new List<Product>()
            {
                new Product(1, "testProduct", 3.33f, 3)
            };

            productRepository
                .Setup(x => x.GetAll())
                .Returns(products);

            LookUseCase lookUseCase = new LookUseCase(productRepository.Object, shelfView);


            string expectedMsg = expectedMessage + products[0].ToString();
            var reader = new StreamReader(expectedMsg);
            var textWriter = new TextWriter();

            string line;
            StringBuilder storage = new StringBuilder();
            while ((line = Console.ReadLine()) != null)
            {
                storage.Append(line);
            }
            lookUseCase.Execute();

            Assert.Equal(1, 2);
           */
        }

        [Fact]
        public void HavingNoProductsInRepository_ThanCanExecuteIsFalse()
        {
          /*  List<Product> products = new List<Product>()
            {
            };

            productRepository
                .Setup(x => x.GetAll())
                .Returns(products);

            LookUseCase lookUseCase = new LookUseCase(productRepository.Object, shelfView.Object);

            Assert.Equal(1, 2);
          */
        }
    }
}

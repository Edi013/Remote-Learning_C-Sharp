using iQuest.VendingMachine.Business;
using iQuest.VendingMachine.Presentation;
using Moq;

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

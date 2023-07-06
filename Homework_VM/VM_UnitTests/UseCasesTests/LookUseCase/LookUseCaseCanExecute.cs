/*using iQuest.VendingMachine.Business;
using Moq;

namespace VM_UnitTests.UseCasesTests
{
    public class LookUseCaseCanExecute
    {
        private readonly Mock<IProductRepository> productRepository;
        private readonly Mock<IShelfView> shelfView;

        public LookUseCaseCanExecute()
        {
            productRepository = new Mock<IProductRepository>();
            shelfView = new Mock<IShelfView>();
        }

        [Fact]
        public void HavingProductsInRepository_ThanCanExecuteIsTrue()
        {
            List<Product> products = new List<Product>()
            {
                new Product(1, "testProduct", 3.33f, 3)
            };

            productRepository
                .Setup(x => x.GetProducts())
                .Returns(products);

            LookUseCase lookUseCase = new LookUseCase(productRepository.Object, shelfView.Object);

            Assert.True(lookUseCase.CanExecute);
        }

        [Fact]
        public void HavingNoProductsInRepository_ThanCanExecuteIsFalse()
        {
            List<Product> products = new List<Product>()
            {
            };

            productRepository
                .Setup(x => x.GetProducts())
                .Returns(products);

            LookUseCase lookUseCase = new LookUseCase(productRepository.Object, shelfView.Object);

            Assert.False(lookUseCase.CanExecute);
        }
    }
}
*/

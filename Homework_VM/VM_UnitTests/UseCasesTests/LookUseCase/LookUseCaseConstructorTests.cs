/*using iQuest.VendingMachine.Business;
using iQuest.VendingMachine.DataAcces;
using iQuest.VendingMachine.Presentation;

namespace VM_UnitTests.UseCasesTests
{
    
    public class LookUseCaseConstructorTests
    {
        private  IProductRepository productRepository;
        private  IShelfView shelfView;

        [Fact]
        public void HavingAllArgumentsInOrder_ThanNameAndDescriptionAreInOrder()
        {
            string nameText = "See products";
            string descriptionText = "This is our stock.";

            productRepository = new InMemoryRepository();
            shelfView = new ShelfView();

            LookUseCase lookUseCase = new LookUseCase(productRepository, shelfView);
            Assert.Equal(nameText, lookUseCase.Name);
            Assert.Equal(descriptionText, lookUseCase.Description);
        }

        [Fact]
        public void Having3Arguments_WithEitherNull_ThrowsException()
        {
            productRepository = null;
            Assert.Throws<ArgumentNullException>(() => new LookUseCase(productRepository, shelfView));
            productRepository = new InMemoryRepository();

            shelfView = null;
            Assert.Throws<ArgumentNullException>(() => new LookUseCase(productRepository, shelfView));
        }
    }
}
*/

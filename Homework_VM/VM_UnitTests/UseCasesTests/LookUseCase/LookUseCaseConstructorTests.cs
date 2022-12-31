using iQuest.VendingMachine.DataLayer;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM_UnitTests.UseCasesTests
{
    
    public class LookUseCaseConstructorTests
    {
        private  IProductRepository productRepository;
        private  IShelfView shelfView;

       /* public LookUseCaseConstructorTests()
        {
            productRepository = new ProductRepository();
            view = new ShelfView();
        }*/

        [Fact]
        public void Having3Arguments_WithEitherNull_ThrowsException()
        {
            productRepository = null;
            Assert.Throws<ArgumentNullException>(() => new LookUseCase(productRepository, shelfView));
            productRepository = new ProductRepository();

            shelfView = null;
            Assert.Throws<ArgumentNullException>(() => new LookUseCase(productRepository, shelfView));
            shelfView = new ShelfView();
        }
    }
}

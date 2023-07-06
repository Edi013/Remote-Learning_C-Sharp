using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iQuest.VendingMachine.Business;
using iQuest.VendingMachine.Presentation;
using Moq;

namespace VM_UnitTests.UseCasesTests.Commands
{
    public class BuyCommandDescription
    {
        private IProductAndSalesUnitOfWork unitOfWork;
        private IAuthenticationService authenticationService;
        private IBuyView buyView;

        [Fact]
        public void HavingAllArgumentsInOrder_ThanNameAndDescriptionAreInOrder()
        {
            string nameText = "Buy";
            string descriptionText = "You will buy something.";

            Mock<IUseCaseFactory> useCaseFactory = new Mock<IUseCaseFactory>();
            Mock<IProductRepository> productRepo = new Mock<IProductRepository>();
            Mock<IAuthenticationService> authenticationService = new Mock<IAuthenticationService>();

            BuyCommand buyCommand = new BuyCommand(useCaseFactory.Object, productRepo.Object, authenticationService.Object);
            Assert.Equal(nameText, buyCommand.Name);
            Assert.Equal(descriptionText, buyCommand.Description);
        }
    }
}

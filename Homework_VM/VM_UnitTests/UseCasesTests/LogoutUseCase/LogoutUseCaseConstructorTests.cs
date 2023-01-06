using iQuest.VendingMachine.Services;
using iQuest.VendingMachine.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM_UnitTests.UseCasesTests
{
    public class LogoutUseCaseConstructorTests
    {
        private IAuthenticationService authenticationService;

        [Fact]
        public void HavingAllArgumentsInOrder_ThanNameAndDescriptionAreInOrder()
        {
            string nameText = "logout";
            string descriptionText = "Restrict access to administration buttons.";

            authenticationService = new AuthenticationService();

            LogoutUseCase logoutUseCase = new LogoutUseCase(authenticationService);
            Assert.Equal(nameText, logoutUseCase.Name);
            Assert.Equal(descriptionText, logoutUseCase.Description);
        }

        [Fact]
        public void HavingOneArgumentNull_ThrowsException()
        {
            authenticationService = null;
            Assert.Throws<ArgumentNullException>(() => new LogoutUseCase(authenticationService));
        }
    }
}

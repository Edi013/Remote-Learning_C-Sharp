using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.Services;
using iQuest.VendingMachine.UseCases;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM_UnitTests.UseCasesTests
{
    public class LoginUseCaseCanExecuteTests
    {
        private readonly Mock<IMainDisplay> mainDisplay;
        private readonly Mock<IAuthenticationService> authenticationService;

        public LoginUseCaseCanExecuteTests()
        {
            mainDisplay = new Mock<IMainDisplay>();
            authenticationService = new Mock<IAuthenticationService>();
        }

        [Fact]
        public void HavingAdminLoggedIn_CanExecuteIsFalse()
        {
            authenticationService
                .Setup(x => x.IsUserAuthenticated)
                .Returns(true);

            LoginUseCase loginUseCase = new LoginUseCase(mainDisplay.Object, authenticationService.Object);

            Assert.False(loginUseCase.CanExecute);
        }

        [Fact]
        public void HavingNoAdminLoggedIn_CanExecuteIsTrue()
        {
            authenticationService
                .Setup(x => x.IsUserAuthenticated)
                .Returns(false);

            LoginUseCase loginUseCase = new LoginUseCase(mainDisplay.Object, authenticationService.Object);

            Assert.True(loginUseCase.CanExecute);
        }


    }
}

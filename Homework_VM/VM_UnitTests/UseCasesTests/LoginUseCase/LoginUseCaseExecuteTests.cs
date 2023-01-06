using iQuest.VendingMachine.Exceptions;
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
    public class LoginUseCaseExecuteTests
    {
        private readonly Mock<IMainDisplay> mainDisplay;
        private readonly IAuthenticationService authenticationService;

        private string correctPassword = "supercalifragilisticexpialidocious";
        private string incorrectPassword = "Just a string, not the right password";

        public LoginUseCaseExecuteTests()
        {
            mainDisplay = new Mock<IMainDisplay>();
            authenticationService = new AuthenticationService();
        }

        [Fact]
        public void HavingNoAdminLoggedInAndCorrectPassword_ThanLogIn()
        {
            authenticationService.Logout();

            mainDisplay
                .Setup(x => x.AskForPassword())
                .Returns(correctPassword);

            LoginUseCase loginUseCase = new LoginUseCase(mainDisplay.Object, authenticationService);
        
            loginUseCase.Execute();

            Assert.True(authenticationService.IsUserAuthenticated);
        
        }

        [Fact]
        public void HavingNoAdminLoggedInAndIncorrectPassword_ThanDoesNotLogIn()
        {
            mainDisplay
                .Setup(x => x.AskForPassword())
                .Returns(incorrectPassword);

            LoginUseCase loginUseCase = new LoginUseCase(mainDisplay.Object, authenticationService);

            Assert.Throws<InvalidPasswordException>(() => loginUseCase.Execute());
        }
    }
}

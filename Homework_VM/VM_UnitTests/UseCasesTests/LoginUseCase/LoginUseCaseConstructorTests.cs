using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iQuest.VendingMachine.UseCases;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.Services;
using Moq;

namespace VM_UnitTests.UseCasesTests
{
    public class LoginUseCaseConstructorTests
    {
        private IMainDisplay mainDisplay;
        private IAuthenticationService  authenticationService;

       /* public LoginUseCaseConstructorTests()
        {
             mainDisplay = new MainDisplay();
             authenticationService = new AuthenticationService();
        }*/

        [Fact]
        public void HavingOneArgumentNull_ThrowsException()
        {
            mainDisplay = null;
            Assert.Throws<ArgumentNullException>(() => new LoginUseCase(mainDisplay, authenticationService));
            mainDisplay = new MainDisplay();

            authenticationService = null;
            Assert.Throws<ArgumentNullException>(() => new LoginUseCase(mainDisplay, authenticationService));
            authenticationService = new AuthenticationService();
        }

    }
}

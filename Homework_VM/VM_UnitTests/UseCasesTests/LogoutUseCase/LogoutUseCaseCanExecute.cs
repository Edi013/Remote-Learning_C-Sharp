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
    public class LogoutUseCaseCanExecute
    {
        private IAuthenticationService authenticationService;

        public LogoutUseCaseCanExecute()
        {
            authenticationService = new AuthenticationService();
        }

        [Fact]
        public void HavingAdminLoggedIn_ThenCanExecuteIsTrue()
        {
            authenticationService.IsUserAuthenticated = true;

            LogoutUseCase logoutUseCase = new LogoutUseCase(authenticationService);

           Assert.True(logoutUseCase.CanExecute);
        }

        [Fact]
        public void HavingNoAdminLoggedIn_ThenCanExecuteIsFalse()
        {
            authenticationService.IsUserAuthenticated = false;

            LogoutUseCase logoutUseCase = new LogoutUseCase(authenticationService);

            Assert.False(logoutUseCase.CanExecute);
        }
    }
}

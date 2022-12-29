using iQuest.VendingMachine.Services;
using iQuest.VendingMachine.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM_UnitTests.UseCasesTests
{
    public class LogoutUseCaseExecute
    {
        private IAuthenticationService authenticationService;

        public LogoutUseCaseExecute()
        {
            authenticationService = new AuthenticationService();
        }

        [Fact]
        public void HavingAdminLoggedIn_ThenLogOut()
        {
            authenticationService.IsUserAuthenticated = true;

            LogoutUseCase logoutUseCase = new LogoutUseCase(authenticationService);

            logoutUseCase.Execute();

            Assert.False(authenticationService.IsUserAuthenticated);
        }
    }
}

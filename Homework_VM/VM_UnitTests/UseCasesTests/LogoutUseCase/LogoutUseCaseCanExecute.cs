using iQuest.VendingMachine.Business;

namespace VM_UnitTests.UseCasesTests
{
    public class LogoutUseCaseCanExecute
    {
        private IAuthenticationService authenticationService;
        private string correctPassword = "supercalifragilisticexpialidocious";

        public LogoutUseCaseCanExecute()
        {
            authenticationService = new AuthenticationService();
        }

        [Fact]
        public void HavingAdminLoggedIn_ThenCanExecuteIsTrue()
        {
            authenticationService.Login(correctPassword);

            LogoutUseCase logoutUseCase = new LogoutUseCase(authenticationService);

           Assert.True(logoutUseCase.CanExecute);
        }

        [Fact]
        public void HavingNoAdminLoggedIn_ThenCanExecuteIsFalse()
        {
            authenticationService.Logout();

            LogoutUseCase logoutUseCase = new LogoutUseCase(authenticationService);

            Assert.False(logoutUseCase.CanExecute);
        }
    }
}

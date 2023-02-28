using iQuest.VendingMachine.Business;

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
            authenticationService.Login("supercalifragilisticexpialidocious");

            LogoutUseCase logoutUseCase = new LogoutUseCase(authenticationService);

            logoutUseCase.Execute();

            Assert.False(authenticationService.IsUserAuthenticated);
        }
    }
}

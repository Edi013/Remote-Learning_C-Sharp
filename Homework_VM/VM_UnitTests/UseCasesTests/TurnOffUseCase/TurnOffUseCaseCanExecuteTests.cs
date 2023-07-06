using iQuest.VendingMachine.Business;
using Moq;

namespace VM_UnitTests.UseCasesTests
{
    public class TurnOffUseCaseCanExecuteTests
    {
        private readonly AuthenticationService authenticationService;
        private readonly Mock<ITurnOffService> turnOffService;

        public TurnOffUseCaseCanExecuteTests()
        {
            authenticationService = new AuthenticationService();
            turnOffService = new Mock<ITurnOffService>();
        }

        [Fact]
        public void HavingAdminLoggedIn_ThanCanExecute()
        {
            authenticationService.Login("edi");

            TurnOffUseCase turnOffUseCase = new TurnOffUseCase(turnOffService.Object, authenticationService);

            Assert.True(turnOffUseCase.CanExecute);
        }

        [Fact]
        public void HavingNoAdminLoggedIn_ThanCanNotExecute()
        {
            authenticationService.Logout();

            TurnOffUseCase turnOffUseCase = new TurnOffUseCase(turnOffService.Object, authenticationService);

            Assert.False(turnOffUseCase.CanExecute);
        }
    }
}

using iQuest.VendingMachine.Business;
using Moq;

namespace VM_UnitTests.UseCasesTests
{
    public class TurnOffUseCaseExecuteTests
    {
        private readonly Mock<IAuthenticationService> authenticationService;
        private readonly ITurnOffService turnOffService;


        public TurnOffUseCaseExecuteTests()
        {
            authenticationService = new Mock<IAuthenticationService>();
            turnOffService = new TurnOffService();
        }

        [Fact]
        public void HavingAdminLoggedIn_ThanTurnOff()
        {
            authenticationService
                .Setup(x => x.IsUserAuthenticated)
                .Returns(true);

            TurnOffUseCase turnOffUseCase = new TurnOffUseCase(turnOffService, authenticationService.Object);

            turnOffUseCase.Execute();

            Assert.True(turnOffService.Status);
        }
    }
}

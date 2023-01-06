using iQuest.VendingMachine.Classes;
using iQuest.VendingMachine.Interfaces;
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
    public class TurnOffUseCaseExecuteTests
    {
        private readonly Mock<IAuthenticationService> authenticationService;
        private readonly ITurnOffWasRequestedChecker turnOffWasRequestedChecker;


        public TurnOffUseCaseExecuteTests()
        {
            authenticationService = new Mock<IAuthenticationService>();
            turnOffWasRequestedChecker = new TurnOffService();
        }

        [Fact]
        public void HavingAdminLoggedIn_ThanTurnOff()
        {
            authenticationService
                .Setup(x => x.IsUserAuthenticated)
                .Returns(true);

            TurnOffUseCase turnOffUseCase = new TurnOffUseCase(turnOffWasRequestedChecker, authenticationService.Object);

            turnOffUseCase.Execute();

            Assert.True(turnOffWasRequestedChecker.Status);
        }
    }
}

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
    public class TurnOffUseCaseCanExecuteTests
    {
        private readonly AuthenticationService authenticationService;
        private readonly Mock<ITurnOffWasRequestedChecker> turnOffWasRequestedChecker;

        public TurnOffUseCaseCanExecuteTests()
        {
            authenticationService = new AuthenticationService();
            turnOffWasRequestedChecker = new Mock<ITurnOffWasRequestedChecker>();
        }

        [Fact]
        public void HavingAdminLoggedIn_ThanCanExecute()
        {
            authenticationService.IsUserAuthenticated = true;

            TurnOffUseCase turnOffUseCase = new TurnOffUseCase(turnOffWasRequestedChecker.Object, authenticationService);

            Assert.True(turnOffUseCase.CanExecute);
        }

        [Fact]
        public void HavingNoAdminLoggedIn_ThanCanNotExecute()
        {
            authenticationService.IsUserAuthenticated = false;

            TurnOffUseCase turnOffUseCase = new TurnOffUseCase(turnOffWasRequestedChecker.Object, authenticationService);

            Assert.False(turnOffUseCase.CanExecute);
        }
    }
}

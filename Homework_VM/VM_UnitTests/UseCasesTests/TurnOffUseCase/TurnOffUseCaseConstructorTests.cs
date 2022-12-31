using iQuest.VendingMachine.Classes;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.Services;
using iQuest.VendingMachine.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM_UnitTests.UseCasesTests
{
    public class TurnOffUseCaseConstructorTests
    {
        private IAuthenticationService authenticationService;
        private ITurnOffWasRequestedChecker turnOffWasRequestedChecker;

        public TurnOffUseCaseConstructorTests()
        {
            turnOffWasRequestedChecker = new TurnOffWasRequestedChecker();
            authenticationService = new AuthenticationService();
        }

        [Fact]
        public void Having3Arguments_WithEitherNull_ThrowsException()
        {
            turnOffWasRequestedChecker = null;
            Assert.Throws<ArgumentNullException>(() => new TurnOffUseCase(turnOffWasRequestedChecker, authenticationService));
            turnOffWasRequestedChecker = new TurnOffWasRequestedChecker();

            authenticationService = null;
            Assert.Throws<ArgumentNullException>(() => new TurnOffUseCase(turnOffWasRequestedChecker, authenticationService));
            authenticationService = new AuthenticationService();
        }

    }
}

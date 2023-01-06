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
        private ITurnOffService turnOffService;

        public TurnOffUseCaseConstructorTests()
        {
            turnOffService = new TurnOffService();
            authenticationService = new AuthenticationService();
        }

        [Fact]
        public void Having3Arguments_WithEitherNull_ThrowsException()
        {
            turnOffService = null;
            Assert.Throws<ArgumentNullException>(() => new TurnOffUseCase(turnOffService, authenticationService));
            turnOffService = new TurnOffService();

            authenticationService = null;
            Assert.Throws<ArgumentNullException>(() => new TurnOffUseCase(turnOffService, authenticationService));
        }
    }
}

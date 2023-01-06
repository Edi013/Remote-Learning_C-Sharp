using iQuest.VendingMachine.Services;
using iQuest.VendingMachine.UseCases;

namespace VM_UnitTests.UseCasesTests
{
    public class TurnOffUseCaseConstructorTests
    {
        private ITurnOffService turnOffService;
        private IAuthenticationService authenticationService;

        [Fact]
        public void HavingAllArgumentsInOrder_ThanNameAndDescriptionAreInOrder()
        {
            string nameText = "exit";
            string descriptionText = "Go to live your life.";

            turnOffService = new TurnOffService();
            authenticationService = new AuthenticationService();

            TurnOffUseCase turnOffUseCase = new TurnOffUseCase(turnOffService, authenticationService);
            Assert.Equal(nameText, turnOffUseCase.Name);
            Assert.Equal(descriptionText, turnOffUseCase.Description);
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

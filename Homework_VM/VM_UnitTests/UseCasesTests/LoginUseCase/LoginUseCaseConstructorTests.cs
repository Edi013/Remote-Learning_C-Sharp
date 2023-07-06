/*using iQuest.VendingMachine.Business;
using iQuest.VendingMachine.Presentation;

namespace VM_UnitTests.UseCasesTests
{
    public class LoginUseCaseConstructorTests
    {
        private IMainDisplay mainDisplay;
        private IAuthenticationService  authenticationService;

        [Fact]
        public void HavingAllArgumentsInOrder_ThanNameAndDescriptionAreInOrder()
        {
            string nameText = "login";
            string descriptionText = "Get access to administration buttons.";

            mainDisplay = new MainDisplay();
            authenticationService = new AuthenticationService();

            LoginUseCase loginUseCase = new LoginUseCase(mainDisplay, authenticationService);
            Assert.Equal(nameText, loginUseCase.Name);
            Assert.Equal(descriptionText, loginUseCase.Description);
        }

        [Fact]
        public void HavingOneArgumentNull_ThrowsException()
        {
            mainDisplay = null;
            Assert.Throws<ArgumentNullException>(() => new LoginUseCase(mainDisplay, authenticationService));
            mainDisplay = new MainDisplay();

            authenticationService = null;
            Assert.Throws<ArgumentNullException>(() => new LoginUseCase(mainDisplay, authenticationService));
        }
    }
}
*/

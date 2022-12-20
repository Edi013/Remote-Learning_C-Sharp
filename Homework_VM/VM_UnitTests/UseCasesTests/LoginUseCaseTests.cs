
using Moq;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.UseCases;
using iQuest.VendingMachine;
using iQuest.VendingMachine.Exceptions;


namespace VM_UnitTests.UseCases
{
    public class LoginUseCaseTests
    {
        [Fact]
        public void HavingLoginUseCase_WhenCorrectPassword_ThanLoginSuccesful()
        {
            //Arange
/*
            var mockLogin = new Mock<ILoginChecker>();
            var mockVendingMachineApplication = new Mock<IVendingMachineApplication>();

            var mainDisplay = new Mock<MainDisplay>();
            mainDisplay.Setup(x => x.AskForPassword()).Returns("supercalifragilisticexpialidocious");

            var loginUseCase = new Mock<LoginUseCase>(mockVendingMachineApplication, mainDisplay, mockLogin);

            //Act

            //loginUseCase.Setup(x => x.Execute());

            //Assert
            Assert.False(new InvalidPasswordException("Invalid password") == loginUseCase.Setup(x => x.Execute()));*/
        }
    }
}
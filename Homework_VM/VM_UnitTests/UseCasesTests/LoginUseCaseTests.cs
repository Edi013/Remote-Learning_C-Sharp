
using Moq;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.UseCases;
using iQuest.VendingMachine.Classes;
using iQuest.VendingMachine.Exceptions;


namespace VM_UnitTests.UseCases
{
    public class LoginUseCaseTests
    {
        private string correctPassword = "supercalifragilisticexpialidocious";
        private string incorrectPassword = "Just a string, not the right password";

        [Fact]
        public void HavingAuthenticationService_WhenCorrectPassword_ThanLoginSuccesful()
        {
            //Arange 
            AuthenticationService authenticationService = new AuthenticationService();

            //Act
            authenticationService.Login(correctPassword);

            //Assert
            Assert.True(authenticationService.IsUserAuthenticated);
        }
        
        [Fact]
        public void HavingAuthenticationService_WhenIncorrectPassword_ThanLoginFail()
        {
            //Arange
            AuthenticationService authenticationService = new AuthenticationService();

            //Act
            try
            {
                authenticationService.Login(incorrectPassword);
            }catch(InvalidPasswordException e)
            {
                
            }

            //Assert
            Assert.False(authenticationService.IsUserAuthenticated);

        }

        [Fact]
        public void HavingAuthenticationService_WhenUserIsNotLoggedIn_ThanLogoutSuccesful()
        {
            //Arange
            AuthenticationService authenticationService = new AuthenticationService();
            //Act     
            authenticationService.Logout();           
            //Assert
            Assert.False(authenticationService.IsUserAuthenticated);
        }

        [Fact]
        public void HavingAuthenticationService_WhenUserIsAlredyLoggedIn_ThanLogoutSuccesful()
        {
            //Arange
            AuthenticationService authenticationService = new AuthenticationService();
            authenticationService.Login(correctPassword);
            //Act     
            authenticationService.Logout();
            //Assert
            Assert.False(authenticationService.IsUserAuthenticated);
        }
    }
}
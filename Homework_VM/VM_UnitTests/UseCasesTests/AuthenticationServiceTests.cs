
using Moq;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.UseCases;
using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine;
using iQuest.VendingMachine.DataLayer;
using iQuest.VendingMachine.Services;

namespace VM_UnitTests.UseCasesTests
{
    public class AuthenticationServiceTests
    {
        private string correctPassword = "supercalifragilisticexpialidocious";
        private string incorrectPassword = "Just a string, not the right password";

        [Fact]
        public void HavingAuthenticationServiceLoginMethod_WhenCorrectPassword_ThanLoginSuccesful()
        {
            //Arange 
            AuthenticationService authenticationService = new AuthenticationService();

            //Act
            authenticationService.Login(correctPassword);

            //Assert
            Assert.True(authenticationService.IsUserAuthenticated);
        }
        
        [Fact]
        public void HavingAuthenticationServiceLoginMethod_WhenIncorrectPassword_ThanLoginFail()
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
        public void HavingAuthenticationServiceLogoutMethod_WhenUserIsLoggedIn_ThanLogoutSuccesful()
        {
            //Arange
            AuthenticationService authenticationService = new AuthenticationService();
            authenticationService.Login(correctPassword);
            //Act     
            authenticationService.Logout();
            //Assert
            Assert.False(authenticationService.IsUserAuthenticated);
        }

        [Fact]
        public void HavingAuthenticationServiceLogoutMethod_WhenUserIsNotLoggedIn_ThanLogoutSuccesful()
        {
            //Arange
            AuthenticationService authenticationService = new AuthenticationService();
            //Act     
            authenticationService.Logout();           
            //Assert
            Assert.False(authenticationService.IsUserAuthenticated);
        }
    }
}
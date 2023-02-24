using iQuest.VendingMachine.Business.Exceptions;

namespace iQuest.VendingMachine.Business
{
    public class AuthenticationService : IAuthenticationService
    {
        private bool isUserAuthenticated;
        public bool IsUserAuthenticated { get => isUserAuthenticated; private set => isUserAuthenticated = value; }

        public AuthenticationService()
        {
            IsUserAuthenticated = false;
        }

        public void Login(string userInputedPassword)
        {
            if (userInputedPassword != "supercalifragilisticexpialidocious")
            {
                throw new InvalidPasswordException("Invalid password");
            }
            IsUserAuthenticated = true;
        }
        public void Logout()
        {
            IsUserAuthenticated = false;
        }
    }
}

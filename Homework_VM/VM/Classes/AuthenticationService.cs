using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iQuest.VendingMachine.Exceptions;


namespace iQuest.VendingMachine.Classes
{
    internal class AuthenticationService
    {
        public bool IsUserAuthenticated { get; private set; } 

        internal AuthenticationService() 
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

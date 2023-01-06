﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iQuest.VendingMachine.Exceptions;


namespace iQuest.VendingMachine.Services
{
    internal class AuthenticationService : IAuthenticationService
    {
        private bool isUserAuthenticated;
        public bool IsUserAuthenticated { get => isUserAuthenticated; private set => isUserAuthenticated = value; }

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

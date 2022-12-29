using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iQuest.VendingMachine.Services
{
    internal interface IAuthenticationService
    {
        public bool IsUserAuthenticated { get; set; }
        public void Login(string userInputedPassword);
        public void Logout();

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iQuest.VendingMachine.Business
{
    public interface IAuthenticationService
    {
        public bool IsUserAuthenticated { get; }
        public void Login(string userInputedPassword);
        public void Logout();

    }
}

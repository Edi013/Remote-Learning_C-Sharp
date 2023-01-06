using iQuest.VendingMachine.Services;
using iQuest.VendingMachine.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM_UnitTests.UseCasesTests
{
    public class LogoutUseCaseConstructorTests
    {
        private IAuthenticationService authenticationService;

        [Fact]
        public void HavingOneArgumentNull_ThrowsException()
        {
            authenticationService = null;
            Assert.Throws<ArgumentNullException>(() => new LogoutUseCase(authenticationService));
        }
    }
}

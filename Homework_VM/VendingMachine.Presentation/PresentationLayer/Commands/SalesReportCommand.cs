using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iQuest.VendingMachine.Business;

namespace iQuest.VendingMachine.Presentation
{
    public class SalesReportCommand : ICommand
    {
        private readonly IAuthenticationService authenticationService;
        private IUseCaseFactory factory;


        public string Name => "Sales report";
        public string Description => "Admins can generate reports - sales";
        public bool CanExecute => authenticationService.IsUserAuthenticated;

        public SalesReportCommand(IAuthenticationService authenticationService, IUseCaseFactory factory)
        {
            this.authenticationService = authenticationService;
            this.factory = factory;
        }

        public void Execute()
        {
            var usecCase = factory.Create<SalesReportUseCase>();
            usecCase.Execute();
        }
    }
}

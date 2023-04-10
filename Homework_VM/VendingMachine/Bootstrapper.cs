using Autofac;
using iQuest.VendingMachine.Business;

namespace iQuest.VendingMachine
{
    internal class Bootstrapper
    {
        public void Run()
        {
            var container = AutofacContainer.BuildAutofacContainer();
            using (var scope = container)
            {
                var app = scope.Resolve<VendingMachineApplication>();
                app.Run();
            }
        }
    }
}

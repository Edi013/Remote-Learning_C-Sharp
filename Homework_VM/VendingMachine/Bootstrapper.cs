using Autofac;
using iQuest.VendingMachine.Business;

namespace iQuest.VendingMachine
{
    internal class Bootstrapper
    {
        public void Run()
        {
            var container = AutofacContainer.GetInstance();
            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<VendingMachineApplication>();
                app.Run();
            }
        }
    }
}

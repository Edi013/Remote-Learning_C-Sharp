using Autofac;

namespace iQuest.VendingMachine
{
    internal class Bootstrapper
    {
        public void Run()
        {
            Log4NetConfigurator.Configure();
            var container = AutofacContainer.BuildAutofacContainer();
            using (var scope = container)
            {
                var app = scope.Resolve<VendingMachineApplication>();
                app.Run();
            }
        }
    }
}

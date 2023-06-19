using Autofac;

namespace iQuest.VendingMachine
{
    internal class Bootstrapper
    {
        public void Run()
        {

            var container = AutofacContainer.BuildAutofacContainer();
            using (var scope = container)
            {
                Log4NetConfigurator.Configure();
                var app = scope.Resolve<VendingMachineApplication>();
                app.Run();
            }
        }
    }
}

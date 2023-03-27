using System.Configuration;
using System.Reflection;
using Autofac;
using iQuest.VendingMachine.Business;
using iQuest.VendingMachine.DataAcces;
using iQuest.VendingMachine.Presentation;

namespace iQuest.VendingMachine
{
    internal class Bootstrapper
    {
        private static IContainer Container { get; set; }

        public void Run()
        {
            VendingMachineApplication vendingMachineApplication = BuildApplication();
            vendingMachineApplication.Run();
        }

        private static VendingMachineApplication BuildApplication()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MainDisplay>()
                 .As<IMainDisplay>();

            var businessAssembly = Assembly.GetAssembly(typeof(IUseCase));
            builder.RegisterAssemblyTypes(businessAssembly)
                 .Where(type => type.Name.EndsWith("UseCase"))
                 .As<IUseCase>();

            string _connectionString;
            switch (ConfigurationManager.AppSettings["repoType"])
            {
                case "InMemory":
                    builder.RegisterType<InMemoryRepository>()
                        .As<IProductRepository>();
                    break;
                case "SQL":
                    _connectionString =
                        ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
                    builder.Register<SqlServerRepository>(_ => new SqlServerRepository(_connectionString))
                        .As<IProductRepository>();
                    break;
                case "LiteDB":
                    _connectionString =
                        ConfigurationManager.ConnectionStrings["LiteDB"].ConnectionString;
                    builder.Register<LiteDBRepository>(_ => new LiteDBRepository(_connectionString))
                        .As<IProductRepository>();
                    break;
            }

            builder.RegisterType<TurnOffService>()
                .As<ITurnOffService>();
            builder.RegisterType<AuthenticationService>()
                .As<IAuthenticationService>();



            builder.RegisterType<ShelfView>()
                .As<IShelfView>();
            builder.RegisterType<BuyView>()
                .As<IBuyView>();

            builder.RegisterAssemblyTypes(businessAssembly)
                 .Where(type => type.Name.EndsWith("Payment"))
                 .As<IPaymentAlgorithm>(); ;



            builder.RegisterCallback(_ => new VendingMachineApplication(
                (List<IUseCase>)Container.Resolve<IUseCase>(),
                Container.Resolve<MainDisplay>(), Container.Resolve<TurnOffService>()));


            Container = builder.Build();
            return Container.Resolve<VendingMachineApplication>();
        }
    }
}

/*string _connectionString;

IProductRepository productRepository = null;
switch (ConfigurationManager.AppSettings["repoType"])
{
    case "InMemory":
        productRepository = new InMemoryRepository();
        break;
    case "SQL":
        _connectionString = 
            ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        productRepository = new SqlServerRepository(_connectionString);
        break;
    case "LiteDB":
        _connectionString =
            ConfigurationManager.ConnectionStrings["LiteDB"].ConnectionString;

        productRepository = new LiteDBRepository(_connectionString);
        break;
}

TurnOffService turnOffService = new TurnOffService();

AuthenticationService authenticationService = new AuthenticationService();

VendingMachineApplication vendingMachineApplication =
    new VendingMachineApplication(useCases, mainDisplay, turnOffService);

ShelfView shelfView = new ShelfView();
BuyView buyView = new BuyView();

List<IPaymentAlgorithm> paymentAlgorithms = new List<IPaymentAlgorithm>
{
    new CardPayment(new CardPaymentTerminal()),
    new CashPayment(new CashPaymentTerminal())
};
PaymentUseCase payment = new PaymentUseCase(buyView, paymentAlgorithms); 

useCases.AddRange(new IUseCase[]
{

    new LoginUseCase(mainDisplay, authenticationService),
    new LogoutUseCase(authenticationService),
    new TurnOffUseCase(turnOffService, authenticationService), 
    new LookUseCase(productRepository, shelfView),
    new BuyUseCase(buyView, authenticationService, productRepository, payment)
});*/

using System.Configuration;
using Autofac;
using iQuest.VendingMachine.Business;
using iQuest.VendingMachine.DataAcces;
using iQuest.VendingMachine.Presentation;

namespace iQuest.VendingMachine
{
    internal class Bootstrapper
    {
        public void Run()
        {
            var container = BuildAutofacContainer();
            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<VendingMachineApplication>();
                app.Run();
            }
        }

        private static IContainer BuildAutofacContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<CardPayment>()
                 .As<IPaymentAlgorithm>();
            builder.RegisterType<CashPayment>()
                 .As<IPaymentAlgorithm>();
            builder.RegisterType<PaymentUseCase>()
                .As<IPaymentUseCase>();
            builder.RegisterType<CardValidator>()
                .AsSelf();

            builder.RegisterType<BuyUseCase>()
                .As<IUseCase>();
            builder.RegisterType<LoginUseCase>()
                .As<IUseCase>();
            builder.RegisterType<LogoutUseCase>()
                .As<IUseCase>();
            builder.RegisterType<LookUseCase>()
                .As<IUseCase>();
            builder.RegisterType<PaymentUseCase>()
                .As<IPaymentUseCase>();
            builder.RegisterType<TurnOffUseCase>()
                .AsSelf();

            builder.RegisterType<TurnOffService>()
                .As<ITurnOffService>();
            builder.RegisterType<AuthenticationService>()
                .As<IAuthenticationService>();
            builder.RegisterType<PaymentMethod>()
                .AsSelf();

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

            builder.RegisterType<ShelfView>()
                .As<IShelfView>();
            builder.RegisterType<BuyView>()
                .As<IBuyView>();
            builder.RegisterType<MainDisplay>()
                 .As<IMainDisplay>();
            builder.RegisterType<CashPaymentTerminal>()
                .As<ICashPaymentTerminal>();
            builder.RegisterType<CardPaymentTerminal>()
                .As<ICardPaymentTerminal>();

            builder.RegisterType<VendingMachineApplication>()
                .As<VendingMachineApplication>()
                .SingleInstance();

            return builder.Build();
        }
    }
}

using Autofac;
using System.Configuration;
using iQuest.VendingMachine.DataAcces;
using iQuest.VendingMachine.Presentation;
using iQuest.VendingMachine.Business;

namespace iQuest.VendingMachine
{
    public class AutofacContainer
    {
        private static IContainer container;

        public static IContainer GetInstance()
        {
            if (container == null)
                container = BuildAutofacContainer();
            return container;
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
            builder.RegisterType<PaymentUseCase>()
                .As<IPaymentUseCase>();

            builder.RegisterType<BuyUseCase>()
                .As<IUseCase>()
                .SingleInstance();
            builder.RegisterType<LoginUseCase>()
                .As<IUseCase>()
                .SingleInstance();
            builder.RegisterType<LogoutUseCase>()
                .As<IUseCase>()
                .SingleInstance();
            builder.RegisterType<LookUseCase>()
                .As<IUseCase>()
                .SingleInstance();
            builder.RegisterType<TurnOffUseCase>()
                .AsSelf();

            builder.RegisterType<BuyCommand>()
                .As<ICommand>()
                .SingleInstance();
            builder.RegisterType<LoginCommand>()
                .As<ICommand>()
                .SingleInstance();
            builder.RegisterType<LogoutCommand>()
                .As<ICommand>()
                .SingleInstance();
            builder.RegisterType<LookCommand>()
                .As<ICommand>()
                .SingleInstance();

            builder.RegisterType<UseCaseFactory>()
                .As<IUseCaseFactory>();
            builder.RegisterType<BuyUseCase>()
                .AsSelf();
            builder.RegisterType<LoginUseCase>()
                .AsSelf();
            builder.RegisterType<LogoutUseCase>()
                .AsSelf();
            builder.RegisterType<LookUseCase>()
                .AsSelf();
            
            

            builder.RegisterType<TurnOffService>()
                .As<ITurnOffService>()
                .SingleInstance();
            builder.RegisterType<AuthenticationService>()
                .As<IAuthenticationService>()
                .SingleInstance();
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

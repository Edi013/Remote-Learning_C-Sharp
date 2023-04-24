using Autofac;
using System.Configuration;
using iQuest.VendingMachine.DataAcces;
using iQuest.VendingMachine.Presentation;
using iQuest.VendingMachine.Business;
using iQuest.VendingMachine.JsonReports;
using iQuest.VendingMachine.DataAccess;

namespace iQuest.VendingMachine
{
    public class AutofacContainer
    {
        public static IContainer BuildAutofacContainer()
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
            builder.RegisterType<StockReportUseCase>()
                .As<IUseCase>()
                .SingleInstance();
            builder.RegisterType<SalesReportUseCase>()
                .As<IUseCase>()
                .SingleInstance();
            builder.RegisterType<VolumeReportUseCase>()
                .As<IUseCase>()
                .SingleInstance();
            builder.RegisterType<SupplyNewProductUseCase>()
                .As<IUseCase>()
                .SingleInstance();
            builder.RegisterType<SupplyExistingProductUseCase>()
                .As<IUseCase>()
                .SingleInstance();

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
            builder.RegisterType<StockReportCommand>()
                .As<ICommand>()
                .SingleInstance();
            builder.RegisterType<SalesReportCommand>()
                .As<ICommand>()
                .SingleInstance();
            builder.RegisterType<VolumeReportCommand>()
                .As<ICommand>()
                .SingleInstance();
            builder.RegisterType<SupplyNewProductCommand>()
                .As<ICommand>()
                .SingleInstance();
            builder.RegisterType<SupplyExistingProductCommand>()
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
            builder.RegisterType<TurnOffUseCase>()
                .AsSelf();
            builder.RegisterType<StockReportUseCase>()
                .AsSelf();
            builder.RegisterType<SalesReportUseCase>()
                .AsSelf();
            builder.RegisterType<VolumeReportUseCase>()
                .AsSelf();
            builder.RegisterType<SupplyNewProductUseCase>()
                .AsSelf(); 
            builder.RegisterType<SupplyExistingProductUseCase>()
                .AsSelf();


            builder.RegisterType<JsonStockReportRepository>()
                .As<IReportRepository<StockReport>>();
            builder.RegisterType<JsonSalesReportRepository>()
                .As<IReportRepository<SalesReport>>();
            builder.RegisterType<JsonVolumeReportRepository>()
                .As<IReportRepository<VolumeReport>>();

            switch (ConfigurationManager.AppSettings["SalesRepository"])
            {
                case "Local":
                    builder.RegisterType<SalesRepository>()
                        .As<ISaleRepository>()
                        .SingleInstance();
                    break;
                case "SQL":
                    string sqlConnectionString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
                    builder.Register<SqlSalesRepository>(_ => new SqlSalesRepository(sqlConnectionString))
                        .As<ISaleRepository>()
                        .SingleInstance();
                    break;
            }

            builder.RegisterType<ReportsView>()
                .As<IReportsView>();
            builder.RegisterType<SupplyProductView>()
                .As<ISupplyProductView>();

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
                        .As<IProductRepository>()
                        .SingleInstance();
                    break;

                case "SQL":
                    _connectionString =
                        ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
                    builder.Register<SqlServerRepository>(_ => new SqlServerRepository(_connectionString))
                        .As<IProductRepository>()
                        .SingleInstance();
                    break;

                case "LiteDB":
                    _connectionString =
                        ConfigurationManager.ConnectionStrings["LiteDB"].ConnectionString;
                    builder.Register<LiteDBRepository>(_ => new LiteDBRepository(_connectionString))
                        .As<IProductRepository>()
                        .SingleInstance();
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

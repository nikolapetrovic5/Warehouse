using Autofac;
using Warehouse.Repository;
using Warehouse.Repository.Factories;
using Warehouse.Repository.Factories.Interfaces;
using Warehouse.Repository.Interfaces;
using Warehouse.Service;
using Warehouse.Service.Interfaces;

namespace Warehouse.App;

public static class Program
{
    public static IContainer Container;

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Container = ConfigureServices();

        Application.Run(
            new Form1(
                Container.Resolve<IAccountRepository>(),
                Container.Resolve<IProductRepository>()
                )
            );
    }

    static IContainer ConfigureServices()
    {
        var builder = new ContainerBuilder();

        // Repositories
        builder.RegisterType<ProductRepository>().As<IProductRepository>();
        builder.RegisterType<AccountRepository>().As<IAccountRepository>();

        // Factories
        builder.RegisterType<ConnectionFactory>().As<IConnectionFactory>();

        // Services
        builder.RegisterType<AuthenticationService>().As<IAuthenticationService>();

        // Forms able to use services
        builder.RegisterType<Form1>();

        return builder.Build();
    }
}

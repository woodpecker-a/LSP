using Autofac;
using Structure.DbContexts;
using Structure.Repositories;
using Structure.Services;
using Structure.UnitOfWorks;

public class StructureModule : Module
{
    private readonly string _connectionString;
    private readonly string _migrationAssemblyName;

    public StructureModule(string connectionString, string migrationassembly)
    {
        _connectionString = connectionString;
        _migrationAssemblyName = migrationassembly;
    }

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ApplicationDbContext>().AsSelf()
            .WithParameter("connectionString", _connectionString)
            .WithParameter("migrationAssemblyName", _migrationAssemblyName)
            .InstancePerLifetimeScope();

        builder.RegisterType<ApplicationDbContext>().As<IApplicationDbContext>()
            .WithParameter("connectionString", _connectionString)
            .WithParameter("migrationAssemblyName", _migrationAssemblyName)
            .InstancePerLifetimeScope();

        builder.RegisterType<ProductRepository>().As<IProductRepository>()
            .InstancePerLifetimeScope();

        builder.RegisterType<ApplicationUnitOfWork>().As<IApplicationUnitOfWork>()
            .InstancePerLifetimeScope();

        builder.RegisterType<ProductService>().As<IProductService>()
            .InstancePerLifetimeScope();

        base.Load(builder);
    }
}
using Autofac;
using LSP.API.Models;

public class APIModulle : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ProductModel>().AsSelf();

        base.Load(builder);
    }
}
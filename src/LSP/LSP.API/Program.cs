using Autofac.Extensions.DependencyInjection;
using Autofac;
using Serilog;
using Serilog.Events;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Structure.DbContexts;
using LSP.API.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((c, l) => l
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .ReadFrom.Configuration(builder.Configuration)
);

try
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    var assemblyName = Assembly.GetExecutingAssembly().FullName;

    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
    builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => {
        containerBuilder.RegisterModule(new StructureModule(connectionString,
            assemblyName));
        containerBuilder.RegisterModule(new APIModulle());
    });

    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString, m => m.MigrationsAssembly(assemblyName)));

    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    var siteSettings = builder.Configuration.GetSection("SiteSettings");
    builder.Services.Configure<SiteSettings>(siteSettings);
    var allowedSites = siteSettings.GetValue<string>("AllowedSites")?.Split(',');
    var useUrlSettings = siteSettings.GetValue<bool>("UseUrlSettings");

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();


    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch(Exception ex)
{
    Log.Fatal(ex, "Application Crushed");
}
finally
{
    Log.CloseAndFlush();
}
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolves.Autofac;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        // var serviceProvider = new AutofacServiceProvider(container);

        #region Set-up Autofac
        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()) 
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacBusinessModule());
    });
        #endregion

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Autofact, Ninject, CastleWindsor, StructureMap, LightInject, DryInject
        // AOP 
        // interface : referans tutucudur.
        //builder.Services.AddSingleton<IProductService, ProductManager>();
        //builder.Services.AddSingleton<IProductDal, EfProductDal>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            //app.UseSwagger();
            //app.UseSwaggerUI();
        }

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
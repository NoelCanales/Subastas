using Application.Data;
using Domain.Productos;
using Domain.Usuarios;
using Domain.Subastas;
using Domain.PujaSubastas;
using Domain.Primitives;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPersistence(configuration);
        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServer")));

        services.AddScoped<IApplicationDbContext>(sp =>
                sp.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IUnitOfWork>(sp =>
                sp.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IProductoRepository, ProductoRepository>();

        services.AddScoped<IUsuarioRepository, UsuarioRepository>();

        services.AddScoped<ISubastaRepository, SubastaRepository>();

        services.AddScoped<IPujaSubastaRepository, PujaSubastaRepository>();


        return services;
    }
}
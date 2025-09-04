using Inventory_Management_System.InheritDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Infrastructure.Repositorys.IRepository;
using MyApp.Infrastructure.Repositorys.Repository;

namespace MyApp.Infrastructure.Dependency_Injection
{
    public static class DependencyInjection
    {
        public static IServiceCollection InfrasDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyAppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("connectionString")));

            services.AddScoped<IPurchaseRepository, PurchaseRepository>();
            services.AddScoped<ICustomerRepository,CustomerRepository>();
            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<ISupplyRepository, SupplyRepository>();
            services.AddScoped<IWarHouseRepository, WarHouseRepository>();
            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            return services;
        }
    }
    
}

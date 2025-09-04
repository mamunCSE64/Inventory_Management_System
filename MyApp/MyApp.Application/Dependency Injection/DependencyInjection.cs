using FluentValidation;
using FluentValidation.AspNetCore;
using Inventory_Management_System.Validation;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Application.Mapper;
using MyApp.Application.Service_Layer.Service_Interface;
using MyApp.Application.Service_Layer.Service_Repostory;
using MyApp.Application.Services.ServiceImplementation;
using MyApp.Application.Services.ServiceInterfaces;
using MyApp.Application.Validation;

namespace MyApp.Application.Dependency_Injection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AppDI(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<CustomerValidator>();
            services.AddValidatorsFromAssemblyContaining<SupplierValidator>();
            services.AddValidatorsFromAssemblyContaining<WarHouseValidator>();
            services.AddValidatorsFromAssemblyContaining<UserRoleValidator>();
            services.AddValidatorsFromAssemblyContaining<UserValidator>();
            services.AddFluentValidationAutoValidation();
            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            services.AddScoped<IPurchaseService, PurchaseService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ISaleService, SaleService>();
            services.AddScoped<IStockService, StockService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<ISupplyService, SupplyService>();
            services.AddScoped<IWarhouseService, WarHouseService>();
            services.AddScoped<IApplicationUserService, ApplicationUserService>();
            return services;
        }
    }
}

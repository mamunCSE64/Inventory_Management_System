using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using MyApp.Application.Mapper;
using MyApp.Application.Dependency_Injection;
using MyApp.Infrastructure.Dependency_Injection;
using MyApp.Api.Dependency_Injection;

var builder = WebApplication.CreateBuilder(args);

// ===========================
// ✅ Add DI services from all layers
// ===========================
builder.Services.InfrasDI(builder.Configuration);  // Infrastructure services (repositories, DB context)
builder.Services.AppDI();                             // Application services (services, validators)
builder.Services.ApiiDI(builder.Configuration);      // API-specific services (JWT, CORS, etc.)

// ===========================
// ✅ Add Controllers with FluentValidation
// ===========================
builder.Services.AddControllers()
    .AddFluentValidation(fv =>
    {
        // Automatically register all validators in the assembly
        fv.RegisterValidatorsFromAssemblyContaining<MappingProfile>();
    });

// ===========================
// ✅ Add AutoMapper
// ===========================
builder.Services.AddAutoMapper(typeof(MappingProfile));

// ===========================
// ✅ Add Swagger/OpenAPI
// ===========================
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ===========================
// ✅ Add Authentication/Authorization if needed
// ===========================
// Example (JWT or Identity) should be configured in ApiiDI or here
// builder.Services.AddAuthentication(...).AddJwtBearer(...);

var app = builder.Build();

// ===========================
// ✅ Middleware pipeline
// ===========================
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty; // Swagger on root
});
 
app.UseHttpsRedirection();

// Ensure authentication is configured before authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

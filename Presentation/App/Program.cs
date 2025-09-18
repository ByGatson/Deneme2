using App.Middlewares.ExceptionMiddleware;
using Application.Mappings.AppUserMap;
using Application.Mappings.CategoryMap;
using Application.Mappings.CompanyMap;
using Application.Mappings.CustomerMap;
using Application.Mappings.ProductMap;
using Microsoft.OpenApi.Models;
using Persistence.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // JWT Authorization Header için Swagger ayarlarý
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header. Örnek: 'Bearer {token}'"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(Assembly.Load("Application")));
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<AppUserProfile>());
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<CompanyProfile>());
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<CustomerProfile>());
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<ProductProfile>());
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<CategoryProfile>());

builder.Services.AddMemoryCache();
var app = builder.Build();

app.UseMiddleware<GlobalExceptionMiddleware>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.DisplayRequestDuration();
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

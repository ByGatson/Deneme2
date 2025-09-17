using App.Middlewares.ExceptionMiddleware;
using Application.Mappings.AppUserMap;
using Application.Mappings.CompanyMap;
using Application.Mappings.CustomerMap;
using Persistence.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(Assembly.Load("Application")));
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<AppUserProfile>());
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<CompanyProfile>());
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<CustomerProfile>());

builder.Services.AddMemoryCache();
var app = builder.Build();

app.UseMiddleware<GlobalExceptionMiddleware>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

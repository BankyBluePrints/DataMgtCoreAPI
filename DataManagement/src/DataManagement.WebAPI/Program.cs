using DataManagement.Business;
using DataManagement.Business.Interfaces;
using DataManagement.Entities;
using DataManagement.Repository;
using DataManagement.Repository.Interfaces;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "DataManagement API",
        Version = "v1",
        Description = "Educational API for managing users, customers, and products"
    });

    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        options.IncludeXmlComments(xmlPath);
    }
});

var connectionString = builder.Configuration.GetConnectionString("MyConnection")
    ?? throw new InvalidOperationException(
        "ConnectionStrings:MyConnection is required. "
        + "Set ConnectionStrings__MyConnection in the environment."
    );

builder.Services.AddTransient<IUserManager, UserManager>();
builder.Services.AddTransient<IUserRepository>(_ => new UserRepository(connectionString));
builder.Services.AddTransient<IRepository<Customer>>(
    _ => new CustomerRepository(connectionString)
);
builder.Services.AddTransient<IRepository<Product>>(
    _ => new ProductRepository(connectionString)
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "DataManagement API v1");
    });
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

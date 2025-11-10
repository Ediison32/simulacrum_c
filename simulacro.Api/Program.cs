using simulacro.Application.Interfaces.Services;
using simulacro.Application.Services;
using simulacro.Domain.Interfaces;
using simulacro.Infrastructure.Extensions;
using simulacro.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);


// Database Dependency Injection:
builder.Services.AddInfrastructure(builder.Configuration);

// inyectar productos
builder.Services.AddScoped<IProductsRespository, ProductsRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

// inyectar usuarios
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUsersService, UserService>();


// cors para hacer peticiones a desde cualquier parete 
var corsPolicyName = "AllowAllOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicyName, policy =>
    {
        policy
            .AllowAnyHeader()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


// contruccion de los controladores 

builder.Services.AddControllers();

// construccion de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseCors(corsPolicyName);


app.MapControllers(); // para los controladores 

app.Run();


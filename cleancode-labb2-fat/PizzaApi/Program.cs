using Microsoft.EntityFrameworkCore;
using PizzaApi.DAL;
using PizzaApi.DAL.Repositories;
using PizzaApi.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string host = Environment.GetEnvironmentVariable("DB_HOST")!;
string db = Environment.GetEnvironmentVariable("DB_NAME")!;
string password = Environment.GetEnvironmentVariable("DB_SA_PASSWORD")!;
string connectionString = $"Data Source={host};Initial Catalog={db};User ID=sa;Password={password};TrustServerCertificate=True;";

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
builder.Services.AddScoped<IPizzaRepository, PizzaRepository>();

builder.Services.AddDbContext<PizzaContext>(options =>
{
    options.UseSqlServer(connectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

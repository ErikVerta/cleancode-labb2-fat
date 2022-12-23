using Microsoft.EntityFrameworkCore;
using OrderApi.DAL;
using OrderApi.DAL.Repositories;
using OrderApi.Interfaces;

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


builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddDbContext<OrderContext>(options =>
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

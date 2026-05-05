using RestWithASPNET10.Services;
using RestWithASPNET10.Services.Implementation;
using RestWithASPNET10.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSingleton<MathService>();
builder.Services.AddSingleton<NumberValidator>();
builder.Services.AddScoped<IPersonService, PersonServiceImpl>();



var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

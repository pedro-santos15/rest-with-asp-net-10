using RestWithASPNET10.Configurations;
using RestWithASPNET10.Services;
using RestWithASPNET10.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);

builder.AddSerilogLogging();

builder.Services.AddControllers();

builder.Services.AddScoped<IPersonService, PersonServiceImpl>();

builder.Services.AddDatabaseConfiguration(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

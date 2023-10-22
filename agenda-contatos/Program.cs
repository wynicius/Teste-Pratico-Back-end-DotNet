using agenda_contatos.Models;
using agenda_contatos.DataAccess;
using agenda_contatos.DataAccess.Repository;
using agenda_contatos.DataAccess.IRepository;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Sinks.File;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IContatoRepository, ContatoRepository>();
builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

string logpath = builder.Configuration.GetSection("Logging:Logpath").Value;
var _logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .MinimumLevel.Override("microsoft", Serilog.Events.LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.File(logpath)
    .CreateLogger();
builder.Logging.AddSerilog(_logger);

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

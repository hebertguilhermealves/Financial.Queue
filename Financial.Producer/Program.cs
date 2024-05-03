using Financial.Queue.Models.Config;
using Financial.Queue.Repositories.Interfaces;
using Financial.Queue.Repositories.Repository;
using Financial.Queue.Services.Interfaces;
using Financial.Queue.Services.Services;
using Microsoft.OpenApi.Models;
using RabbitMQ.Client;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});



var config = new RabbitMQConfiguration();

var factory = new ConnectionFactory()
{
    HostName = config.HostName,
    UserName = config.UserName,
    Password = config.Password,
    Port = config.Port
};

builder.Services.AddSingleton<IConnection>(serviceProvider =>
{
    try
    {
        // Tenta criar a conexão
            var connection = factory.CreateConnection();
        Console.WriteLine("RabbitMQ connection created successfully.");
        return connection;
    }
    catch (Exception ex)
    {
        // Logue a exceção ou trate-a conforme necessário
        Console.WriteLine("Failed to create a RabbitMQ connection: " + ex.Message);
        throw;
    }
});


builder.Services.AddSingleton<IRabbitMessageRepository, RabbitMessageRepository>();
builder.Services.AddSingleton<IRabbitMessageService, RabbitMessageService>();

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

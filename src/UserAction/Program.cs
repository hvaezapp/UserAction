using UserAction.Handlers;
using UserAction.Registeration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.RegisterSqlServer(builder.Configuration);
builder.Services.RegisterBroker(builder.Configuration);
builder.Services.RegisterRedis(builder.Configuration);  

builder.Services.AddScoped<IRedisHandler , RedisHandler>();


var app = builder.Build();


app.UseHttpsRedirection();


// Configure the HTTP request pipeline.


app.Run();

public partial class Program { }
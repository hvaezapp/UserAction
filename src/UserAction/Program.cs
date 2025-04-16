using UserAction.Registeration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.RegisterSqlServer(builder.Configuration);
builder.Services.RegisterBroker(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.





public partial class Program { }
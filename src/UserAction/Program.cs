using UserAction.Registeration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.RegisterSqlServer(builder.Configuration);
builder.Services.RegisterBroker(builder.Configuration);


//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();


var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}


app.UseHttpsRedirection();


// Configure the HTTP request pipeline.


app.Run();

public partial class Program { }
using Microsoft.EntityFrameworkCore;
using Policy.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add services to the container.
var connStr = "server=192.168.1.19;port=3306;user=user;password=123456;database=policy;Convert Zero Datetime=True;";
builder.Services.AddDbContext<Context>(opt => opt.UseMySQL(
    connStr
  ));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

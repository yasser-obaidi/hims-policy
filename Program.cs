using Microsoft.EntityFrameworkCore;
using Policy.Data;
using Policy.Data.Services;
using Policy.Helper;
using Policy.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});
// Add services to the container.
// Add services to the container.
var connStr = "server=192.168.1.3;port=3306;user=user;password=123456;database=policy;Convert Zero Datetime=True;";
builder.Services.AddDbContext<Context>(opt => opt.UseMySQL(
    connStr
  ));
builder.Services.AddHttpContextAccessor();
builder.Services
    .AddRepositories()
    .AddServices()
    .AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();
builder.Logging.AddDbLogger(options =>
{
    builder.Configuration.GetSection("Database").GetSection("Options").Bind(options);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

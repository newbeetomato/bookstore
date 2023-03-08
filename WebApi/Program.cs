using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebApi.DBOperations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//**BURA
builder.Services.AddDbContext<BookStoreDbContext>(Options => Options.UseInMemoryDatabase(databaseName: "BookStoreDB"));
//**SON
builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//**BURA
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
//**SON

var app = builder.Build();
using (var scope = app.Services.CreateScope()) { var services = scope.ServiceProvider; DataGenerator.Initialize(services); }

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

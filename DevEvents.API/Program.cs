using DevEvents.API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddSingleton<DevEventsDbContext>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Conexão com o banco de dados
var connectionStringMysql = builder.Configuration.GetConnectionString("DevEventsCs");
builder.Services.AddDbContext<DevEventsDbContext>(options => options.UseMySql(connectionStringMysql, ServerVersion.Parse("8.0-mysql")));

//Usando em mémoria
//builder.Services.AddDbContext<DevEventsDbContext>(o => o.UseInMemoryDatabase("DevEvents"));
//Conexão com o banco de dados MySql

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

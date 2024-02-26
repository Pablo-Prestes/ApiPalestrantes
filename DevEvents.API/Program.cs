using DevEvents.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "DevEventsAPI",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Pablo",
            Email = "pablo.henrique.prestes@gmail.com",
            Url = new Uri("https://www.linkedin.com/in/pablo-henrique-prestes/")
        }
    });

    var xmlFile = "DevEvents.API.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

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

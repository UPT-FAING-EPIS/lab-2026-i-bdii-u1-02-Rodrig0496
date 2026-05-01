using ClienteAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Conexión a tu Base de Datos SQL Server
builder.Services.AddDbContext<BdClientesContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("ClienteDB")));

// Habilitar los controladores y la interfaz gráfica Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// PASO 22: Comentar las siguientes líneas para que funcione en Docker
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// Forzar el uso de Swagger en cualquier entorno
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

// Mapear los controladores (TiposDocumentosController, etc.)
app.MapControllers();

app.Run();
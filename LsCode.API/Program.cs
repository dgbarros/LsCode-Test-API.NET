using Microsoft.EntityFrameworkCore;
using SeuProjeto.Data;

var builder = WebApplication.CreateBuilder(args);

// String de conexão do SQL Server (exemplo local)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Registrar o DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Outras configurações, por exemplo:
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

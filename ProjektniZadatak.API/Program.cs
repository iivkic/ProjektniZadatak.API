using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ProjektniZadatak.API.Data;
using ProjektniZadatak.API.Models.Domain;
using ProjektniZadatak.API.Repositories.Interface;

var builder = WebApplication.CreateBuilder(args);
var connectionStringBuilder = new SqliteConnectionStringBuilder
{
    DataSource = "schoolPr.db",
    // Add other necessary properties
};

var connectionString = connectionStringBuilder.ConnectionString;
// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
optionsBuilder.UseSqlite(connectionString);

ApplicationDbContext dbContext = new ApplicationDbContext();

builder.Services.AddDbContext<ApplicationDbContext>();


dbContext.SaveChanges();

var app = builder.Build();


dbContext.SaveChanges();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(options =>
{
    options.AllowAnyHeader();
    options.AllowAnyMethod();
    options.AllowAnyOrigin();
});

app.UseAuthorization();

app.MapControllers();

app.Run();

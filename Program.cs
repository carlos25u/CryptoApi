using CryptoApi.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var ConStr = builder.Configuration.GetConnectionString("ConStr");

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<Contexto>(options => options.UseSqlite(ConStr));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();

//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

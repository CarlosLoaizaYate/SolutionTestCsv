using TestCsv.Application.IServices;
using TestCsv.Application.Services;
using TestCsv.Infraestructure.Context;
using TestCsv.Infraestructure.IRepositories;
using TestCsv.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<TestCsvDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TestCsvDB")));

builder.Services.AddScoped<IUploadFileService, UploadFileService>();
builder.Services.AddScoped<IUploadFileRepository, UploadFileRepository>();
builder.Services.AddScoped<IColumnNameFileRepository, ColumnNameFileRepository>();
builder.Services.AddScoped<IColumnValueFileRepository, ColumnValueFileRepository>();

builder.Services.AddControllers().AddJsonOptions(x =>
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader();
        builder.AllowAnyMethod();
        builder.AllowAnyOrigin();
    });
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();

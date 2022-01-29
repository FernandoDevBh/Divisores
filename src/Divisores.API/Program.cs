using Divisores.Application;
using Divisores.Processamento;
using Divisores.API.Extensions;
using Divisores.API.Middlewares;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.AddApplicationServices();
builder.Services.AddProcessamentoServices();

builder.Services.AddControllers(options =>
{
  options.CacheProfiles.Add("Default30", new CacheProfile() { Duration = 30 });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCorsService(builder.Configuration);

var app = builder.Build();

app.UseResponseCaching();

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(builder.Services.GetCorsPolicyName());

app.UseAuthorization();

app.MapControllers();

app.Run();

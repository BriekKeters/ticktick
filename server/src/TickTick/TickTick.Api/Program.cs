using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;
using TickTick.Api;
using Microsoft.Extensions.DependencyInjection;
using TickTick.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<TickTickDbContext>(options=>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "TickTick.Api",
            Version = "v1",
            Description = "Lorem",
            Contact = new OpenApiContact
            {
                Name = "Briek",
                Email = "OpenAI@Gmail.com",
                Url = new Uri("https://chat.openai.com")
            }
        });
});
builder.Services.AddApiVersioning(config =>
{
    config.DefaultApiVersion = new ApiVersion(1, 0);
    config.AssumeDefaultVersionWhenUnspecified = true;
});

builder.Services.RegisterDependencies();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

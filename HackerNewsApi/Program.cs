using HackerNewsApi.Profiles;
using HackerNewsApi.Services.Api;
using HackerNewsApi.Services;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Refit;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add Services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers();
builder.Services.AddSingleton<IHackerNewsService, HackerNewsService>();
builder.Services.AddRefitClient<IHackerNewsApi>().ConfigureHttpClient(
    c => c.BaseAddress = new Uri(builder.Configuration["HackerNewsBaseApi"])
);
builder.Services.AddAutoMapper(typeof(HackerNewsProfile));
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc(
        "v1", new OpenApiInfo
        {
            Version = builder.Configuration["ApiInfo:Version"],
            Title = builder.Configuration["ApiInfo:Title"],
            Description = builder.Configuration["ApiInfo:Description"],
            Contact = new OpenApiContact
            {
                Name = builder.Configuration["ApiInfo:Contact:Name"],
                Email = builder.Configuration["ApiInfo:Contact:Email"],
                Url = new Uri(builder.Configuration["ApiInfo:Contact:Url"])
            }
        });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

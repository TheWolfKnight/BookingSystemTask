
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using Udlejningsmaskineoversigt.Data;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<UdlejningDataContext>();


builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo {
        Title = "Resource API - v1",
        Version = "v1",
    });
    string xmlFileMain = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    string xmlFileAbstraction = "Abstraction.xml";
    string filePathMain = Path.Combine(AppContext.BaseDirectory, xmlFileMain);
    string filePathAbstraction = Path.Combine(AppContext.BaseDirectory, xmlFileAbstraction);
    c.IncludeXmlComments(filePathMain);
    c.IncludeXmlComments(filePathAbstraction);
});


WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.MapControllers();

app.Run();

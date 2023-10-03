
using Microsoft.AspNetCore.Cors.Infrastructure;
using Udlejningsmaskineoversigt.Data;

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

    foreach (string path in Directory.EnumerateFiles(AppContext.BaseDirectory)) {
        if (!path.EndsWith(".xml")) continue;
        c.IncludeXmlComments(path);
    }
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

app.UseCors(policyBuilder => {
    policyBuilder.AllowAnyMethod();
    policyBuilder.AllowAnyHeader();
    policyBuilder.AllowAnyOrigin();
});

app.Run();

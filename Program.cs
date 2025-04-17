using complete_guide_to_aspnetcore_web_api.Data;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using CompleteGuideToAspNetCoreWebApi.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); 

// Add services to the container
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v2", new OpenApiInfo { Title = "My API", Version = "v2" });
});

var app = builder.Build();

AppDbInitializer.Seed(app); 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v2/swagger.json", "My API V2");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



app.Run();

// Call the seed method to initialize the database with data




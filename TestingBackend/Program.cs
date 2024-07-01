using Microsoft.EntityFrameworkCore;
using TestingBackend.BusinessLayer.Interfaces;
using TestingBackend.BusinessLayer.Mapping;
using TestingBackend.BusinessLayer.Services;
using TestingBackend.DataLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<ITestService, TestService>();

var connection = builder.Configuration.GetConnectionString("Database");
builder.Services.AddDbContext<TestingBackendDbContext>(options => options.UseSqlServer(connection));

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.EnableTryItOutByDefault();
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TestingBackend");
        //c.OAuthClientId(AzureAdConfiguration["ClientId"]);
        //c.OAuthRealm(AzureAdConfiguration["ClientId"]);
        c.OAuthUsePkce();
        c.RoutePrefix = "docs";
        //c.OAuthScopes($"api://{AzureAdConfiguration["ClientId"]}/access_as_user");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

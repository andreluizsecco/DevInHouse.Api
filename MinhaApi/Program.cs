using System.Reflection;
using MinhaApi.Interfaces;
using MinhaApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var CORSPolicy = "CORSPolicy";

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CORSPolicy,
        policy  =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod();
        });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});
builder.Services.AddScoped<IHealthCheck, HealthCheck>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseCors(CORSPolicy);
app.UseAuthorization();
app.MapControllers();

app.Run();

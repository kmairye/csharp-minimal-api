using System.Reflection;
using WordPredictorMinimalApi.Clients;

// Initiate client
LingappsClient client = new LingappsClient();

// Builder container
var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddHttpClient();
builder.Configuration.AddEnvironmentVariables().AddUserSecrets(Assembly.GetExecutingAssembly(), true);
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
var app = builder.Build();

app.UseCors("corsapp");




app.MapGet("/", () => "Hello World!");

app.MapGet("/{textInput}", async (string textInput) => 
{
    return await client.Get(textInput);
});

app.Run();

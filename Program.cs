
// create a builder class instance which will create the application
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
// only if the app is not fully deployed
if (app.Environment.IsDevelopment()) app.MapOpenApi();

// This tells the web app to use HTTPS redirection protocol
// Meaning the app can respond to GET, POST, DELETE, etc. requests
app.UseHttpsRedirection();

app.MapGet("/hello", () => {return "Hello";}).WithName("GetHello");

// runs the server
app.Run();
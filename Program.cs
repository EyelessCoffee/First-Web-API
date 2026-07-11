
// create a builder class instance which will create the application
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
// only if the app is not fully deployed
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// This tells the web app to use HTTPS redirection protocol
// Meaning the app can respond to GET, POST, DELETE, etc. requests
app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};


// This is where I determine what happens when a GET request is made,
// specifically, a get request with a /weatherforcast at the end of
// the URL.

// Note that this code does not happen here I am just
// adding this delegate to the server to respond when a GET
// request is made
app.MapGet("/weatherforecast", () =>
{
    // Just the demo code, which picks a random weather from the summaries
    // and returns it to the get
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

// runs the server
app.Run();

// the weather forcast record used in the demo
record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

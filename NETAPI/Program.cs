var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "API is running.");

app.MapGet("/pokemons", () =>
{
    var pokemons = new[]
    {
        new { Id = 1, Name = "Charmander", Type = "Fire"},
        new { Id = 2, Name = "Bulbasaur", Type = "Grass"},
        new { Id = 3, Name = "Squirtle", Type = "Water"}
    };

    return pokemons;
});

app.Run();

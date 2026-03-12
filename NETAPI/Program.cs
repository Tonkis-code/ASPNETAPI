var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "API is running.");

// GET Request for the pokemons inside of the pokemons variable
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

var attacks = [
    Id = attack1,
    request.Name = "Tackle",
    request.Damage = 40,
    request.Type = "Normal",


];

app.Run();

// POST Request for an attack
app.MapPost("/attack", (AttackRequest request) =>
{
    var attack = new
    {
        Id = 1,
        Name = request.Name,
        Damage = request.Damage,
        Type = request.Type
    };

    return attack;
});

public class AttackRequest
{
    public string Name { get; set; }
    public int Damage { get; set; }     // int because its a number not a string (i forgot)
    public string Type { get; set; }
}


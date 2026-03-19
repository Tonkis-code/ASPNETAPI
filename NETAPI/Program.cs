var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var pokemons = new List<Pokemon>
{
    new Pokemon { Id = 1, Name = "Charmander", Type = "Fire" },
    new Pokemon { Id = 2, Name = "Bulbasaur", Type = "Grass" },
    new Pokemon { Id = 3, Name = "Squirtle", Type = "Water"}
};

var attacks = new List<Attack>
{
    new Attack { Id = 1, Name = "Tackle", Damage = 40, Type = "Normal" }
};

app.MapGet("/", () => "API is running.");

app.MapGet("/pokemons", () => pokemons);

app.MapGet("/attacks", () => attacks);

app.MapPost("/attack", (AttackRequest request) =>
{
    var attack = new Attack
    {
        Id = attacks.Count + 1,
        Name = request.Name,
        Damage = request.Damage,
        Type = request.Type
    };

    attacks.Add(attack);
    return Results.Created($"/attacks/{attack.Id}", attack);
});

app.Run();

public class Pokemon
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Type { get; set; } = "";
}

public class Attack
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int Damage { get; set; }
    public string Type { get; set; } = "";
}

public class AttackRequest
{
    public string Name { get; set; } = "";
    public int Damage { get; set; }
    public string Type { get; set; } = "";
}
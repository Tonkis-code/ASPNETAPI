var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// In-memory list of Pokémon used for testing API responses
var pokemons = new List<Pokemon>
{
    new Pokemon { Id = 1, Name = "Charmander", Type = "Fire" },
    new Pokemon { Id = 2, Name = "Bulbasaur", Type = "Grass" },
    new Pokemon { Id = 3, Name = "Squirtle", Type = "Water"}
};

// In-memory list of attacks used for testing POST and GET endpoints
var attacks = new List<Attack>
{
    new Attack { Id = 1, Name = "Tackle", Damage = 40, Type = "Normal" }
};

// Health check endpoint to verify the API is running
app.MapGet("/", () => "API is running.");

// Returns all Pokémon
app.MapGet("/pokemons", () => pokemons);

// Returns all attacks
app.MapGet("/attacks", () => attacks);

// Returns a single attack chosen by ID
app.MapGet("/attacks/{id}", (int id) =>
{
    var attack = attacks.FirstOrDefault(a => a.Id == id);
    return attack is not null ? Results.Ok(attack) : Results.NotFound();
});

// Returns a single Pokémon chosen by ID
app.MapGet("/pokemons/{id}", (int id) =>
{
    var pokemon = pokemons.FirstOrDefault(a => a.Id == id);
    return pokemon is not null ? Results.Ok(pokemon) : Results.NotFound();
});

// Creates a new attack and adds it to the in-memory list
app.MapPost("/attacks", (AttackRequest request) =>
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

// Creates a new Pokémon and adds it to the in-memory list
app.MapPost("/pokemons", (PokemonRequest request) =>
{
    var pokemon = new Pokemon
    {
        Id = pokemons.Count + 1,
        Name = request.Name,
        Type = request.Type
    };

    pokemons.Add(pokemon);
    return Results.Created($"/pokemons/{pokemon.Id}", pokemon);
});

app.Run();




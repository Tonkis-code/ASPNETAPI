public class Battle
{
    public int Id { get; set; }
    public int PlayerPokemonId { get; set; }
    public int EnemyPokemonId { get; set; }
    public int PlayerHp { get; set; } = 100;
    public int EnemyHp { get; set; } = 100;
    public bool IsOver { get; set; } = false;
}
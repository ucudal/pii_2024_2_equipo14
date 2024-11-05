namespace Library;

public class Revivir: Item
{
    public void RevivirPokemon(Pokemon pokemon)
    {
        pokemon.Curar(pokemon.VidaInicial/2);
    } 
}
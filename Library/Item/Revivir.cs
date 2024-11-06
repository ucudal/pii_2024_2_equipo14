namespace Library;

public class Revivir: Item
{
    public Revivir()
    {
        this.Nombre = "Revivir";
    }
    public void RevivirPokemon(Pokemon pokemon)
    {
        pokemon.Curar(pokemon.VidaInicial/2);
    } 
}
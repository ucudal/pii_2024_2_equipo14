namespace Library;

public class SuperPocion: Item
{
    public void SuperPocionar(Pokemon pokemon)
    {
        pokemon.Curar(70);
    }
}
namespace Library;

public class SuperPocion: Item
{
    
    public SuperPocion()
    {
        this.Nombre = "Súper Poción";
    }
    public void SuperPocionar(Pokemon pokemon)
    {
        pokemon.Curar(70);
    }
}
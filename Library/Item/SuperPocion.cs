namespace Library;

public class SuperPocion: Item
{
    
    public SuperPocion()
    {
        this.Nombre = "Súper Poción";
        this.Descripcion = "Recupera 70 puntos de vida";
    }
    public void SuperPocionar(Entrenador entrenador, Pokemon pokemon)
    {
        pokemon.Curar(70);
        entrenador.QuitarItem(this);
    }
}
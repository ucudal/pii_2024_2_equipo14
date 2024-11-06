namespace Library;

public class CuraTotal: Item
{
    
    public CuraTotal()
    {
        this.Nombre = "Cura Total";
    }
    public void CurarTotalmente(Pokemon pokemon)
    {
        pokemon.Curar(pokemon.VidaInicial);
    }
}
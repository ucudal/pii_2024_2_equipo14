namespace Library;

public class CuraTotal: Item
{
    public void CurarTotalmente(Pokemon pokemon)
    {
        pokemon.Curar(pokemon.VidaInicial);
    }
}
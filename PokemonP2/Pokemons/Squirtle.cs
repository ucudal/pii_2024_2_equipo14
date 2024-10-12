namespace PokemonP2;

public class Squirtle: IPokemon
{
    private int vidaTotal = 80;
    public string Nombre
    {
        get { return "Squirtle"; }
    }

    public ITipo Tipo
    {
        get { return new Agua(); }

    }
    public int VidaInicial 
    {
        get { return 80; }
    }
    public int VidaTotal
    {
        get { return this.vidaTotal;}
        set { this.vidaTotal = value; }
    }
    public int Dano
    {
        get { return 20; }
    }
}
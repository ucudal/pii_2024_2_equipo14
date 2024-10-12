namespace PokemonP2;

public class Charmander: IPokemon
{
    private int vidaTotal = 60;
    public string Nombre
    {
        get { return "Charmander"; }
    }

    public ITipo Tipo
    {
        get { return new Fuego(); }

    }
    public int VidaInicial 
    {
        get { return 60; }
    }
    public int VidaTotal
    {
        get { return this.vidaTotal;}
        set { this.vidaTotal = value; }
    }
    public int Dano
    {
        get { return 40; }
    }
}
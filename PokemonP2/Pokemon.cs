namespace PokemonP2;

public class Pokemon
{
    private string nombre;
    private ITipo tipo;
    private int ataque;
    private int vidaInicial;
    private int vidaTotal;

    public string GetNombre()
    {
        return this.nombre;
    }

    public ITipo GetTipo()
    {
        return this.tipo;
    }

    public int GetAtaque()
    {
        return this.ataque;
    }

    private int GetVidaInicial()
    {
        return this.vidaInicial;
    }

    private int GetVidaTotal()
    {
        return this.vidaTotal;
    }

    public Pokemon(string nombre, int ataque,ITipo tipo, int vidaInicial, int vidaTotal)
    {
        this.nombre = nombre;
        this.ataque = ataque;
        this.tipo = tipo;
        this.vidaInicial = vidaInicial;
        this.vidaTotal = vidaTotal;
    }
}
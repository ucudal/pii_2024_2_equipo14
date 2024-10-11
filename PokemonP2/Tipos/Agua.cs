namespace PokemonP2;

public class Agua: ITipo
{
    public string Nombre
    {
        get
        {
            return "Agua";
        }
    }

    public int AtaqueEspecial
    {
        get { return 40; }
    }
}
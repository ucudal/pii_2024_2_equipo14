namespace PokemonP2;

public class Fuego: ITipo
{
    public string Nombre
    {
        get
        {
            return "Fuego";
        }
    }

    public int AtaqueEspecial
    {
        get { return 80; }
    }
}
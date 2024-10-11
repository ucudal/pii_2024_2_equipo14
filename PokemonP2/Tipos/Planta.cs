namespace PokemonP2;

public class Planta: ITipo
{
    public string Nombre 
    {
        get
        {
            return "Planta";
        }
    }

    public int AtaqueEspecial
    {
        get { return 60; }
    }
}
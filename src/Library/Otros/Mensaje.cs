using System.Text;

namespace Library;

public static class Mensaje
{
    public static string PokemonesDisponibles()
    {
        string mensaje = "\nPOKÉDEX:";
        foreach (Pokemon pokemon in Pokedex.listaPokemons)
        {
            mensaje += $"\t¨{pokemon.Nombre}¨ | Tipo: {pokemon.Tipo}";
        }

        return mensaje;
    }

}
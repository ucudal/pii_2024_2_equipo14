namespace PokemonP2;

public class Ataque
{
    public static int CalcularAtaque(IPokemon pokemon1, IPokemon pokemon2)
    {
        int ataque = 0;
        if (pokemon1.Tipo == pokemon2.Tipo)
        {
            ataque = pokemon1.Dano;
        }
        
        if ((pokemon1.Tipo.Nombre == "Agua" && pokemon2.Tipo.Nombre == "Planta") ||
            (pokemon1.Tipo.Nombre == "Agua" && pokemon2.Tipo.Nombre == "Fuego") ||
            (pokemon1.Tipo.Nombre == "Fuego" && pokemon2.Tipo.Nombre == "Planta"))
        {
            ataque = pokemon1.Dano * 2;
        }

        if ((pokemon1.Tipo.Nombre == "Planta" && pokemon2.Tipo.Nombre == "Agua") || 
            (pokemon1.Tipo.Nombre == "Fuego" && pokemon2.Tipo.Nombre == "Agua"))
        {
           ataque = pokemon1.Dano / 2;
        }
        return ataque;
    }
}
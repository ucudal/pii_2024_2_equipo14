using Library.Item;

namespace Library.Otros;
/// <summary>
/// Esta es la clase estática UsarItem. Se encarga de gestionar la acción del mismo nombre durante la batalla.
/// </summary>
public static class UsarItem
{
    /// <summary>
    /// Determina el item a usar y la acción que este realiza del usuario.
    /// </summary>
    /// <param name="entrenador">El entrenador que elige item.</param>
    /// <param name="usarRevivir">El número que indica si se puede usar Revivir.</param>
    /// <param name="usarSuperPocion">El número que indica si se puede usar SuperPocion.</param>
    /// <param name="usarCuraTotal">El número que indica si se puede usar CuraTotal.</param>
    public static void UsoDeItem(Entrenador entrenador, int usarRevivir, int usarSuperPocion, int usarCuraTotal)
    {
        FacadeJuego.ElegirItem(entrenador);
        string item = Console.ReadLine();//CAMBIAR A BOT
        int itemElegido = int.Parse(item);
        if (entrenador.misItems[itemElegido] is Revivir && usarRevivir == 1)
        {
            while (entrenador.misItems[itemElegido] is Revivir)
            {
                FacadeJuego.ItemInvalido();
                FacadeJuego.ElegirItem(entrenador);
                item = Console.ReadLine();//CAMBIAR A BOT
                itemElegido = int.Parse(item);
            }
        }

        if (entrenador.misItems[itemElegido] is SuperPocion && usarSuperPocion == 1)
        {
            while (entrenador.misItems[itemElegido] is SuperPocion)
            {
                FacadeJuego.ItemInvalido();
                FacadeJuego.ElegirItem(entrenador);
                item = Console.ReadLine();//CAMBIAR A BOT
                itemElegido = int.Parse(item);

            }
        }

        if (entrenador.misItems[itemElegido] is CuraTotal && usarCuraTotal == 1)
        {
            while (entrenador.misItems[itemElegido] is CuraTotal)
            {
                FacadeJuego.ItemInvalido();
                FacadeJuego.ElegirItem(entrenador);
                item = Console.ReadLine();//CAMBIAR A BOT
                itemElegido = int.Parse(item);
            }
        }

        if (entrenador.misItems[itemElegido] is Revivir revivir)
        {
            FacadeJuego.ElegirPokemonMuerto(entrenador);
            string pokemonMuerto = Console.ReadLine();//CAMBIAR A BOT
            int pokemonElegido = int.Parse(pokemonMuerto);
            Pokemon pokemonARevivir = entrenador.misMuertos[pokemonElegido];
            revivir.Accion(entrenador, pokemonARevivir);
        }
        else
        {
            FacadeJuego.ElegirPokemonHerido(entrenador, itemElegido);
            string _pokemon = Console.ReadLine(); //CAMBIAR A BOT
            int pokemonElegido = int.Parse(_pokemon);
            Pokemon pokemon = entrenador.miCatalogo[pokemonElegido];
            if (entrenador.misItems[itemElegido] is CuraTotal curaTotal)
            {
                curaTotal.Accion(entrenador, pokemon);
                if (entrenador.misItems[itemElegido] is SuperPocion superPocion)
                {
                    superPocion.Accion(entrenador, pokemon);
                }
            }
        }
    }
}
using Library.Otros;

namespace Library.Item;
/// <summary>
/// Esta es la clase Revivir. Hereda <see cref="Item"/> y agrega el método RevivirPokemon.
/// </summary>
public class Revivir: Item
{
    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="Revivir"/>.
    /// </summary>
    public Revivir()
    {
        this.Nombre = "Revivir";
        this.Descripcion = "Revive a un Pokémon con el 50% de su vida total";
    }
    public override void Accion(Entrenador entrenador, Pokemon pokemon)
    {
        pokemon.Curar(pokemon.VidaInicial/2);
        entrenador.QuitarMuerto(pokemon);
        entrenador.Recuperar(pokemon);
        entrenador.QuitarItem(this);
    }
}
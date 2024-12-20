namespace Library;
/// <summary>
/// Esta es la clase CuraTotal. Hereda <see cref="Item"/> y agrega el método CurarTotalmente.
/// </summary>
public class CuraTotal: Item
{
    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="CuraTotal"/>.
    /// </summary>
    public CuraTotal()
    {
        this.Nombre = "CuraTotal";
        this.Descripcion = "Cura a un Pokémon de efectos de ataques especiales";
    }
    /// <summary>
    /// Cura al Pokémon ingresado de efectos de ataques especiales.
    /// <param name="entrenador">El entrenador afectado.</param>
    /// <param name="pokemon">El Pokémon afectado.</param>
    /// <summary>
    public override void Accion(Entrenador entrenador, Pokemon pokemon)
    {
        if (pokemon.Dormido)
        {
            pokemon.Dormido = false;
        }
        if (pokemon.Paralizado)
        {
            pokemon.Paralizado = false;
        }
        if (pokemon.Envenenado)
        {
            pokemon.Envenenado = false;
        }
        if (pokemon.Quemado)
        {
            pokemon.Quemado = false;
        }
        entrenador.QuitarItem(this);  
    }
}
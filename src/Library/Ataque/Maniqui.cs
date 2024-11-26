namespace Library;
/// <summary>
/// Esta es la clase Maniqui. Hereda <see cref="AtaqueEspecial"/> y agrega el método Paralizar.
/// </summary>
public class Maniqui: AtaqueEspecial
{
    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="Maniqui"/>.
    /// </summary>
    /// <param name="nombre">El nombre del ataque.</param>
    /// <param name="Dano">El daño que influye el ataque.</param>
    /// <param name="Precision">La precisión del ataque.</param>
    /// <param name="Tipo">El nombre del tipo de ataque.</param>
    /// <param name="Efecto">El nombre del efecto que realizará el ataque.</param>
    public Maniqui() : base("Maniquí", 0, 80, "Psíquico","Paralizar")
    {
        
    }
    /// <summary>
    /// Causa el efecto "Paralizar" en el Pokémon ingresado.
    /// <param name="entrenador">El entrenador afectado.</param>
    /// <param name="pokemon">El Pokémon afectado.</param>
    /// <summary>
    public override void CausarEfecto(Entrenador? entrenador, Pokemon pokemon)
    {
        pokemon.Paralizado = true;
    }
    
}
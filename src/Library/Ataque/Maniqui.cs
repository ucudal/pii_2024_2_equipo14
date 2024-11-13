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
    public override void CausarEfecto(Entrenador entrenador, Pokemon pokemon, int critico)
    {
        pokemon.Paralizado = true;
    }
}
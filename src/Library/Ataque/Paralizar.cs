using Library.Otros;

namespace Library;
/// <summary>
/// Esta es la clase Paralizar. Hereda <see cref="AtaqueEspecial"/> y agrega el método Paralizar.
/// </summary>
public class Paralizar: AtaqueEspecial
{
    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="Paralizar"/>.
    /// </summary>
    /// <param name="nombre">El nombre del ataque.</param>
    /// <param name="Dano">El daño que influye el ataque.</param>
    /// <param name="Precision">La precisión del ataque.</param>
    /// <param name="Tipo">El nombre del tipo de ataque.</param>
    /// <param name="Efecto">El nombre del efecto que realizará el ataque.</param>
    public Paralizar() : base("Maniquí", 0, 80, "Psíquico","Paralizar")
    {
        
    }
    public override void CausarEfecto(Entrenador entrenador, Pokemon pokemon, int critico)
    {
        pokemon.Paralizado = true;
    }
}
namespace Library;
/// <summary>
/// Esta es la clase Zzz. Hereda <see cref="AtaqueEspecial"/> y agrega el método Dormir.
/// </summary>
public class Zzz: AtaqueEspecial
{
    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="Zzz"/>.
    /// </summary>
    /// <param name="nombre">El nombre del ataque.</param>
    /// <param name="Dano">El daño que influye el ataque.</param>
    /// <param name="Precision">La precisión del ataque.</param>
    /// <param name="Tipo">El nombre del tipo de ataque.</param>
    /// <param name="Efecto">El nombre del efecto que realizará el ataque.</param>
    public Zzz() : base("Zzz", 0, 50, "Normal","Dormir")
    {
        
    }
    public override void CausarEfecto(Entrenador entrenador, Pokemon pokemon, int? critico)
    {
        pokemon.Dormido = true;
        Random turnosDormido = new Random();
        int turnos = turnosDormido.Next(1, 5);
        pokemon.TurnosDormido = entrenador.Turnos += turnos;
    }
}
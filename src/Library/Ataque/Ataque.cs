namespace Library;
/// <summary>
/// Esta es la clase Ataque. Se encarga de crear instancias de ataques que usarán los Pokémons en la batalla.
/// </summary>
public class Ataque
{
    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="Ataque"/>.
    /// </summary>
    /// <param name="nombre">El nombre del ataque.</param>
    /// <param name="dano">El daño que influye el ataque.</param>
    /// <param name="precision">La precisión del ataque.</param>
    /// <param name="tipo">El nombre del tipo de ataque.</param>
    public Ataque(string nombre, int dano, int precision,string tipo)
    {
        this.Nombre = nombre;
        this.Dano = dano;
        this.Precision = precision;
        this.Tipo = tipo;
    }
    /// <summary>
    /// Obtiene o establece un string que indica el nombre del ataque.
    /// </summary>
    public string Nombre { get; protected set; }
    /// <summary>
    /// Obtiene o establece un valor (int) que indica el daño del ataque.
    /// </summary>
    public int Dano { get; protected set; }
    /// <summary>
    /// Obtiene o establece un valor (int) que indica la precisión del ataque.
    /// </summary>
    public int Precision { get; protected set; }
    /// <summary>
    /// Obtiene o establece un string que indica el tipo del ataque.
    /// </summary>
    public string Tipo { get; }
    /// <summary>
    /// Calcula si el ataque es preciso, es decir, si hace o no daño/causa un efecto en la víctima.
    /// </summary>
    /// <returns>
    /// <c>0</c> si el ataque es preciso, <c>1</c> en caso contrario.
    /// </returns>
    public int CalcularPrecision()
    {
        Random numero = new Random();
        int ataca = numero.Next(1, 11);
        if (ataca > (this.Precision/10))
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}
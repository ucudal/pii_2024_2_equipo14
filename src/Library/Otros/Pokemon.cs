namespace Library;
/// <summary>
/// Esta es la clase Pokémon. Se encarga de crear instancias de Pokémon y gestionar sus responsabilidades.
/// </summary>
public class Pokemon
{
    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="Pokemon"/>.
    /// </summary>
    /// <param name="nombre">El nombre del Pokémon.</param>
    /// <param name="tipo">El tipo del Pokémon.</param>
    public Pokemon(string nombre, string tipo, Ataque ataque, AtaqueEspecial ataqueEspecial)
    {
        Nombre = nombre;
        Tipo = tipo;
        Ataque = ataque;
        AtaqueEspecial = ataqueEspecial;
        this.ataques.Add(ataque);
        this.ataques.Add(ataqueEspecial);
    }
    /// <summary>
    /// Obtiene o establece un string que indica el nombre del Pokémon.
    /// </summary>
    public string Nombre { get; protected set; }
    /// <summary>
    /// Obtiene o establece un Tipo que indica tipo del Pokémon.
    /// </summary>
    public string Tipo { get; protected set; }
    /// <summary>
    /// Atributo que indica la vida total del Pokémon
    /// </summary>
    public AtaqueEspecial AtaqueEspecial { get; set; }
    public Ataque Ataque { get; set; }
   
    private int vidaTotal = 80;
    /// <summary>
    /// Obtiene o establece un bool que indica si el Pokémon está dormido.
    /// </summary>
    public bool Dormido { get; set; }
    /// <summary>
    /// Obtiene o establece un bool que indica si el Pokémon está paralizado.
    /// </summary>
    public bool Paralizado { get; set; }
    /// <summary>
    /// Obtiene o establece un bool que indica si el Pokémon está envenenado.
    /// </summary>
    public bool Envenenado { get; set; }
    /// <summary>
    /// Obtiene o establece un bool que indica si el Pokémon está quemado.
    /// </summary>
    public bool Quemado { get; set; }
    /// <summary>
    /// Obtiene o establece un int que indica los turnos dormido del Pokémon.
    /// </summary>
    public int TurnosDormido { get; set; }
    /// <summary>
    /// Atributo que indica la lista de ataques del Pokémon.
    /// </summary>
    private List<Ataque> ataques = new List<Ataque>();
    /// <summary>
    /// Se encarga de retornar los ataques del Pokémon
    /// </summary>
    public List<Ataque> GetAtaques()
    {
        return this.ataques;
    }
    /// <summary>
    /// Obtiene un int que indica la vida inicial del Pokémon.
    /// </summary>
    public int VidaInicial {get { return 80; }}
    
    /// <summary>
    /// Obtiene un int que indica la vida total del Pokémon.
    /// </summary>
    public int VidaTotal
    {
        get { return this.vidaTotal;}
        protected set { this.vidaTotal = value < 0 ? 0 : value; }
    }
    /// <summary>
    /// Se encarga de curar al Pokémon.
    /// </summary>
    /// <param name="puntos">Los puntos de vida que se le agregan al Pokémon.</param>
    public void Curar(int puntos)
    {
        this.VidaTotal += puntos;
    }
    /// <summary>
    /// Se encarga de dañar al Pokémon.
    /// </summary>
    /// <param name="dano">Los puntos de vida que se le quitan al Pokémon.</param>
    public void RecibirDano(int dano)
    {
        this.VidaTotal -= dano;
    }
    
}
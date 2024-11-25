namespace Library;
/// <summary>
/// Esta es la clase SuperPocion. Hereda <see cref="Item"/> y agrega el método SuperPocionar
/// </summary>
public class SuperPocion: Item
{
    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="SuperPocion"/>.
    /// </summary>
    public SuperPocion()
    {
        this.Nombre = "SúperPoción";
        this.Descripcion = "Recupera 70 puntos de vida";
    }
  
    public override void Accion(Entrenador entrenador, Pokemon pokemon)
    {
        if (pokemon.VidaTotal + 70 <= pokemon.VidaInicial) 
            pokemon.Curar(70);
        else
        {
            pokemon.Curar(pokemon.VidaInicial - pokemon.VidaTotal);
        }
        entrenador.QuitarItem(this);
    }
}
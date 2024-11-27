namespace Library;
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
    public static void UsoDeItem(Entrenador entrenador, Item item, Pokemon pokemon)
    {
       item.Accion(entrenador, pokemon);
    }
}
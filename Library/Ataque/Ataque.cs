namespace Library;

public abstract class Ataque
{
    public string Nombre { get; protected set; }
    public Tipo Tipo { get; protected set; }
    public int Dano { get; protected set; }
}
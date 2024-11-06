namespace Library;

public abstract class Ataque
{
    public string Nombre { get; protected set; }
    public Tipo Tipo { get; protected set; }

    public string GetNombreTipo()
    {
        return Tipo.Nombre;
    }
    public int Dano { get; protected set; }
    public int Precision { get; protected set; }
}
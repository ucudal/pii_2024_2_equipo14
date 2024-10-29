namespace Library;

public abstract class Pokemon
{
    public string Nombre { get; protected set; }
    public Tipo Tipo { get; protected set; }
    public int VidaInicial {get { return 80; }}
    public int VidaTotal
    {
        get { return 80;}
        set { this.VidaTotal = value; }
    }
}
namespace Library;

public abstract class Tipo
{
    public string Nombre { get; protected set; }
    public List<Tipo> debilContra = new List<Tipo>();
    public List<Tipo> resistenteContra = new List<Tipo>();
    public List<Tipo> inmuneContra = new List<Tipo>();
}
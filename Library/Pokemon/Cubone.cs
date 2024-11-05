namespace Library;

public class Cubone: Pokemon
{
    public Cubone()
    {
        this.Nombre = "Cubone";
        this.Tipo = new Tierra();
        this.misAtaques.Add(new Terremoto());
        this.misAtaques.Add(new Zzz());
    }
}
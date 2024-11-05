namespace Library;

public class Snorlax: Pokemon
{
    public Snorlax()
    {
        this.Nombre = "Snorlax";
        this.Tipo = new Normal();
        this.misAtaques.Add(new Iceberg());
        this.misAtaques.Add(new Zzz());
    }
}
namespace Library;

public class Koffing: Pokemon
{
    public Koffing()
    {
        this.Nombre = "Koffing";
        this.Tipo = new Veneno();
        this.misAtaques.Add(new Mordisco());
        this.misAtaques.Add(new Off());
    }
}
namespace Library;

public class Caterpie: Pokemon
{
    public Caterpie()
    {
        this.Nombre = "Caterpie";
        this.Tipo = new Bicho();
        this.misAtaques.Add(new Mordisco());
        this.misAtaques.Add(new Off());
    }
}
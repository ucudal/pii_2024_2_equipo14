namespace Library;

public class Wurmple: Pokemon
{
    public Wurmple()
    {
        this.Nombre = "Wurmple";
        this.Tipo = new Bicho();
        this.misAtaques.Add(new Mordisco());
        this.misAtaques.Add(new Maniqui());
    }
}
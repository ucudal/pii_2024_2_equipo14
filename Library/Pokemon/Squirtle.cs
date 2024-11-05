namespace Library;

public class Squirtle: Pokemon
{
    public Squirtle()
    {
        this.Nombre = "Squirtle";
        this.Tipo = new Agua();
        this.misAtaques.Add(new Tsunami());
        this.misAtaques.Add(new Maniqui());
    }
}
namespace Library;

public class Psyduck: Pokemon
{
    public Psyduck()
    {
        this.Nombre = "Psyduck";
        this.Tipo = new Agua();
        this.misAtaques.Add(new Tsunami());
        this.misAtaques.Add(new Zzz());
    }
}
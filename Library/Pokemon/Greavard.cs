namespace Library;

public class Greavard: Pokemon
{
    public Greavard()
    {
        this.Nombre = "Greavard";
        this.Tipo = new Fantasma();
        this.misAtaques.Add(new Danza());
        this.misAtaques.Add(new Incendio());
    }
}
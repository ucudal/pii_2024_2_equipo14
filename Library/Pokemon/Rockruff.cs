namespace Library;

public class Rockruff: Pokemon
{
    public Rockruff()
    {
        this.Nombre = "Rockruff";
        this.Tipo = new Roca();
        this.misAtaques.Add(new Derrumbe());
        this.misAtaques.Add(new Incendio());
    }
}
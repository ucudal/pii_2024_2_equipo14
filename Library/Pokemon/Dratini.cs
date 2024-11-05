namespace Library;

public class Dratini: Pokemon
{
    public Dratini()
    {
        this.Nombre = "Dratini";
        this.Tipo = new Dragon();
        this.misAtaques.Add(new Volcan());
        this.misAtaques.Add(new Incendio());
    }
}
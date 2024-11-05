namespace Library;

public class Charmander: Pokemon
{
    public Charmander()
    {
        this.Nombre = "Charmander";
        this.Tipo = new Fuego();
        this.misAtaques.Add(new Volcan());
        this.misAtaques.Add(new Incendio());
    }
}
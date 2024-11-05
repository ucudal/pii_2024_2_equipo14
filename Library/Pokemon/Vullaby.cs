namespace Library;

public class Vullaby: Pokemon
{
    public Vullaby()
    {
        this.Nombre = "Vullaby";
        this.Tipo = new Volador();
        this.misAtaques.Add(new Viento());
        this.misAtaques.Add(new Incendio());
    }
}
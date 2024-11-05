namespace Library;

public class Vulpix: Pokemon
{
    public Vulpix()
    {
        this.Nombre = "Vulpix";
        this.Tipo = new Fuego();
        this.misAtaques.Add(new Derrumbe());
        this.misAtaques.Add(new Incendio());
    }
}
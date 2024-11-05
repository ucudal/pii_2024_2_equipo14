namespace Library;

public class Hielo: Tipo
{
    public Hielo()
    {
        this.Nombre = "Hielo";
        this.debilContra.Add(new Fuego());
        this.debilContra.Add(new Lucha());
        this.debilContra.Add(new Roca());
        this.resistenteContra.Add(new Hielo());
    }
}
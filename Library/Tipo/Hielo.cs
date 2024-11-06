namespace Library;

public class Hielo: Tipo
{
    public Hielo()
    {
        this.Nombre = "Hielo";
        this.debilContra.Add("Fuego");
        this.debilContra.Add("Lucha");
        this.debilContra.Add("Roca");
        this.resistenteContra.Add("Hielo");
    }
}
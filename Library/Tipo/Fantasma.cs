namespace Library;

public class Fantasma: Tipo
{
    public Fantasma()
    {
        this.Nombre = "Fantasma";
        this.debilContra.Add("Fantasma");
        this.resistenteContra.Add("Veneno");
        this.resistenteContra.Add("Lucha");
        this.resistenteContra.Add("Normal");
    }
}
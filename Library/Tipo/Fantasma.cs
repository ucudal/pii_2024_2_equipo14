namespace Library;

public class Fantasma: Tipo
{
    public Fantasma()
    {
        this.Nombre = "Fantasma";
        this.debilContra.Add(new Fantasma());
        this.resistenteContra.Add(new Veneno());
        this.resistenteContra.Add(new Lucha());
        this.resistenteContra.Add(new Normal());
    }
}
namespace Library;

public class Veneno: Tipo
{
    public Veneno()
    {
        this.Nombre = "Veneno";
        this.debilContra.Add(new Bicho());
        this.debilContra.Add(new Psiquico());
        this.debilContra.Add(new Tierra());
        this.debilContra.Add(new Lucha());
        this.debilContra.Add(new Planta());
        this.resistenteContra.Add(new Veneno());
    }
}
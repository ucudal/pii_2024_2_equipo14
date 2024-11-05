namespace Library;

public class Planta: Tipo
{
    public Planta()
    {
        this.Nombre = "Planta";
        this.debilContra.Add(new Bicho());
        this.debilContra.Add(new Fuego());
        this.debilContra.Add(new Hielo());
        this.debilContra.Add(new Veneno());
        this.debilContra.Add(new Volador());
        this.resistenteContra.Add(new Agua());
        this.resistenteContra.Add(new Electrico());
        this.resistenteContra.Add(new Planta());
        this.resistenteContra.Add(new Tierra());
    }
}
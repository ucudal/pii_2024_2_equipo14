namespace Library;

public class Tierra: Tipo
{
    public Tierra()
    {
        this.Nombre = "Tierra";
        this.debilContra.Add(new Agua());
        this.debilContra.Add(new Hielo());
        this.debilContra.Add(new Planta());
        this.debilContra.Add(new Roca());
        this.debilContra.Add(new Veneno());
        this.resistenteContra.Add(new Electrico());
    }
}
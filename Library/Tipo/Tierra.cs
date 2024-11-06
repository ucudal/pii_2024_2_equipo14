namespace Library;

public class Tierra: Tipo
{
    public Tierra()
    {
        this.Nombre = "Tierra";
        this.debilContra.Add("Agua");
        this.debilContra.Add("Hielo");
        this.debilContra.Add("Planta");
        this.debilContra.Add("Roca");
        this.debilContra.Add("Veneno");
        this.resistenteContra.Add("Electrico");
    }
}
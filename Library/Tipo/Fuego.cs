namespace Library;

public class Fuego: Tipo
{
    public Fuego()
    {
        this.Nombre = "Fuego";
        this.debilContra.Add("Agua");
        this.debilContra.Add("Roca");
        this.debilContra.Add("Tierra");
        this.resistenteContra.Add("Bicho");
        this.resistenteContra.Add("Fuego");
        this.resistenteContra.Add("Planta");
    }
}
namespace Library;

public class Bicho: Tipo
{
    public Bicho()
    {
        this.Nombre = "Bicho";
        this.debilContra.Add("Fuego");
        this.debilContra.Add("Roca");
        this.debilContra.Add("Volador");
        this.debilContra.Add("Veneno");
        this.resistenteContra.Add("Lucha");
        this.resistenteContra.Add("Planta");
        this.resistenteContra.Add("Tierra");
    }
}
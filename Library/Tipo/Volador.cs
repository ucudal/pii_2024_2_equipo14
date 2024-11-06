namespace Library;

public class Volador: Tipo
{
    public Volador()
    {
        this.Nombre = "Volador";
        this.debilContra.Add("Eléctrico");
        this.debilContra.Add("Hielo");
        this.debilContra.Add("Roca");
        this.resistenteContra.Add("Bicho");
        this.resistenteContra.Add("Lucha");
        this.resistenteContra.Add("Planta");
        this.resistenteContra.Add("Tierra");
    }
}
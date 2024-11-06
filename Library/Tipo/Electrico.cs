namespace Library;

public class Electrico: Tipo
{
    public Electrico()
    {
        this.Nombre = "Eléctrico";
        this.debilContra.Add("Tierra");
        this.resistenteContra.Add("Volador");
        this.inmuneContra.Add("Electrico");
    }
}
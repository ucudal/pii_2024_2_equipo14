namespace Library;

public class Agua: Tipo
{
    public Agua()
    {
        this.Nombre = "Agua";
        this.debilContra.Add("Eléctrico");
        this.debilContra.Add("Planta");
        this.resistenteContra.Add("Agua");
        this.resistenteContra.Add("Fuego");
        this.resistenteContra.Add("Hielo");
    }
}
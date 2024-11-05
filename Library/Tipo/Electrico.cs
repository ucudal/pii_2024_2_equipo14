namespace Library;

public class Electrico: Tipo
{
    public Electrico()
    {
        this.Nombre = "Eléctrico";
        this.debilContra.Add(new Tierra());
        this.resistenteContra.Add(new Volador());
        this.inmuneContra.Add(new Electrico());
    }
}
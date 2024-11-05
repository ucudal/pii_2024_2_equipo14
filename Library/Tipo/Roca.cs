namespace Library;

public class Roca: Tipo
{
    public Roca()
    {
        this.Nombre = "Roca";
        this.debilContra.Add(new Agua());
        this.debilContra.Add(new Lucha());
        this.debilContra.Add(new Planta());
        this.debilContra.Add(new Tierra());
        this.resistenteContra.Add(new Fuego());
        this.resistenteContra.Add(new Normal());
        this.resistenteContra.Add(new Veneno());
        this.resistenteContra.Add(new Volador());
    }
}
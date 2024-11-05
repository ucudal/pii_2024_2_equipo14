namespace Library;

public class Bicho: Tipo
{
    public Bicho()
    {
        this.Nombre = "Bicho";
        this.debilContra.Add(new Fuego());
        this.debilContra.Add(new Roca());
        this.debilContra.Add(new Volador());
        this.debilContra.Add(new Veneno());
        this.resistenteContra.Add(new Lucha());
        this.resistenteContra.Add(new Planta());
        this.resistenteContra.Add(new Tierra());
    }
}
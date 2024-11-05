namespace Library;

public class Volador: Tipo
{
    public Volador()
    {
        this.Nombre = "Volador";
        this.debilContra.Add(new Electrico());
        this.debilContra.Add(new Hielo());
        this.debilContra.Add(new Roca());
        this.resistenteContra.Add(new Bicho());
        this.resistenteContra.Add(new Lucha());
        this.resistenteContra.Add(new Planta());
        this.resistenteContra.Add(new Tierra());
    }
}
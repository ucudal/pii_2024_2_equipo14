namespace Library;

public class Fuego: Tipo
{
    public Fuego()
    {
        this.Nombre = "Fuego";
        this.debilContra.Add(new Agua());
        this.debilContra.Add(new Roca());
        this.debilContra.Add(new Tierra());
        this.resistenteContra.Add(new Bicho());
        this.resistenteContra.Add(new Fuego());
        this.resistenteContra.Add(new Planta());
    }
}
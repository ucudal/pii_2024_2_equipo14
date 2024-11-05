namespace Library;

public class Agua: Tipo
{
    public Agua()
    {
        this.Nombre = "Agua";
        this.debilContra.Add(new Electrico());
        this.debilContra.Add(new Planta());
        this.resistenteContra.Add(new Agua());
        this.resistenteContra.Add(new Fuego());
        this.resistenteContra.Add(new Hielo());
    }
}
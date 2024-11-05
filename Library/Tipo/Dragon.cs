namespace Library;

public class Dragon: Tipo
{
    public Dragon()
    {
        this.Nombre = "Dragón";
        this.debilContra.Add(new Dragon());
        this.debilContra.Add(new Hielo());
        this.resistenteContra.Add(new Agua());
        this.resistenteContra.Add(new Electrico());
        this.resistenteContra.Add(new Fuego());
        this.resistenteContra.Add(new Planta());
    }
}
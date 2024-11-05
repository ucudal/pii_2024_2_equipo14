namespace Library;

public class Incendio: AtaqueEspecial
{
    public Incendio()
    {
        this.Nombre = "Incendio";
        this.Tipo = new Fuego();
        this.Dano = 45;
        this.Efecto = "Quemar";
        //agregar efecto quemar
    }
}
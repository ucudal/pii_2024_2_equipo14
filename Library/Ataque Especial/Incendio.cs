namespace Library;

public class Incendio: AtaqueEspecial
{
    public Incendio()
    {
        this.Nombre = "Incendio";
        this.Tipo = new Fuego();
        this.Dano = 45;
        this.Precision = 70;
        this.Efecto = "Quemar";
    }

    public static void Quemar(Pokemon pokemon)
    {
        if (pokemon.Quemado == false)
        {
            pokemon.Quemado = true;
        }
    }
}
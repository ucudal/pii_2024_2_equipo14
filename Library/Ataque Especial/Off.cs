namespace Library;

public class Off: AtaqueEspecial
{
    public Off()
    {
        this.Nombre = "Off";
        this.Tipo = new Veneno();
        this.Dano = 30;
        this.Precision = 90;
        this.Efecto = "Envenenar";
    }
    public static void Envenenar(Pokemon pokemon)
    {
        if (pokemon.Envenenado == false)
        {
            pokemon.Envenenado = true;
            pokemon.RecibirDano(pokemon.VidaTotal*5/100);
        }
    }
}
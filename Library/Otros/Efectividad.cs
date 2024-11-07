namespace Library;

public static class Efectividad
{
    public static int CalcularEfectividad(Ataque ataque, Pokemon pokemon)
    {
        int danoFinal = 0;
        if (pokemon.GetDebilContra().Contains(ataque.Tipo))
        {
            danoFinal = ataque.Dano*2;
        }
        if (pokemon.GetResistenteContra().Contains(ataque.Tipo))
        {
            danoFinal = ataque.Dano / 2;
        }
        return danoFinal;
    }
}
namespace Library;

public class Efectividad
{
    public void CalcularEfectividad(Ataque ataque, Pokemon pokemon)
    {
        if (pokemon.GetDebilContra().Contains(ataque.Tipo))
        {
            pokemon.RecibirDano(ataque.Dano*2);
        }
        if (pokemon.GetResistenteContra().Contains(ataque.Tipo))
        {
            pokemon.RecibirDano(ataque.Dano/2);
        }
        if (pokemon.GetInmuneContra().Contains(ataque.Tipo))
        { 
            pokemon.RecibirDano(0);  
        }
    }
}
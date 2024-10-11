namespace PokemonP2;

public interface IPokemon
{
    string Nombre { get;}
    ITipo Tipo { get;}
    int VidaInicial { get;}
    int VidaTotal { get; set; }
    int Dano { get; }
}
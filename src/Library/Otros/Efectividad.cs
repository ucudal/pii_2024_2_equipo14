namespace Library;

/// <summary>
/// Esta es la clase estática Efectividad. Se encarga de calcular la efectividad del ataque que recibe.
/// </summary>
public static class Efectividad
{
    /// <summary>
    /// Calcula qué tan efectivo es el ataque que recibe según su tipo y el tipo del Pokémon atacado.
    /// </summary>
    /// <param name="ataque">El ataque que se está utilizando.</param>
    /// <param name="pokemon">El Pokémon que está siendo atacado.</param>
    public static int CalcularEfectividad(Ataque ataque, Pokemon pokemon)
    {
        if (debilContra[pokemon.Tipo].Contains(ataque.Tipo))
        {
            return ataque.Dano * 2;
        }
        if (resistenteContra.ContainsKey(pokemon.Tipo))
        {
            if (resistenteContra[pokemon.Tipo].Contains(ataque.Tipo))
            {
                return ataque.Dano / 2;
            }
        }
        if (inmuneContra.ContainsKey(pokemon.Tipo))
        {
            if (inmuneContra[pokemon.Tipo] == ataque.Tipo)
            {
                return 0;
            }
        }
        return ataque.Dano;
    }

    private static Dictionary<string, List<string>> debilContra = new Dictionary<string, List<string>>
    {
        {"Agua", new List<string> {"Eléctrico","Planta"}}, 
        {"Bicho",new List<string>{"Fuego","Roca","Volador","Veneno"}},
        {"Dragón",new List<string>{"Dragón","Hielo"}},
        {"Eléctrico",new List<string>{"Tierra"}},
        {"Fantasma",new List<string>{"Fantasma"}},
        {"Fuego",new List<string>{"Agua","Roca","Tierra"}},
        {"Hielo",new List<string>{"Fuego","Lucha","Roca"}},
        {"Lucha",new List<string>{"Psíquico","Volador","Bicho","Roca"}},
        {"Normal",new List<string>{"Lucha"}},
        {"Planta",new List<string>{"Bicho","Fuego","Hielo","Veneno","Volador"}},
        {"Psíquico",new List<string>{"Bicho","Lucha","Fantasma"}},
        {"Roca",new List<string>{"Agua","Lucha","Planta","Tierra"}},
        {"Tierra",new List<string>{"Agua","Hielo","Planta","Roca","Veneno"}},
        {"Veneno",new List<string>{"Bicho","Psíquico","Tierra","Lucha"}},
        {"Volador",new List<string>{"Eléctrico","Hielo","Roca"}},
    };
    private static Dictionary<string, List<string>> resistenteContra = new Dictionary<string, List<string>>
    {
        {"Agua", new List<string> {"Agua","Fuego","Hielo"}}, 
        {"Bicho",new List<string>{"Lucha","Planta","Tierra"}},
        {"Dragón",new List<string>{"Agua","Eléctrico","Fuego","Planta"}},
        {"Eléctrico",new List<string>{"Volador"}},
        {"Fantasma",new List<string>{"Veneno","Lucha","Normal"}},
        {"Fuego",new List<string>{"Bicho","Fuego","Planta"}},
        {"Hielo",new List<string>{"Hielo"}},
        {"Planta",new List<string>{"Agua","Eléctrico","Planta","Tierra"}},
        {"Roca",new List<string>{"Fuego","Normal","Veneno","Volador"}},
        {"Tierra",new List<string>{"Eléctrico"}},
        {"Veneno",new List<string>{"Planta","Veneno"}},
        {"Volador",new List<string>{"Bicho","Lucha","Planta","Tierra"}},
    };

    private static Dictionary<string, string> inmuneContra = new Dictionary<string, string>
    {
        { "Eléctrico", "Eléctrico" },
        { "Normal", "Fantasma" }
    };
}
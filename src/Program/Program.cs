﻿using System;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido al juego de Pokémon!");

            // Solicitar nombres de los jugadores
            Console.Write("Ingresa el nombre del Jugador 1: ");
            string nombreJugador1 = Console.ReadLine();
            Console.Write("Ingresa el nombre del Jugador 2: ");
            string nombreJugador2 = Console.ReadLine();

            // Crear la fachada del juego
            Facade juego = new Facade(nombreJugador1, nombreJugador2);

            // Comenzar la batalla
            juego.ComenzarBatalla();

            // Aquí puedes agregar más lógica para continuar el juego, como turnos, acciones, etc.
            // Por ejemplo, puedes permitir que los jugadores realicen acciones en un bucle.
            while (true)
            {
                Console.WriteLine("¿Quieres continuar la batalla? (s/n)");
                string continuar = Console.ReadLine();
                if (continuar.ToLower() != "s")
                {
                    break;
                }
                
            }

            Console.WriteLine("Gracias por jugar!");
        }
    }
}


/*
 *using Ucu.Poo.DiscordBot.Domain;
using Ucu.Poo.DiscordBot.Services;

namespace Program;

/// <summary>
/// Un programa que implementa un bot de Discord.
/// </summary>
internal static class Program
{
    /// <summary>
    /// Punto de entrada al programa.
    /// </summary>
    private static void Main()
    {
        //DemoFacade();
         DemoBot();
    }

    private static void DemoFacade()
    {
        Console.WriteLine(Facade.Instance.AddTrainerToWaitingList("player"));
        Console.WriteLine(Facade.Instance.AddTrainerToWaitingList("opponent"));
        Console.WriteLine(Facade.Instance.GetAllTrainersWaiting());
        Console.WriteLine(Facade.Instance.StartBattle("player", "opponent"));
        Console.WriteLine(Facade.Instance.GetAllTrainersWaiting());
    }

    private static void DemoBot()
    {
        BotLoader.LoadAsync().GetAwaiter().GetResult();
    }
} 
 */
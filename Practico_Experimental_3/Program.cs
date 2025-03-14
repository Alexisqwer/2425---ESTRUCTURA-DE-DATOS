using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace RegistroTorneoFutbol
{
    // Clase que representa un jugador
    public class Jugador
    {
        public string Nombre { get; set; }
        public int Numero { get; set; } // Número de camiseta

        public Jugador(string nombre, int numero)
        {
            Nombre = nombre;
            Numero = numero;
        }

        public override string ToString()
        {
            return $"Jugador: {Nombre}, Número: {Numero}";
        }

        // Sobreescritura de Equals y GetHashCode para garantizar la unicidad en el HashSet
        public override bool Equals(object obj)
        {
            if (obj is Jugador otroJugador)
                return Nombre.Equals(otroJugador.Nombre) && Numero == otroJugador.Numero;
            return false;
        }
        public override int GetHashCode()
        {
            return Nombre.GetHashCode() ^ Numero.GetHashCode();
        }
    }

    // Clase que representa un equipo de fútbol
    public class Equipo
    {
        public string NombreEquipo { get; set; }
        // Uso de HashSet para evitar duplicados en el registro de jugadores
        public HashSet<Jugador> Jugadores { get; set; }

        public Equipo(string nombreEquipo)
        {
            NombreEquipo = nombreEquipo;
            Jugadores = new HashSet<Jugador>();
        }

        // Método para agregar un jugador al equipo
        public void AgregarJugador(Jugador jugador)
        {
            if (!Jugadores.Add(jugador))
            {
                Console.WriteLine($"El jugador {jugador.Nombre} con número {jugador.Numero} ya está registrado en el equipo {NombreEquipo}.");
            }
        }

        public override string ToString()
        {
            return $"Equipo: {NombreEquipo} - Total Jugadores: {Jugadores.Count}";
        }
    }

    // Clase que representa el torneo y utiliza un Dictionary para gestionar los equipos
    public class Torneo
    {
        // El mapa asocia el nombre del equipo a la instancia de Equipo
        public Dictionary<string, Equipo> Equipos { get; set; }

        public Torneo()
        {
            Equipos = new Dictionary<string, Equipo>();
        }

        // Método para agregar un equipo al torneo
        public void AgregarEquipo(Equipo equipo)
        {
            if (!Equipos.ContainsKey(equipo.NombreEquipo))
            {
                Equipos.Add(equipo.NombreEquipo, equipo);
            }
            else
            {
                Console.WriteLine($"El equipo {equipo.NombreEquipo} ya está registrado en el torneo.");
            }
        }

        // visualización de equipos y sus jugadores
        public void ReporteEquipos()
        {
            Console.WriteLine("----- Reporte de Equipos -----");
            foreach (var equipo in Equipos.Values)
            {
                Console.WriteLine(equipo.ToString());
                foreach (var jugador in equipo.Jugadores)
                {
                    Console.WriteLine("\t" + jugador.ToString());
                }
            }
            Console.WriteLine("------------------------------");
        }
    }

    // Clase principal del programa
    class Program
    {
        static void Main(string[] args)
        {
            // Inicio del contador para medir el tiempo de ejecución
            Stopwatch stopwatch = Stopwatch.StartNew();

            // Creación del torneo
            Torneo torneo = new Torneo();

            // Registro inicial de equipos (pueden crearse de forma dinámica luego)
            Equipo equipo1 = new Equipo("Los Guerreros");
            Equipo equipo2 = new Equipo("Los Titanes");

            torneo.AgregarEquipo(equipo1);
            torneo.AgregarEquipo(equipo2);

            // Menú interactivo para agregar jugadores y consultar la reportería
            int opcion = 0;
            while (opcion != 3)
            {
                Console.WriteLine("\n--- Menú ---");
                Console.WriteLine("1. Agregar jugador a un equipo");
                Console.WriteLine("2. Mostrar reporte de equipos");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción: ");
                
                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Entrada no válida. Intente nuevamente.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        // Solicitar el nombre del equipo
                        Console.Write("Ingrese el nombre del equipo: ");
                        string nombreEquipo = Console.ReadLine();

                        // Verificar si el equipo existe
                        if (torneo.Equipos.ContainsKey(nombreEquipo))
                        {
                            AgregarJugadorAEquipo(torneo.Equipos[nombreEquipo]);
                        }
                        else
                        {
                            Console.Write($"El equipo '{nombreEquipo}' no existe. ¿Desea crearlo? (s/n): ");
                            string respuesta = Console.ReadLine();
                            if (respuesta.ToLower() == "s")
                            {
                                Equipo nuevoEquipo = new Equipo(nombreEquipo);
                                torneo.AgregarEquipo(nuevoEquipo);
                                AgregarJugadorAEquipo(nuevoEquipo);
                            }
                            else
                            {
                                Console.WriteLine("No se agregó ningún jugador.");
                            }
                        }
                        break;

                    case 2:
                        torneo.ReporteEquipos();
                        break;

                    case 3:
                        Console.WriteLine("Saliendo de la aplicación...");
                        break;

                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break;
                }
            }

            // Finalización del contador y visualización del tiempo de ejecución
            stopwatch.Stop();
            Console.WriteLine("Tiempo de ejecución: {0} ms", stopwatch.ElapsedMilliseconds);
            Console.WriteLine("Presione cualquier tecla para salir...");
            Console.ReadKey();
        }

        // Método auxiliar para solicitar los datos de un jugador y agregarlo al equipo indicado
        static void AgregarJugadorAEquipo(Equipo equipo)
        {
            Console.Write("Ingrese el nombre del jugador: ");
            string nombreJugador = Console.ReadLine();
            Console.Write("Ingrese el número del jugador: ");
            if (!int.TryParse(Console.ReadLine(), out int numero))
            {
                Console.WriteLine("Número inválido. Se cancelará la operación.");
                return;
            }
            Jugador jugador = new Jugador(nombreJugador, numero);
            equipo.AgregarJugador(jugador);
            Console.WriteLine("Jugador agregado correctamente al equipo " + equipo.NombreEquipo + ".");
        }
    }
}

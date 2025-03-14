using System;
using System.Collections.Generic;

class Programa
{
    // Lista que representa el catálogo de revistas
    static List<string> catalogo = new List<string>
    {
        "El Mundo",
        "Revista 5W",
        "Cultura Colectiva",
        "Memorias",
        "Matador",
        "Revista 15M",
        "Abanico veterinario",
        "Xataka",
        "Letras Libres",
        "Jot Down",
    };

    static void Main(string[] args)
    {
        bool salir = false;

        // Menú para interactuar con el programa
        while (!salir)
        {
            MostrarMenu(); // Mostrar las opciones
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    BuscarTitulo(); // Llamar al método de búsqueda
                    break;
                case "2":
                    salir = true; // Salir del programa
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }

    // Método que muestra las opciones del menú
    static void MostrarMenu()
    {
        Console.WriteLine("\n--- Menú ---");
        Console.WriteLine("1. Buscar título de revista");
        Console.WriteLine("2. Salir");
        Console.Write("Seleccione una opción: ");
    }

    // Método para buscar un título de revista en el catálogo
    static void BuscarTitulo()
    {
        Console.Write("Ingrese el título de la revista a buscar: ");
        string titulo = Console.ReadLine();
        bool encontrado = BusquedaRecursiva(catalogo, titulo); // Llamar a la búsqueda recursiva
        Console.WriteLine(encontrado ? "Título encontrado." : "Título no encontrado.");
    }

    // Método de búsqueda recursiva
    static bool BusquedaRecursiva(List<string> catalogo, string titulo, int indice = 0)
    {
        // Si llegamos al final de la lista y no encontramos el título
        if (indice >= catalogo.Count) return false;

        // Si encontramos el título
        if (string.Equals(catalogo[indice], titulo, StringComparison.OrdinalIgnoreCase)) return true;

        // Llamada recursiva a la siguiente revista en el catálogo
        return BusquedaRecursiva(catalogo, titulo, indice + 1);
    }
}
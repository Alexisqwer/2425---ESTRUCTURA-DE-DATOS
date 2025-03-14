using System;
using System.Collections.Generic;

class Traductor
{
    // Diccionario con las palabras base
    static Dictionary<string, string> diccionario = new Dictionary<string, string>()
    {
        { "tiempo", "time" },
        { "persona", "person" },
        { "año", "year" },
        { "camino", "way" },
        { "forma", "way" },
        { "día", "day" },
        { "cosa", "thing" },
        { "hombre", "man" },
        { "mundo", "world" },
        { "vida", "life" },
        { "mano", "hand" },
        { "parte", "part" },
        { "niño", "child" },
        { "ojo", "eye" },
        { "mujer", "woman" },
        { "lugar", "place" },
        { "trabajo", "work" },
        { "semana", "week" },
        { "caso", "case" },
        { "punto", "point" },
        { "tema", "point" },
        { "gobierno", "government" },
        { "empresa", "company" },
        { "compañía", "company" }
    };

    static void Main(string[] args)
    {
        bool continuar = true;

        while (continuar)
        {
            Console.Clear();
            MostrarMenu();
            int opcion = ObtenerOpcion();

            switch (opcion)
            {
                case 1:
                    TraducirFrase();
                    break;
                case 2:
                    AgregarPalabra();
                    break;
                case 0:
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, elija una opción válida.");
                    break;
            }
        }
    }

    static void MostrarMenu()
    {
        Console.WriteLine("MENU");
        Console.WriteLine("=======================================================");
        Console.WriteLine("1. Traducir una frase");
        Console.WriteLine("2. Ingresar más palabras al diccionario");
        Console.WriteLine("0. Salir");
        Console.Write("Seleccione una opción: ");
    }

    static int ObtenerOpcion()
    {
        int opcion;
        while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 0 || opcion > 2)
        {
            Console.Write("Opción no válida. Por favor, seleccione una opción: ");
        }
        return opcion;
    }

    static void TraducirFrase()
    {
        Console.Write("Ingrese la frase: ");
        string frase = Console.ReadLine();
        string[] palabras = frase.Split(new char[] { ' ', ',', '.', ';', ':', '?' }, StringSplitOptions.RemoveEmptyEntries);
        string fraseTraducida = "";

        foreach (var palabra in palabras)
        {
            if (diccionario.ContainsKey(palabra.ToLower()))
            {
                fraseTraducida += diccionario[palabra.ToLower()] + " ";
            }
            else
            {
                fraseTraducida += palabra + " ";
            }
        }

        Console.WriteLine("Su frase traducida es: " + fraseTraducida.Trim());
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    static void AgregarPalabra()
    {
        Console.Write("Ingrese la palabra en español: ");
        string espanol = Console.ReadLine().ToLower();

        if (diccionario.ContainsKey(espanol))
        {
            Console.WriteLine("La palabra ya existe en el diccionario.");
        }
        else
        {
            Console.Write("Ingrese la traducción en inglés: ");
            string ingles = Console.ReadLine().ToLower();
            diccionario.Add(espanol, ingles);
            Console.WriteLine("Palabra agregada correctamente.");
        }

        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }
}

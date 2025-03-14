using System;
using System.Collections.Generic;

class Traductor
{
    // Diccionario con algunas palabras en español e inglés
    static Dictionary<string, string> diccionario = new Dictionary<string, string>()
    {
        {"hola", "hello"},
        {"familia","family"},
        {"amigo","friend"},
        {"casa","house"},
        {"perro","dog"},
        {"gato","cat"},
        {"rojo","red"},
        {"libro","book"},
        {"sol","sun"},
        {"luna","moon"},
        {"agua","water"},
        {"fuego","fire"},
        {"aire","air"},
        {"tierra","earth"},
        {"cielo","sky"},
        {"nube","cloud"},
        {"arbol","tree"},
        {"flor","flower"},
        {"fruta","fruit"},
        {"verde","green"},
        {"azul","blue"},
        {"amarillo","yellow"},
        {"blanco","white"},
        {"mundo", "world"},
        {"adios", "goodbye"}
    };

    static void Main(string[] args)
    {
        bool seguir = true; // Variable para controlar el ciclo del menú

        // Bucle principal que se ejecuta mientras seguir sea verdadero
        while (seguir)
        {
            Console.Clear();  // Limpiar la pantalla para mostrar el menú
            MostrarMenu();    // Llama al método para mostrar el menú
            int opcion = ObtenerOpcion(); // Obtiene la opción seleccionada por el usuario

            // Dependiendo de la opción seleccionada, ejecuta una acción
            switch (opcion)
            {
                case 1:
                    TraducirFrase();  // Traducir una frase
                    break;
                case 2:
                    AgregarPalabra();  // Agregar una nueva palabra al diccionario
                    break;
                case 0:
                    seguir = false;  // Salir del programa si se elige la opción 0
                    break;
                default:
                    // Si la opción es inválida, mostramos un mensaje de error
                    Console.WriteLine("Opción no válida. Por favor, elija una opción válida.");
                    break;
            }
        }
    }

    // Método que muestra el menú de opciones al usuario
    static void MostrarMenu()
    {
        Console.WriteLine("MENÚ");
        Console.WriteLine("=======================================================");
        Console.WriteLine("1. Traducir una frase");
        Console.WriteLine("2. Ingresar más palabras al diccionario");
        Console.WriteLine("0. Salir");
        Console.Write("Seleccione una opción: ");
    }

    // Método que obtiene la opción seleccionada por el usuario
    static int ObtenerOpcion()
    {
        int opcion;
        // Verificamos que la opción ingresada sea un número válido entre 0 y 2
        while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 0 || opcion > 2)
        {
            Console.Write("Opción no válida. Por favor, seleccione una opción (0, 1 o 2): ");
        }
        return opcion;
    }

    // Método que traduce una frase ingresada por el usuario
    static void TraducirFrase()
    {
        Console.Write("Ingrese la frase a traducir: ");
        string frase = Console.ReadLine();  // Leemos la frase ingresada por el usuario
        // Divide la frase ingresada en palabras, eliminando espacios y signos de puntuación, y omitiendo entradas vacías
        string[] palabras = frase.Split(new char[] { ' ', ',', '.', ';', ':', '?' }, StringSplitOptions.RemoveEmptyEntries);
        string fraseTraducida = ""; // Variable para almacenar la frase traducida
        bool hayTraduccion = false; // Variable para verificar si se encontró alguna traducción

        // Itera sobre las palabras de la frase
        foreach (var palabra in palabras)
        {
            // Convertimos la palabra a minúsculas para comparar, sin importar si el usuario usa mayúsculas
            string palabraMinuscula = palabra.ToLower();

            // Si la palabra existe en el diccionario, la traducimos
            if (diccionario.ContainsKey(palabraMinuscula))
            {
                fraseTraducida += diccionario[palabraMinuscula] + " "; // Agrega la traducción
                hayTraduccion = true; // Se encontró una traducción
            }
            else
            {
                // Si no existe en el diccionario, indicamos que no está en el diccionario
                fraseTraducida += $"La palabra '{palabra}' no existe en el diccionario"; // Muestra el mensaje cuando la palabra no existe
                hayTraduccion = true; // Al menos se ha encontrado una palabra que no existe
            }
        }

        // Si hay traducción (al menos una palabra traducida o no encontrada), mostramos la frase traducida
        if (hayTraduccion)
        {
            Console.WriteLine(fraseTraducida.Trim());
        }

        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();  // Esperamos que el usuario presione una tecla para continuar
    }

    // Método que permite agregar una palabra al diccionario
    static void AgregarPalabra()
    {
        Console.Write("Ingrese la palabra en español: ");
        string espanol = Console.ReadLine().ToLower();  // Lee la palabra en español (en minúsculas)

        // Verifica si la palabra ya existe en el diccionario
        if (diccionario.ContainsKey(espanol))
        {
            Console.WriteLine("La palabra ya existe en el diccionario.");
        }
        else
        {
            // Si la palabra no existe, pedimos su traducción al inglés
            Console.Write("Ingrese la traducción en inglés: ");
            string ingles = Console.ReadLine().ToLower();  // Lee la traducción en inglés
            diccionario.Add(espanol, ingles);  // Agrega la palabra al diccionario
            Console.WriteLine("Palabra agregada correctamente.");
        }

        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();  // Esperamos que el usuario presione una tecla para continuar
    }
}

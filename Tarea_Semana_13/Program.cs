class Program  // Define la clase principal que contiene el método Main.
{
    static void Main(string[] args)  // Método principal donde inicia la ejecución del programa.
    {
        // Se crea una instancia de la clase ArbolBinario para almacenar los títulos de revistas.
        ArbolBinario catalogo = new ArbolBinario();

        // Se define un arreglo de cadenas con los títulos de revistas que se agregarán al árbol binario.
        string[] titulos = {
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

        // Se recorren los títulos y se agregan uno por uno al árbol binario usando el método Agregar.
        foreach (var titulo in titulos)
        {
            catalogo.Agregar(titulo);
        }

        // Bucle infinito para mostrar un menú interactivo al usuario.
        while (true)
        {
            // Se muestra el menú de opciones.
            Console.WriteLine("\n--- Catálogo de Revistas ---");
            Console.WriteLine("1. Buscar un título");
            Console.WriteLine("2. Salir");
            Console.Write("Seleccione una opción: ");
            
            // Se lee la opción ingresada por el usuario.
            string opcion = Console.ReadLine();

            if (opcion == "1")  // Si el usuario elige la opción 1, se inicia la búsqueda de una revista.
            {
                Console.WriteLine("Ingrese el título de la revista que desea buscar:");
                
                // Se lee el título que el usuario quiere buscar.
                string tituloABuscar = Console.ReadLine();

                // Se usa el método Buscar para ver si el título está en el árbol binario.
                if (catalogo.Buscar(tituloABuscar))
                {
                    Console.WriteLine("Encontrado");  // Si se encuentra en el árbol, se muestra este mensaje.
                }
                else
                {
                    Console.WriteLine("No encontrado");  // Si no se encuentra, se informa al usuario.
                }
            }
            else if (opcion == "2")  // Si el usuario elige la opción 2, se sale del programa.
            {
                Console.WriteLine("Saliendo del programa...");
                break;  // Se rompe el bucle infinito, terminando el programa.
            }
            else  // Si el usuario ingresa una opción inválida.
            {
                Console.WriteLine("Opción no válida. Intente de nuevo.");
            }
        }
    }
}

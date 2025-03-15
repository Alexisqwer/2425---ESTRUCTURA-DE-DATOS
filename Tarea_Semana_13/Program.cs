class Program
{
    static void Main(string[] args)
    {
        ArbolBinario catalogo = new ArbolBinario();
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

        // Agregar títulos al catálogo
        foreach (var titulo in titulos)
        {
            catalogo.Agregar(titulo);
        }

        // Menú de búsqueda
        while (true)
        {
            Console.WriteLine("\n--- Catálogo de Revistas ---");
            Console.WriteLine("1. Buscar un título");
            Console.WriteLine("2. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            if (opcion == "1")
            {
                Console.WriteLine("Ingrese el título de la revista que desea buscar:");
                string tituloABuscar = Console.ReadLine();

                if (catalogo.Buscar(tituloABuscar))
                {
                    Console.WriteLine("Encontrado");
                }
                else
                {
                    Console.WriteLine("No encontrado");
                }
            }
            else if (opcion == "2")
            {
                Console.WriteLine("Saliendo del programa...");
                break;
            }
            else
            {
                Console.WriteLine("Opción no válida. Intente de nuevo.");
            }
        }
    }
}
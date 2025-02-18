//using System;
//using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Crear una lista de 500 ciudadanos ficticios
        HashSet<string> ciudadanos = new HashSet<string>();
        for (int i = 1; i <= 500; i++)
        {
            ciudadanos.Add("Ciudadano " + i); // "Ciudadano 1" hasta "Ciudadano 500"
        }

        // Crear listas de vacunados con Pfizer y AstraZeneca
        HashSet<string> vacunadosPfizer = new HashSet<string>();
        HashSet<string> vacunadosAstraZeneca = new HashSet<string>();

        // Los primeros 78 ciudadanos están vacunados con Pfizer
        for (int i = 1; i <= 78; i++)
        {
            vacunadosPfizer.Add("Ciudadano " + i);
        }

        // Los siguientes 70 ciudadanos están vacunados con AstraZeneca
        for (int i = 81; i <= 150; i++)
        {
            vacunadosAstraZeneca.Add("Ciudadano " + i);
        }
        // Los siguientes 50 ciudadanos están vacunados con las dos vacunas
        for (int i = 151; i <= 200; i++)
        {
            vacunadosPfizer.Add("Ciudadano " + i);
            vacunadosAstraZeneca.Add("Ciudadano " + i);
        }

        // Obtener los distintos grupos de ciudadanos

        // Ciudadanos no vacunados: Son aquellos que no están en ningún conjunto de vacunados.
        var noVacunados = ciudadanos.Except(vacunadosPfizer.Concat(vacunadosAstraZeneca)).ToList();

        // Ciudadanos vacunados con ambas vacunas: Intersección de los conjuntos Pfizer y AstraZeneca.
        var vacunadosAmbas = vacunadosPfizer.Intersect(vacunadosAstraZeneca).ToList();

        // Ciudadanos vacunados solo con Pfizer: Aquellos que están en Pfizer pero no en AstraZeneca.
        var soloPfizer = vacunadosPfizer.Except(vacunadosAstraZeneca).ToList();

        // Ciudadanos vacunados solo con AstraZeneca: Aquellos que están en AstraZeneca pero no en Pfizer.
        var soloAstraZeneca = vacunadosAstraZeneca.Except(vacunadosPfizer).ToList();
        
        // Mostrar los ciudadanos no vacunados
        Console.WriteLine("\n");
        Console.WriteLine("Reporte de Vacunación");
        Console.WriteLine("--------------------------");
        Console.WriteLine("Ciudadanos no vacunados: ");
        Console.WriteLine("--------------------------");
        foreach (var ciudadano in noVacunados)
        {
            Console.WriteLine(ciudadano); // Imprime cada ciudadano no vacunado
        }
        Console.WriteLine("**********************************");
        Console.WriteLine($"Total de ciudadanos no vacunados: {noVacunados.Count}");
        Console.WriteLine("**********************************");

        // Mostrar los ciudadanos vacunados con ambas vacunas
        Console.WriteLine("\n--------------------------------------");
        Console.WriteLine("Ciudadanos vacunados con ambas vacunas: ");
        Console.WriteLine("--------------------------------------");
        foreach (var ciudadano in vacunadosAmbas)
        {
            Console.WriteLine(ciudadano); // Imprime cada ciudadano vacunado con ambas vacunas
        }

        // Muestra en consola debajo de cada lista de los ciudadanos cuantos se vacunaron con ambas vacunas
        Console.WriteLine("*************************************************");
        Console.WriteLine($"Total de ciudadanos vacunados con ambas vacunas: {vacunadosAmbas.Count}");
        Console.WriteLine("*************************************************");

        // Mostrar los ciudadanos vacunados solo con Pfizer
        Console.WriteLine("\n------------------------------------");
        Console.WriteLine("Ciudadanos vacunados solo con Pfizer: ");
        Console.WriteLine("------------------------------------");
        foreach (var ciudadano in soloPfizer)
        {
            Console.WriteLine(ciudadano); // Imprime cada ciudadano vacunado solo con Pfizer
        }

        // Muestra en consola debajo de cada lista de los ciudadanos cuantos se vacunaron solo con Pfizer
        Console.WriteLine("***********************************************");
        Console.WriteLine($"Total de ciudadanos vacunados solo con Pfizer: {soloPfizer.Count}");
        Console.WriteLine("***********************************************");

        // Mostrar los ciudadanos vacunados solo con AstraZeneca
        Console.WriteLine("\n-----------------------------------------");
        Console.WriteLine("Ciudadanos vacunados solo con AstraZeneca: ");
        Console.WriteLine("-----------------------------------------");
        foreach (var ciudadano in soloAstraZeneca)
        {
            Console.WriteLine(ciudadano); // Imprime cada ciudadano vacunado solo con AstraZeneca
        }

        // Muestra en consola debajo de cada lista de los ciudadanos cuantos se vacunaron solo con AstraZeneca
        Console.WriteLine("****************************************************");
        Console.WriteLine($"Total de ciudadanos vacunados solo con AstraZeneca: {soloAstraZeneca.Count}");
        Console.WriteLine("****************************************************");

        // Calcular el total de ciudadanos vacunados (suma de los distintos grupos)
        int totalVacunados = vacunadosAmbas.Count + soloPfizer.Count + soloAstraZeneca.Count;

        // Mostrar el total de vacunados en un reporte final
        Console.WriteLine("\n--------------------------------");
        Console.WriteLine("Reporte Final de Vacunación");
        Console.WriteLine("--------------------------------");
        Console.WriteLine($"Total de ciudadanos vacunados con ambas vacunas: {vacunadosAmbas.Count}");
        Console.WriteLine($"Total de ciudadanos vacunados solo con Pfizer: {soloPfizer.Count}");
        Console.WriteLine($"Total de ciudadanos vacunados solo con AstraZeneca: {soloAstraZeneca.Count}");
        Console.WriteLine($"Total de ciudadanos no vacunados: {noVacunados.Count}");
        Console.WriteLine($"Total de ciudadanos vacunados (todas categorías): {totalVacunados}");

        // Fin del proceso
        Console.WriteLine("\nProceso completado.");
    }
}

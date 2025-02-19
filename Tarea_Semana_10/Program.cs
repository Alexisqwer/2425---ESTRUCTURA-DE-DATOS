using System;
using System.Collections.Generic;
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

        // Los primeros 75 ciudadanos están vacunados con Pfizer (Ciudadano 1 a Ciudadano 75)
        for (int i = 1; i <= 75; i++)
        {
            vacunadosPfizer.Add("Ciudadano " + i);
        }

        // Para lograr la intersección, se asignamos a AstraZeneca 
        // a ciudadanos con rango que se en cuentre en el rango de Pfizer,
        // del 50 al 124.
        for (int i = 50; i <= 124; i++)
        {
            vacunadosAstraZeneca.Add("Ciudadano " + i);
        }
       
        // Operaciones de conjuntos:

        // Ciudadanos no vacunados: aquellos que NO están en ningún conjunto de vacunados.
        var noVacunados = ciudadanos.Except(vacunadosPfizer.Union(vacunadosAstraZeneca)).ToList();

        // Ciudadanos vacunados con ambas vacunas: intersección de los conjuntos Pfizer y AstraZeneca.
        HashSet<string> tempo = new HashSet<string>(vacunadosPfizer.Intersect(vacunadosAstraZeneca));

        // Ciudadanos vacunados solo con Pfizer: los que están en Pfizer pero no en AstraZeneca.
        var soloPfizer = vacunadosPfizer.Except(vacunadosAstraZeneca).ToList();

        // Ciudadanos vacunados solo con AstraZeneca: los que están en AstraZeneca pero no en Pfizer.
        var soloAstraZeneca = vacunadosAstraZeneca.Except(vacunadosPfizer).ToList();
        
        // Reporte de vacunación:
        Console.WriteLine("\nReporte de Vacunación");
        Console.WriteLine("--------------------------");
        
        Console.WriteLine("Ciudadanos no vacunados (A - (B ∪ C)):");
        Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
        foreach (var ciudadano in noVacunados)
        {
            Console.WriteLine(ciudadano);
        }
        Console.WriteLine("**********************************");
        Console.WriteLine($"Total de ciudadanos no vacunados: {noVacunados.Count}");
        Console.WriteLine("**********************************\n");

        Console.WriteLine("Ciudadanos vacunados con ambas vacunas (B ∩ C):");
        Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
        foreach (var ciudadano in tempo)
        {
            Console.WriteLine(ciudadano);
        }
        Console.WriteLine("*************************************************");
        Console.WriteLine($"Total de ciudadanos vacunados con ambas vacunas: {tempo.Count}");
        Console.WriteLine("*************************************************\n");

        Console.WriteLine("Ciudadanos vacunados solo con Pfizer (C - B):");
        Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
        foreach (var ciudadano in soloPfizer)
        {
            Console.WriteLine(ciudadano);
        }
        Console.WriteLine("***********************************************");
        Console.WriteLine($"Total de ciudadanos vacunados solo con Pfizer: {soloPfizer.Count}");
        Console.WriteLine("***********************************************\n");

        Console.WriteLine("Ciudadanos vacunados solo con AstraZeneca (B - C):");
        Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
        foreach (var ciudadano in soloAstraZeneca)
        {
            Console.WriteLine(ciudadano);
        }
        Console.WriteLine("****************************************************");
        Console.WriteLine($"Total de ciudadanos vacunados solo con AstraZeneca: {soloAstraZeneca.Count}");
        Console.WriteLine("****************************************************\n");

        // Calcular el total de ciudadanos vacunados (suma de los distintos grupos)
        int totalVacunados = tempo.Count + soloPfizer.Count + soloAstraZeneca.Count;

        // Reporte final de vacunación
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Reporte Final de Vacunación");
        Console.WriteLine("--------------------------------\n");
        Console.WriteLine("********************************************************");
        Console.WriteLine($"Total de ciudadanos vacunados con ambas vacunas: {tempo.Count}");
        Console.WriteLine($"Total de ciudadanos vacunados solo con Pfizer: {soloPfizer.Count}");
        Console.WriteLine($"Total de ciudadanos vacunados solo con AstraZeneca: {soloAstraZeneca.Count}");
        Console.WriteLine($"Total de ciudadanos no vacunados: {noVacunados.Count}");
        Console.WriteLine($"Total de ciudadanos vacunados (todas categorías): {totalVacunados}");
        Console.WriteLine("********************************************************");
    }
}

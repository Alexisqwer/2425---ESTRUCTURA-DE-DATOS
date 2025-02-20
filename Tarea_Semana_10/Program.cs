using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Crear un grupo de 500 ciudadanos ficticios
        HashSet<string> ciudadanos = new HashSet<string>();
        for (int i = 1; i <= 500; i++)
        {
            ciudadanos.Add("Ciudadano " + i); // "Ciudadano 1" hasta "Ciudadano 500"
        }

        // Se utiliza un objeto Random para seleccionar alos ciudadanos aleatorios
        Random rand = new Random();

        // Crea un conjunto de 75 ciudadanos aleatorios para Pfizer
        HashSet<string> vacunadosPfizer = new HashSet<string>();
        while (vacunadosPfizer.Count < 75)
        {
            int num = rand.Next(1, 501); // Números aleatorios entre 1 y 500
            vacunadosPfizer.Add("Ciudadano " + num);
        }

        // Crea un conjunto de 75 ciudadanos aleatorios para AstraZeneca
        HashSet<string> vacunadosAstraZeneca = new HashSet<string>();
        while (vacunadosAstraZeneca.Count < 75)
        {
            int num = rand.Next(1, 501); // Números aleatorios entre 1 y 500
            vacunadosAstraZeneca.Add("Ciudadano " + num);
        }

        // Verificar tamaños iniciales de los conjuntos
        Console.WriteLine($"Total de ciudadanos: {ciudadanos.Count}");
        Console.WriteLine($"Vacunados con Pfizer: {vacunadosPfizer.Count}");
        Console.WriteLine($"Vacunados con AstraZeneca: {vacunadosAstraZeneca.Count}\n");

        // Calcular la unión de vacunados (Pfizer ∪ AstraZeneca)
        HashSet<string> unionVacunados = new HashSet<string>(vacunadosPfizer);
        unionVacunados.UnionWith(vacunadosAstraZeneca);

        // Operaciones de conjuntos:

        // Ciudadanos no vacunados: aquellos que NO están en ningún conjunto de vacunados.
        var noVacunados = ciudadanos.Except(unionVacunados);

        // Ciudadanos vacunados con ambas vacunas: intersección de los conjuntos Pfizer y AstraZeneca.
        HashSet<string> ambasVacunas = new HashSet<string>(vacunadosPfizer);
        ambasVacunas.IntersectWith(vacunadosAstraZeneca);

        // Ciudadanos vacunados solo con Pfizer: los que están en Pfizer pero no en AstraZeneca.
        var soloPfizer = vacunadosPfizer.Except(vacunadosAstraZeneca);

        // Ciudadanos vacunados solo con AstraZeneca: los que están en AstraZeneca pero no en Pfizer.
        var soloAstraZeneca = vacunadosAstraZeneca.Except(vacunadosPfizer);

        // Reporte de vacunación:
        Console.WriteLine("\nReporte de Vacunación");
        Console.WriteLine("--------------------------");

        // Título de los ciudadanos no vacunados
        Console.WriteLine("Ciudadanos no vacunados (A - (B ∪ C)):");
        Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
        foreach (var ciudadano in noVacunados)
        {
            Console.WriteLine(ciudadano);
        }
        Console.WriteLine("**********************************");
        Console.WriteLine($"Total de ciudadanos no vacunados: {noVacunados.Count()}");
        Console.WriteLine("**********************************\n");

        // Título de los ciudadanos vacunados con ambas vacunas
        Console.WriteLine("Ciudadanos vacunados con ambas vacunas (B ∩ C):");
        Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
        foreach (var ciudadano in ambasVacunas)
        {
            Console.WriteLine(ciudadano);
        }
        Console.WriteLine("*************************************************");
        Console.WriteLine($"Total de ciudadanos vacunados con ambas vacunas: {ambasVacunas.Count}");
        Console.WriteLine("*************************************************\n");

        // Título de los ciudadanos vacunados solo con Pfizer
        Console.WriteLine("Ciudadanos vacunados solo con Pfizer (C - B):");
        Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
        foreach (var ciudadano in soloPfizer)
        {
            Console.WriteLine(ciudadano);
        }
        Console.WriteLine("***********************************************");
        Console.WriteLine($"Total de ciudadanos vacunados solo con Pfizer: {soloPfizer.Count()}");
        Console.WriteLine("***********************************************\n");

        // Título de los ciudadanos vacunados solo con AstraZeneca
        Console.WriteLine("Ciudadanos vacunados solo con AstraZeneca (B - C):");
        Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
        foreach (var ciudadano in soloAstraZeneca)
        {
            Console.WriteLine(ciudadano);
        }
        Console.WriteLine("****************************************************");
        Console.WriteLine($"Total de ciudadanos vacunados solo con AstraZeneca: {soloAstraZeneca.Count()}");
        Console.WriteLine("****************************************************\n");

        // Calcular el total de ciudadanos vacunados (suma de los distintos grupos)
        int totalVacunados = ambasVacunas.Count + soloPfizer.Count() + soloAstraZeneca.Count();

        // Reporte final de vacunación
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Reporte Final de Vacunación");
        Console.WriteLine("--------------------------------\n");
        Console.WriteLine("********************************************************");
        Console.WriteLine($"Total de ciudadanos vacunados con ambas vacunas: {ambasVacunas.Count}");
        Console.WriteLine($"Total de ciudadanos vacunados solo con Pfizer: {soloPfizer.Count()}");
        Console.WriteLine($"Total de ciudadanos vacunados solo con AstraZeneca: {soloAstraZeneca.Count()}");
        Console.WriteLine($"Total de ciudadanos no vacunados: {noVacunados.Count()}");
        Console.WriteLine($"Total de ciudadanos vacunados (todas categorías): {totalVacunados}");
        Console.WriteLine("********************************************************");
    }
}

using System;
using System.Collections.Generic;

namespace Ejercicios
{
    public class Ejercicio4
    {
        public static void Ejecutar()
        {
            // Crear lista para almacenar los números ganadores
            var numerosGanadores = new List<int>();
            Console.WriteLine("Ejercicio 4 - Ingrese los números ganadores de la lotería primitiva (6 números):");
            for (int i = 0; i < 6; i++)
            {
                Console.Write($"Número {i + 1}: ");
                if (int.TryParse(Console.ReadLine(), out int numero))
                {
                    numerosGanadores.Add(numero); // Agregar el número a la lista
                }
                else
                {
                    Console.WriteLine("Número inválido, se ignorará.");
                }
            }

            // Ordenar y mostrar los números ganadores
            numerosGanadores.Sort();
            Console.WriteLine("\nNúmeros ganadores ordenados:");
            Console.WriteLine(string.Join(", ", numerosGanadores));
            Console.WriteLine("-------------------------------");
        }
    }
}

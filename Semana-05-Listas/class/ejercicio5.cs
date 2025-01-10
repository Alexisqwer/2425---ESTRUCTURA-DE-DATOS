using System;
using System.Collections.Generic;

namespace Ejercicios
{
    public class Ejercicio5
    {
        public static void Ejecutar()
        {
            // Crear lista con números del 1 al 10
            var numeros = new List<int>();
            for (int i = 1; i <= 10; i++)
            {
                numeros.Add(i); // Agregar números del 1 al 10
            }

            // Invertir el orden de los números
            numeros.Reverse();
            Console.WriteLine("Ejercicio 5 - Números del 1 al 10 en orden inverso:");
            Console.WriteLine(string.Join(", ", numeros));
            Console.WriteLine("-------------------------------");
        }
    }
}

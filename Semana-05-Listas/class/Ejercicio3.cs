using System;
using System.Collections.Generic;

namespace Ejercicios
{
    public class Ejercicio3
    {
        public static void Ejecutar(List<Asignatura> asignaturas)
        {
            // Pedir notas para cada asignatura
            Console.WriteLine("Ejercicio 3 - Ingrese las notas de las asignaturas:");
            foreach (var asignatura in asignaturas)
            {
                Console.Write($"Ingrese la nota obtenida en {asignatura.Nombre}: ");
                if (double.TryParse(Console.ReadLine(), out double nota))
                {
                    asignatura.Nota = nota;
                }
                else
                {
                    Console.WriteLine("Nota inválida, se asignará 0.");
                    asignatura.Nota = 0;
                }
            }

            // Mostrar las notas obtenidas
            Console.WriteLine("\nNotas obtenidas:");
            foreach (var asignatura in asignaturas)
            {
                asignatura.MostrarNota();
            }
            Console.WriteLine("-------------------------------");
        }
    }
}

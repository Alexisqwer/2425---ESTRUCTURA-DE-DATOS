using System;
using System.Collections.Generic;

namespace Ejercicios
{
    public class Ejercicio1
    {
        public static void Ejecutar(List<Asignatura> asignaturas)
        {
            // Mostrar las asignaturas del curso
            Console.WriteLine("Ejercicio 1 - Asignaturas del curso:");
            foreach (var asignatura in asignaturas)
            {
                Console.WriteLine(asignatura.Nombre);
            }
            Console.WriteLine("-------------------------------");
        }
    }
}

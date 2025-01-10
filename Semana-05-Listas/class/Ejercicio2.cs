using System;
using System.Collections.Generic;

namespace Ejercicios
{
    public class Ejercicio2
    {
        public static void Ejecutar(List<Asignatura> asignaturas)
        {
            // Mostrar mensaje personalizado por cada asignatura
            Console.WriteLine("Ejercicio 2 - Mensaje personalizado:");
            foreach (var asignatura in asignaturas)
            {
                asignatura.MostrarMensaje();
            }
            Console.WriteLine("-------------------------------");
        }
    }
}

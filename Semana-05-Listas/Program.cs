using System;
using System.Collections.Generic;

namespace Ejercicios
{
    class Program
    {
        static void Main(string[] args)
        {
            // Obtener las asignaturas a través del AsignaturasManager
            List<Asignatura> asignaturas = Asignaturas.CrearAsignaturas();

            // Ejecutar los ejercicios uno por uno
            Ejercicio1.Ejecutar(asignaturas);
            Ejercicio2.Ejecutar(asignaturas);
            Ejercicio3.Ejecutar(asignaturas);
            Ejercicio4.Ejecutar();
            Ejercicio5.Ejecutar();
        }
    }
}


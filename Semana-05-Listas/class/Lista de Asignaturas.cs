using System;
using System.Collections.Generic;

namespace Ejercicios
{
    public class Asignaturas
    {
        // Método para crear las asignaturas
        public static List<Asignatura> CrearAsignaturas()
        {
            return new List<Asignatura>
            {
                new Asignatura("Matemáticas"),
                new Asignatura("Física"),
                new Asignatura("Química"),
                new Asignatura("Historia"),
                new Asignatura("Lengua")
            };
        }
    }
}

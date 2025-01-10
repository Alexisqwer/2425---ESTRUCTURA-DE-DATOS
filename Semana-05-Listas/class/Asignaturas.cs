using System;

namespace Ejercicios
{
    // Clase que representa una asignatura
    public class Asignatura
    {
        public string Nombre { get; set; }
        public double Nota { get; set; }

        public Asignatura(string nombre)
        {
            Nombre = nombre;
        }

        // Mostrar el mensaje de la asignatura
        public void MostrarMensaje()
        {
            Console.WriteLine($"Yo estudio {Nombre}");
        }

        // Mostrar la nota de la asignatura
        public void MostrarNota()
        {
            Console.WriteLine($"En {Nombre} has sacado {Nota}");
        }
    }
}

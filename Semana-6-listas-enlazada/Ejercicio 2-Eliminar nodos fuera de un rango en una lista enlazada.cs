using System;

class Ejercicio2
{
    public static void Ejecutar()
    {
        Random rand = new Random();
        ListaEnlazada lista = new ListaEnlazada();

        // Generar 50 números aleatorios entre 1 y 999 y agregarlos a la lista
        for (int i = 0; i < 50; i++)
        {
            lista.Agregar(rand.Next(1, 1000));  // Números aleatorios entre 1 y 999
        }

        Console.WriteLine("Lista original:");
        lista.Imprimir();

        // Solicitar el rango al usuario
        Console.Write("Ingrese el valor mínimo del rango: ");
        int min = int.Parse(Console.ReadLine());

        Console.Write("Ingrese el valor máximo del rango: ");
        int max = int.Parse(Console.ReadLine());

        // Eliminar nodos fuera del rango
        lista.EliminarFueraDeRango(min, max);

        Console.WriteLine($"Lista después de eliminar nodos fuera del rango ({min}, {max}):");
        lista.Imprimir();
    }
}

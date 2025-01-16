using System;

class Ejercicio1
{
    public static void Ejecutar()
    {
        ListaEnlazada lista = new ListaEnlazada();

        // Agregamos algunos elementos a la lista
        lista.Agregar(1);
        lista.Agregar(2);
        lista.Agregar(3);
        lista.Agregar(4);
        lista.Agregar(5);

        Console.WriteLine("Lista original:");
        lista.Imprimir();

        // Invertir la lista
        lista.Invertir();

        Console.WriteLine("Lista invertida:");
        lista.Imprimir();
    }
}

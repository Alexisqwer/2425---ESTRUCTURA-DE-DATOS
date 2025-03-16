public class Nodo  // Define la clase llamada "Nodo".
{
    public string Titulo;  // Campo público que almacena el valor (título) del nodo.

    public Nodo Izquierda;  // Referencia al nodo hijo izquierdo.
    public Nodo Derecha;    // Referencia al nodo hijo derecho.

    public Nodo(string titulo)  // Constructor de la clase, recibe un título como parámetro.
    {
        Titulo = titulo;  // Asigna el título recibido al campo "Titulo".
        Izquierda = null;  // Inicialmente, el nodo no tiene hijos, se establecen en null.
        Derecha = null;
    }
}

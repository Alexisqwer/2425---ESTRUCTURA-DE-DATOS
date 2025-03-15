public class Nodo
{
    public string Titulo;
    public Nodo Izquierda;
    public Nodo Derecha;

    public Nodo(string titulo)
    {
        Titulo = titulo;
        Izquierda = null;
        Derecha = null;
    }
}
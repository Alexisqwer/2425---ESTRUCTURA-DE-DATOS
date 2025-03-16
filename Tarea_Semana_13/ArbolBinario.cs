using System;
public class ArbolBinario  // Define una clase llamada "ArbolBinario" que representa un árbol binario de búsqueda.
{
    private Nodo raiz;  // Declara una variable privada "raiz" de tipo Nodo, que será la raíz del árbol.

    public ArbolBinario()  // Constructor de la clase, inicializa el árbol sin nodos (raíz nula).
    {
        raiz = null;
    }

    public void Agregar(string titulo)  // Método público para agregar un nuevo nodo al árbol con un título dado.
    {
        raiz = AgregarRecursivo(raiz, titulo);  // Llama a un método recursivo para insertar el nodo en la posición correcta.
    }

    private Nodo AgregarRecursivo(Nodo nodo, string titulo)  // Método recursivo para insertar un nodo en el árbol.
    {
        if (nodo == null)  // Si el nodo actual es nulo, significa que hemos encontrado una posición libre.
        {
            return new Nodo(titulo);  // Crea y devuelve un nuevo nodo con el título dado.
        }

        if (string.Compare(titulo, nodo.Titulo) < 0)  // Compara los títulos para decidir en qué rama colocar el nuevo nodo.
        {
            nodo.Izquierda = AgregarRecursivo(nodo.Izquierda, titulo);  // Si el título es menor, va a la izquierda.
        }
        else if (string.Compare(titulo, nodo.Titulo) > 0)  // Si el título es mayor, va a la derecha.
        {
            nodo.Derecha = AgregarRecursivo(nodo.Derecha, titulo);
        }

        return nodo;  // Retorna el nodo actual después de la posible modificación.
    }

    public bool Buscar(string titulo)  // Método público para buscar un nodo en el árbol por su título.
    {
        return BuscarRecursivo(raiz, titulo);  // Llama al método recursivo de búsqueda.
    }

    private bool BuscarRecursivo(Nodo nodo, string titulo)  // Método recursivo que busca un nodo en el árbol.
    {
        if (nodo == null)  // Si el nodo es nulo, el título no está en el árbol.
        {
            return false;
        }

        if (nodo.Titulo == titulo)  // Si el nodo actual tiene el título buscado, es encontrado.
        {
            return true;
        }

        if (string.Compare(titulo, nodo.Titulo) < 0)  // Si el título buscado es menor, busca en la izquierda.
        {
            return BuscarRecursivo(nodo.Izquierda, titulo);
        }
        else  // Si el título buscado es mayor, busca en la derecha.
        {
            return BuscarRecursivo(nodo.Derecha, titulo);
        }
    }
}

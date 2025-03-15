using System;

public class ArbolBinario
{
    private Nodo raiz;

    public ArbolBinario()
    {
        raiz = null;
    }

    public void Agregar(string titulo)
    {
        raiz = AgregarRecursivo(raiz, titulo);
    }

    private Nodo AgregarRecursivo(Nodo nodo, string titulo)
    {
        if (nodo == null)
        {
            return new Nodo(titulo);
        }

        if (string.Compare(titulo, nodo.Titulo) < 0)
        {
            nodo.Izquierda = AgregarRecursivo(nodo.Izquierda, titulo);
        }
        else if (string.Compare(titulo, nodo.Titulo) > 0)
        {
            nodo.Derecha = AgregarRecursivo(nodo.Derecha, titulo);
        }

        return nodo;
    }

    public bool Buscar(string titulo)
    {
        return BuscarRecursivo(raiz, titulo);
    }

    private bool BuscarRecursivo(Nodo nodo, string titulo)
    {
        if (nodo == null)
        {
            return false;
        }

        if (nodo.Titulo == titulo)
        {
            return true;
        }

        if (string.Compare(titulo, nodo.Titulo) < 0)
        {
            return BuscarRecursivo(nodo.Izquierda, titulo);
        }
        else
        {
            return BuscarRecursivo(nodo.Derecha, titulo);
        }
    }
}
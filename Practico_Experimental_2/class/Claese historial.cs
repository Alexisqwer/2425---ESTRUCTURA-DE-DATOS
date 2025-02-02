public class Historial
{
    private List<Pagina> paginasVisitadas;
    private int indiceActual;

    public Historial()
    {
        paginasVisitadas = new List<Pagina>();
        indiceActual = -1;
    }

    public void AgregarPagina(Pagina pagina)
    {
        // Si estamos en medio del historial, eliminamos las páginas futuras
        if (indiceActual < paginasVisitadas.Count - 1)
        {
            paginasVisitadas.RemoveRange(indiceActual + 1, paginasVisitadas.Count - (indiceActual + 1));
        }
        
        paginasVisitadas.Add(pagina);
        indiceActual++;
    }

    public Pagina Retroceder()
    {
        if (indiceActual > 0)
        {
            indiceActual--;
            return paginasVisitadas[indiceActual];
        }
        return null; // No hay más páginas hacia atrás
    }

    public Pagina Avanzar()
    {
        if (indiceActual < paginasVisitadas.Count - 1)
        {
            indiceActual++;
            return paginasVisitadas[indiceActual];
        }
        return null; // No hay más páginas hacia adelante
    }

    public void MostrarHistorial()
    {
        Console.WriteLine("Historial de navegación:");
        for (int i = 0; i < paginasVisitadas.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {paginasVisitadas[i].URL}");
        }
    }
}

public class Navegador
{
    private Historial historial;

    public Navegador()
    {
        historial = new Historial();
    }

    public void VisitarPagina(Pagina pagina)
    {
        historial.AgregarPagina(pagina);
        Console.WriteLine($"Visita a la página: {pagina.URL}");
    }

    public void Retroceder()
    {
        var pagina = historial.Retroceder();
        if (pagina != null)
        {
            Console.WriteLine($"Retrocediendo a: {pagina.URL}");
        }
        else
        {
            Console.WriteLine("No hay más páginas hacia atrás.");
        }
    }

    public void Avanzar()
    {
        var pagina = historial.Avanzar();
        if (pagina != null)
        {
            Console.WriteLine($"Avanzando a: {pagina.URL}");
        }
        else
        {
            Console.WriteLine("No hay más páginas hacia adelante.");
        }
    }

    public void MostrarHistorial()
    {
        historial.MostrarHistorial();
    }
}

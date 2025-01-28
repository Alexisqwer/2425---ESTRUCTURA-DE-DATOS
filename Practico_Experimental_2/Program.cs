class Program
{
    static void Main(string[] args)
    {
        Navegador navegador = new Navegador();

        // Crear algunas páginas
        Pagina pagina1 = new Pagina("www.pagina1.com");
        Pagina pagina2 = new Pagina("www.pagina2.com");
        Pagina pagina3 = new Pagina("www.pagina3.com");

        // Visitar las páginas
        navegador.VisitarPagina(pagina1);
        navegador.VisitarPagina(pagina2);
        navegador.VisitarPagina(pagina3);

        // Ver el historial
        navegador.MostrarHistorial();

        // Usar el botón retroceder
        navegador.Retroceder();
        navegador.Retroceder();
        navegador.Retroceder(); // No hay más páginas hacia atrás.

        // Usar el botón avanzar
        navegador.Avanzar();
        navegador.Avanzar(); // No hay más páginas hacia adelante.
    }
}

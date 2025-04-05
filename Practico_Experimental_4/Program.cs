using System;
using System.Collections.Generic;

// Clase que representa un vuelo (arista) en el grafo
public class Vuelo
{
    public string Destino { get; set; }
    public double Costo { get; set; }

    public Vuelo(string destino, double costo)
    {
        Destino = destino;
        Costo = costo;
    }
}

// Clase que representa el grafo de vuelos
public class GrafoVuelos
{
    // Diccionario para almacenar cada ciudad y su lista de vuelos salientes
    private Dictionary<string, List<Vuelo>> listaAdyacencia = new Dictionary<string, List<Vuelo>>();

    // Agregar una ciudad al grafo
    public void AgregarCiudad(string ciudad)
    {
        if (!listaAdyacencia.ContainsKey(ciudad))
            listaAdyacencia[ciudad] = new List<Vuelo>();
    }

    // Agregar un vuelo (arista) desde la ciudad de origen a la ciudad de destino con un costo
    public void AgregarVuelo(string origen, string destino, double costo)
    {
        AgregarCiudad(origen);
        AgregarCiudad(destino);
        listaAdyacencia[origen].Add(new Vuelo(destino, costo));
    }

    // Método que implementa el algoritmo de Dijkstra para encontrar la ruta más barata
    public (double costoTotal, List<string> ruta) EncontrarVueloBarato(string origen, string destino)
    {
        // Diccionario para almacenar el costo mínimo desde el origen a cada ciudad
        Dictionary<string, double> costos = new Dictionary<string, double>();
        // Diccionario para almacenar el predecesor de cada ciudad y así reconstruir la ruta
        Dictionary<string, string> predecesor = new Dictionary<string, string>();

        // Inicializar costos: infinito para todas las ciudades, y 0 para el origen
        foreach (var ciudad in listaAdyacencia.Keys)
        {
            costos[ciudad] = double.PositiveInfinity;
            predecesor[ciudad] = null;
        }
        costos[origen] = 0;

        // Conjunto de ciudades no visitadas
        var noVisitadas = new HashSet<string>(listaAdyacencia.Keys);

        while (noVisitadas.Count > 0)
        {
            // Seleccionar la ciudad no visitada con el costo mínimo
            string ciudadActual = null;
            double costoMinimo = double.PositiveInfinity;
            foreach (var ciudad in noVisitadas)
            {
                if (costos[ciudad] < costoMinimo)
                {
                    costoMinimo = costos[ciudad];
                    ciudadActual = ciudad;
                }
            }

            // Si no se encontró ninguna o se alcanzó el destino, salir
            if (ciudadActual == null || ciudadActual == destino)
                break;

            noVisitadas.Remove(ciudadActual);

            // Actualizar los costos de las ciudades vecinas
            foreach (var vuelo in listaAdyacencia[ciudadActual])
            {
                double costoAlternativo = costos[ciudadActual] + vuelo.Costo;
                if (costoAlternativo < costos[vuelo.Destino])
                {
                    costos[vuelo.Destino] = costoAlternativo;
                    predecesor[vuelo.Destino] = ciudadActual;
                }
            }
        }

        // Reconstruir la ruta desde el destino hacia el origen
        List<string> ruta = new List<string>();
        string actual = destino;
        if (predecesor[actual] != null || actual == origen)
        {
            while (actual != null)
            {
                ruta.Insert(0, actual);
                actual = predecesor[actual];
            }
        }

        return (costos[destino], ruta);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Crear el grafo de vuelos
        GrafoVuelos grafo = new GrafoVuelos();

        // Agregar vuelos: (origen, destino, costo)
        grafo.AgregarVuelo("CiudadA", "CiudadB", 100);
        grafo.AgregarVuelo("CiudadA", "CiudadC", 300);
        grafo.AgregarVuelo("CiudadB", "CiudadC", 50);
        grafo.AgregarVuelo("CiudadB", "CiudadD", 200);
        grafo.AgregarVuelo("CiudadC", "CiudadD", 100);
        grafo.AgregarVuelo("CiudadD", "CiudadE", 80);
        grafo.AgregarVuelo("CiudadC", "CiudadE", 250);

        // Buscar el vuelo más barato de CiudadA a CiudadE
        var resultado = grafo.EncontrarVueloBarato("CiudadA", "CiudadE");
        double costoTotal = resultado.costoTotal;
        List<string> ruta = resultado.ruta;

        // Mostrar el resultado
        Console.WriteLine("El vuelo más barato de CiudadA a CiudadE cuesta: " + costoTotal);
        Console.WriteLine("Ruta: " + string.Join(" -> ", ruta));

        Console.WriteLine("Presione cualquier tecla para salir...");
        Console.ReadKey();
    }
}

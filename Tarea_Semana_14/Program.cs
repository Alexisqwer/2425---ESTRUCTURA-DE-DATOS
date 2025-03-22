using System;

// Define la clase Auto
class Auto
{
    // Propiedades del auto
    public int ID { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public decimal Precio { get; set; }

    // Constructor para inicializar un auto
    public Auto(int id, string marca, string modelo, decimal precio)
    {
        ID = id;
        Marca = marca;
        Modelo = modelo;
        Precio = precio;
    }
}

// Define la clase Nodo
class Nodo
{
    // Propiedad que guarda un auto
    public Auto Auto { get; set; }
    // Referencias a los nodos izquierdo y derecho
    public Nodo? Izquierda { get; set; }
    public Nodo? Derecha { get; set; }

    // Constructor para inicializar un nodo con un auto
    public Nodo(Auto auto)
    {
        Auto = auto;
        Izquierda = null;
        Derecha = null;
    }
}

// Define la clase ArbolBinario
class ArbolBinario
{
    // Nodo raíz del árbol
    private Nodo? raiz;

    // Constructor para inicializar el árbol
    public ArbolBinario()
    {
        raiz = null;
    }

    // Método para insertar un auto en el árbol
    public void Insertar(Auto auto)
    {
        raiz = InsertarRec(raiz, auto);
    }

    // Método recursivo para insertar un auto en el árbol
    private Nodo InsertarRec(Nodo? raiz, Auto auto)
    {
        if (raiz == null)
        {
            return new Nodo(auto);
        }

        if (auto.ID < raiz.Auto.ID)
            raiz.Izquierda = InsertarRec(raiz.Izquierda, auto);
        else if (auto.ID > raiz.Auto.ID)
            raiz.Derecha = InsertarRec(raiz.Derecha, auto);

        return raiz;
    }

    // Método para mostrar autos en recorrido Preorden
    public void MostrarPreorden()
    {
        PreordenRec(raiz);
        Console.WriteLine();
    }

    // Método recursivo para mostrar autos en recorrido Preorden
    private void PreordenRec(Nodo? raiz)
    {
        if (raiz != null)
        {
            Console.WriteLine($"ID: {raiz.Auto.ID}, Marca: {raiz.Auto.Marca}, Modelo: {raiz.Auto.Modelo}, Precio: {raiz.Auto.Precio}");
            PreordenRec(raiz.Izquierda);
            PreordenRec(raiz.Derecha);
        }
    }

    // Método para mostrar autos en recorrido Inorden
    public void MostrarInorden()
    {
        InordenRec(raiz);
        Console.WriteLine();
    }

    // Método recursivo para mostrar autos en recorrido Inorden
    private void InordenRec(Nodo? raiz)
    {
        if (raiz != null)
        {
            InordenRec(raiz.Izquierda);
            Console.WriteLine($"ID: {raiz.Auto.ID}, Marca: {raiz.Auto.Marca}, Modelo: {raiz.Auto.Modelo}, Precio: {raiz.Auto.Precio}");
            InordenRec(raiz.Derecha);
        }
    }

    // Método para mostrar autos en recorrido Postorden
    public void MostrarPostorden()
    {
        PostordenRec(raiz);
        Console.WriteLine();
    }

    // Método recursivo para mostrar autos en recorrido Postorden
    private void PostordenRec(Nodo? raiz)
    {
        if (raiz != null)
        {
            PostordenRec(raiz.Izquierda);
            PostordenRec(raiz.Derecha);
            Console.WriteLine($"ID: {raiz.Auto.ID}, Marca: {raiz.Auto.Marca}, Modelo: {raiz.Auto.Modelo}, Precio: {raiz.Auto.Precio}");
        }
    }

    // Método para buscar un auto por ID
    public Auto? Buscar(int id)
    {
        return BuscarRec(raiz, id);
    }

    // Método recursivo para buscar un auto por ID
    private Auto? BuscarRec(Nodo? raiz, int id)
    {
        if (raiz == null)
            return null;

        if (id == raiz.Auto.ID)
            return raiz.Auto;

        return id < raiz.Auto.ID ? BuscarRec(raiz.Izquierda, id) : BuscarRec(raiz.Derecha, id);
    }

    // Método para eliminar un auto por ID
    public void Eliminar(int id)
    {
        raiz = EliminarRec(raiz, id);
    }

    // Método recursivo para eliminar un auto por ID
    private Nodo? EliminarRec(Nodo? raiz, int id)
    {
        if (raiz == null)
            return raiz;

        if (id < raiz.Auto.ID)
            raiz.Izquierda = EliminarRec(raiz.Izquierda, id);
        else if (id > raiz.Auto.ID)
            raiz.Derecha = EliminarRec(raiz.Derecha, id);
        else
        {
            // Nodo encontrado para eliminar
            if (raiz.Izquierda == null)
                return raiz.Derecha;
            else if (raiz.Derecha == null)
                return raiz.Izquierda;

            raiz.Auto = MinValor(raiz.Derecha);
            raiz.Derecha = EliminarRec(raiz.Derecha, raiz.Auto.ID);
        }

        return raiz;
    }

    // Método para encontrar el valor mínimo en el subárbol derecho
    private Auto MinValor(Nodo raiz)
    {
        Nodo? actual = raiz;
        while (actual.Izquierda != null)
            actual = actual.Izquierda;

        return actual.Auto;
    }
}

// Clase principal del programa
class Programa
{
    // Método principal
    static void Main(string[] args)
    {
        // Crear un nuevo árbol binario
        ArbolBinario arbol = new ArbolBinario();
        int opcion;

        // Bucle para mostrar el menú y realizar acciones
        do
        {
            MostrarMenu();
            opcion = int.Parse(Console.ReadLine()!);

            switch (opcion)
            {
                case 1:
                    // Insertar un auto
                    Auto auto = SolicitarAuto();
                    arbol.Insertar(auto);
                    Console.WriteLine("Auto insertado exitosamente.");
                    break;

                case 2:
                    // Mostrar autos en Preorden
                    Console.WriteLine("Recorrido Preorden:");
                    arbol.MostrarPreorden();
                    break;

                case 3:
                    // Mostrar autos en Inorden
                    Console.WriteLine("Recorrido Inorden:");
                    arbol.MostrarInorden();
                    break;

                case 4:
                    // Mostrar autos en Postorden
                    Console.WriteLine("Recorrido Postorden:");
                    arbol.MostrarPostorden();
                    break;

                case 5:
                    // Buscar un auto por ID
                    Console.Write("Ingrese el ID del auto a buscar: ");
                    int idBuscar = int.Parse(Console.ReadLine()!);
                    Auto? encontrado = arbol.Buscar(idBuscar);
                    if (encontrado != null)
                        Console.WriteLine($"Auto encontrado: ID: {encontrado.ID}, Marca: {encontrado.Marca}, Modelo: {encontrado.Modelo}, Precio: {encontrado.Precio}");
                    else
                        Console.WriteLine("Auto no encontrado.");
                    break;

                case 6:
                    // Eliminar un auto por ID
                    Console.Write("Ingrese el ID del auto a eliminar: ");
                    int idEliminar = int.Parse(Console.ReadLine()!);
                    arbol.Eliminar(idEliminar);
                    Console.WriteLine("Auto eliminado exitosamente.");
                    break;

                case 7:
                    // Salir del programa
                    Console.WriteLine("¡Hasta luego!");
                    break;

                default:
                    // Opción no válida
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        } while (opcion != 7);
    }

    // Método para mostrar el menú
    static void MostrarMenu()
    {
        Console.WriteLine("\nMenú de Opciones:");
        Console.WriteLine("1. Insertar auto");
        Console.WriteLine("2. Mostrar autos (Preorden)");
        Console.WriteLine("3. Mostrar autos (Inorden)");
        Console.WriteLine("4. Mostrar autos (Postorden)");
        Console.WriteLine("5. Buscar auto");
        Console.WriteLine("6. Eliminar auto");
        Console.WriteLine("7. Salir");
        Console.Write("Seleccione una opción: ");
    }

    // Método para solicitar los datos de un auto
    static Auto SolicitarAuto()
    {
        Console.Write("Ingrese el ID del auto: ");
        int id = int.Parse(Console.ReadLine()!);
        Console.Write("Ingrese la marca del auto: ");
        string marca = Console.ReadLine()!;
        Console.Write("Ingrese el modelo del auto: ");
        string modelo = Console.ReadLine()!;
        Console.Write("Ingrese el precio del auto: ");
        decimal precio = decimal.Parse(Console.ReadLine()!);

        return new Auto(id, marca, modelo, precio);
    }
}

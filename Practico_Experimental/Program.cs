using System;

namespace AgendaClinica
{
    // Estructura Paciente
    struct Paciente
    {
        public int Id;
        public string Nombre;
        public string Telefono;

        public Paciente(int id, string nombre, string telefono)
        {
            Id = id;
            Nombre = nombre;
            Telefono = telefono;
        }

        public override string ToString()
        {
            return $"Paciente(ID: {Id}, Nombre: {Nombre}, Teléfono: {Telefono})";
        }
    }

    // Estructura Turno
    struct Turno
    {
        public Paciente Paciente;
        public DateTime FechaHora;

        public Turno(Paciente paciente, DateTime fechaHora)
        {
            Paciente = paciente;
            FechaHora = fechaHora;
        }

        public override string ToString()
        {
            return $"Turno(Paciente: {Paciente.Nombre}, Fecha y Hora: {FechaHora})";
        }
    }

    // Clase Agenda
    class Agenda
    {
        private Turno[] turnos; // Vector de turnos
        private int contador;   // Controla el número de turnos registrados

        public Agenda(int capacidad)
        {
            turnos = new Turno[capacidad]; // Inicializa el vector de turnos con la capacidad dada
            contador = 0;
        }

        // Registrar un nuevo turno
        public void RegistrarTurno(Paciente paciente, DateTime fechaHora)
        {
            if (contador < turnos.Length)
            {
                turnos[contador] = new Turno(paciente, fechaHora);
                contador++;
                Console.WriteLine($"Turno registrado exitosamente: {turnos[contador - 1]}");
            }
            else
            {
                Console.WriteLine("No se pueden registrar más turnos, la agenda está llena.");
            }
        }

        // Visualizar todos los turnos
        public void VisualizarTurnos()
        {
            Console.WriteLine("\n--- Turnos Registrados ---");
            if (contador == 0)
            {
                Console.WriteLine("No hay turnos registrados.");
                return;
            }

            for (int i = 0; i < contador; i++)
            {
                Console.WriteLine(turnos[i]);
            }
        }

        // Consultar turnos por ID de paciente
        public void ConsultarTurnosPorPaciente(int idPaciente)
        {
            Console.WriteLine($"\n--- Turnos del Paciente con ID: {idPaciente} ---");
            bool encontrado = false;

            for (int i = 0; i < contador; i++)
            {
                if (turnos[i].Paciente.Id == idPaciente)
                {
                    Console.WriteLine(turnos[i]);
                    encontrado = true;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("No se encontraron turnos para el paciente indicado.");
            }
        }
    }

    // Clase principal
    class Program
    {
        static void Main(string[] args)
        {
            // Crear pacientes
            Paciente paciente1 = new Paciente(1, "Ana Pérez", "555-1234");
            Paciente paciente2 = new Paciente(2, "Carlos Gómez", "555-5678");

            // Crear agenda con capacidad de 5 turnos
            Agenda agenda = new Agenda(5);

            // Registrar turnos
            agenda.RegistrarTurno(paciente1, new DateTime(2025, 1, 11, 10, 0, 0));
            agenda.RegistrarTurno(paciente2, new DateTime(2025, 1, 12, 11, 30, 0));
            agenda.RegistrarTurno(paciente1, new DateTime(2025, 1, 13, 9, 0, 0));

            // Menú interactivo
            while (true)
            {
                Console.WriteLine("\n--- Menú de Agenda Clínica ---");
                Console.WriteLine("1. Visualizar todos los turnos");
                Console.WriteLine("2. Consultar turnos por ID de paciente");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        agenda.VisualizarTurnos();
                        break;
                    case "2":
                        Console.Write("Ingrese el ID del paciente: ");
                        if (int.TryParse(Console.ReadLine(), out int idPaciente))
                        {
                            agenda.ConsultarTurnosPorPaciente(idPaciente);
                        }
                        else
                        {
                            Console.WriteLine("ID inválido. Por favor, intente nuevamente.");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Saliendo del programa. ¡Hasta luego!");
                        return;
                    default:
                        Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                        break;
                }
            }
        }
    }
}

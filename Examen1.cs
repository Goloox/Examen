using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    class Program
    {
        static List<Paciente> pacientes = new List<Paciente>();
        static List<Medicamento> catalogoMedicamentos = new List<Medicamento>();
        static List<Consulta> consultas = new List<Consulta>();
        class Paciente
        {
            public string Nombre { get; set; }
            public string Telefono { get; set; }
            public string TipoSangre { get; set; }
            public string Direccion { get; set; }
            public DateTime FechaNacimiento { get; set; }
            public List<Medicamento> MedicamentosTratamiento { get; } = new List<Medicamento>();
        }

        static void Main()
        {
            int opcion;
            do
            {
                MostrarMenu();
                opcion = LeerEntero("Ingrese la opción deseada: ");

                switch (opcion)
                {
                    case 1:
                        AgregarPaciente();
                        break;
                    case 2:
                        AgregarMedicamento();
                        break;
                    case 3:
                        AsignarTratamiento();
                        break;
                    case 4:
                        MostrarConsultas();
                        break;
                    case 5:
                        // Otra opción, si es necesario
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                        break;
                }

            } while (opcion != 5);
        }

        static void MostrarMenu()
        {
            Console.WriteLine("Menú Principal");
            Console.WriteLine("1- Agregar paciente");
            Console.WriteLine("2- Agregar medicamento al catálogo");
            Console.WriteLine("3- Asignar tratamiento médico a un paciente");
            Console.WriteLine("4- Consultas");
            Console.WriteLine("5- Salir");
        }

        static void AgregarPaciente()
        {
            Console.WriteLine("Agregar Paciente");


            Paciente nuevoPaciente = new Paciente();

            Console.Write("Nombre: ");
            nuevoPaciente.Nombre = Console.ReadLine();

            Console.Write("Teléfono: ");
            nuevoPaciente.Telefono = Console.ReadLine();

            Console.Write("Tipo de sangre: ");
            nuevoPaciente.TipoSangre = Console.ReadLine();

            Console.Write("Dirección: ");
            nuevoPaciente.Direccion = Console.ReadLine();

            Console.Write("Fecha de Nacimiento (yyyy/mm/dd): ");
            nuevoPaciente.FechaNacimiento = DateTime.Parse(Console.ReadLine());

            pacientes.Add(nuevoPaciente);

            Console.WriteLine("Paciente agregado exitosamente.");
        }

        static void AgregarMedicamento()
        {
            Console.WriteLine("Agregar Medicamento al Catálogo");

            Medicamento nuevoMedicamento = new Medicamento();

            Console.Write("Código del medicamento: ");
            nuevoMedicamento.Codigo = Console.ReadLine();

            Console.Write("Nombre del medicamento: ");
            nuevoMedicamento.Nombre = Console.ReadLine();

            Console.Write("Cantidad: ");
            nuevoMedicamento.Cantidad = LeerEntero("Ingrese la cantidad: ");

            catalogoMedicamentos.Add(nuevoMedicamento);

            Console.WriteLine("Medicamento agregado al catálogo exitosamente.");
        }

        static void AsignarTratamiento()
        {
            Console.WriteLine("Asignar Tratamiento Médico a un Paciente");
            Console.WriteLine("Asignar Tratamiento Médico a un Paciente");

            if (pacientes.Count == 0 || catalogoMedicamentos.Count == 0)
            {
                Console.WriteLine("No hay pacientes o medicamentos registrados.");
                return;
            }

            Console.WriteLine("Lista de Pacientes:");
            for (int i = 0; i < pacientes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {pacientes[i].Nombre}");
            }

            int indicePaciente = LeerEntero("Seleccione el número de paciente: ") - 1;

            if (indicePaciente < 0 || indicePaciente >= pacientes.Count)
            {
                Console.WriteLine("Número de paciente no válido.");
                return;
            }

            Paciente pacienteSeleccionado = pacientes[indicePaciente];

            Console.WriteLine("Lista de Medicamentos:");
            for (int i = 0; i < catalogoMedicamentos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {catalogoMedicamentos[i].Nombre}");
            }

            Console.Write("Seleccione el número de medicamento: ");
            int indiceMedicamento = LeerEntero("") - 1;

            if (indiceMedicamento < 0 || indiceMedicamento >= catalogoMedicamentos.Count)
            {
                Console.WriteLine("Número de medicamento no válido.");
                return;
            }

            Medicamento medicamentoSeleccionado = catalogoMedicamentos[indiceMedicamento];

            // Verificar si el paciente ya ha alcanzado el límite de medicamentos en el tratamiento
            if (pacienteSeleccionado.MedicamentosTratamiento.Count >= 3)
            {
                Console.WriteLine("El paciente ya ha alcanzado el límite de medicamentos en el tratamiento.");
                return;
            }

            // Verificar si hay suficiente cantidad de medicamento en el inventario
            if (medicamentoSeleccionado.Cantidad <= 0)
            {
                Console.WriteLine("No hay suficiente cantidad del medicamento en el inventario.");
                return;
            }

            // Asignar el medicamento al tratamiento del paciente
            pacienteSeleccionado.MedicamentosTratamiento.Add(medicamentoSeleccionado);
            medicamentoSeleccionado.Cantidad--;

            Console.WriteLine("Tratamiento asignado exitosamente.");
        }

        static void MostrarConsultas()
        {
            Console.WriteLine("Consultas");
            Console.WriteLine("Consultas");

            Console.WriteLine($"Cantidad total de pacientes registrados: {pacientes.Count}");

            Console.WriteLine("Reporte de todos los medicamentos recetados sin repetir:");
            var medicamentosRecetados = pacientes.SelectMany(p => p.MedicamentosTratamiento).Distinct();
            foreach (var medicamento in medicamentosRecetados)
            {
                Console.WriteLine($"{medicamento.Nombre}");
            }

            // Puedes continuar implementando los otros reportes según las necesidades
        }


        // Métodos adicionales según sea necesario...

        static int LeerEntero(string mensaje)
        {
            int resultado;
            do
            {
                Console.Write(mensaje);
            } while (!int.TryParse(Console.ReadLine(), out resultado));
            return resultado;
        }
    }

    class Paciente
    {
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string TipoSangre { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }

    class Medicamento
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
    }

    class Consulta
    {
       
    }
}

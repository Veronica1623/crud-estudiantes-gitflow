using GestionEstudiantes.Models;
using GestionEstudiantes.Services;

var service = new EstudianteService();
bool salir = false;

while (!salir)
{
    MostrarMenu();
    var opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            CrearEstudiante();
            break;
        case "2":
            ListarEstudiantes();
            break;
        case "3":
            BuscarEstudiante();
            break;
        case "4":
            ActualizarEstudiante();
            break;
        case "5":
            EliminarEstudiante();
            break;
        case "0":
            salir = true;
            break;
        default:
            Console.WriteLine("Opción inválida. Intenta de nuevo.\n");
            break;
    }
}

Console.WriteLine("¡Hasta luego!");

void MostrarMenu()
{
    Console.WriteLine("==== Gestión de Estudiantes (CRUD) ====");
    Console.WriteLine("1. Crear estudiante");
    Console.WriteLine("2. Listar estudiantes");
    Console.WriteLine("3. Buscar estudiante por Id");
    Console.WriteLine("4. Actualizar estudiante");
    Console.WriteLine("5. Eliminar estudiante");
    Console.WriteLine("0. Salir");
    Console.Write("Selecciona una opción: ");
}

void CrearEstudiante()
{
    Console.Write("Nombre: ");
    var nombre = Console.ReadLine() ?? string.Empty;

    Console.Write("Edad: ");
    int.TryParse(Console.ReadLine(), out int edad);

    Console.Write("Carrera: ");
    var carrera = Console.ReadLine() ?? string.Empty;

    var estudiante = service.Crear(nombre, edad, carrera);
    Console.WriteLine($"Estudiante creado con éxito: {estudiante}\n");
}

void ListarEstudiantes()
{
    var lista = service.ListarTodos();
    if (!lista.Any())
    {
        Console.WriteLine("No hay estudiantes registrados.\n");
        return;
    }

    Console.WriteLine("-- Lista de estudiantes --");
    foreach (var e in lista)
        Console.WriteLine(e);
    Console.WriteLine();
}

void BuscarEstudiante()
{
    Console.Write("Id a buscar: ");
    int.TryParse(Console.ReadLine(), out int id);

    var estudiante = service.BuscarPorId(id);
    Console.WriteLine(estudiante is null
        ? $"No se encontró un estudiante con Id {id}.\n"
        : $"Encontrado: {estudiante}\n");
}

void ActualizarEstudiante()
{
    Console.Write("Id a actualizar: ");
    int.TryParse(Console.ReadLine(), out int id);

    Console.Write("Nuevo nombre (Enter para no modificar): ");
    var nombre = Console.ReadLine();

    Console.Write("Nueva edad (Enter para no modificar): ");
    var edadTexto = Console.ReadLine();
    int? edad = int.TryParse(edadTexto, out int edadValor) ? edadValor : null;

    Console.Write("Nueva carrera (Enter para no modificar): ");
    var carrera = Console.ReadLine();

    bool actualizado = service.Actualizar(id, nombre, edad, carrera);
    Console.WriteLine(actualizado
        ? "Estudiante actualizado con éxito.\n"
        : $"No se encontró un estudiante con Id {id}.\n");
}

void EliminarEstudiante()
{
    Console.Write("Id a eliminar: ");
    int.TryParse(Console.ReadLine(), out int id);

    bool eliminado = service.Eliminar(id);
    Console.WriteLine(eliminado
        ? "Estudiante eliminado con éxito.\n"
        : $"No se encontró un estudiante con Id {id}.\n");
}

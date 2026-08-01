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

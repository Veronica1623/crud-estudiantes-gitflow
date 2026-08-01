using System.Text.Json;
using GestionEstudiantes.Models;

namespace GestionEstudiantes.Services;

public class EstudianteService
{
    private readonly string _rutaArchivo;
    private List<Estudiante> _estudiantes;
    private int _siguienteId;

    public EstudianteService(string rutaArchivo = "estudiantes.json")
    {
        _rutaArchivo = rutaArchivo;
        _estudiantes = CargarDesdeArchivo();
        _siguienteId = _estudiantes.Any() ? _estudiantes.Max(e => e.Id) + 1 : 1;
    }

    public Estudiante Crear(string nombre, int edad, string carrera)
    {
        var estudiante = new Estudiante
        {
            Id = _siguienteId++,
            Nombre = nombre,
            Edad = edad,
            Carrera = carrera,
            FechaRegistro = DateTime.Now
        };

        _estudiantes.Add(estudiante);
        Guardar();
        return estudiante;
    }

    public List<Estudiante> ListarTodos()
    {
        return _estudiantes.OrderBy(e => e.Id).ToList();
    }

    public Estudiante? BuscarPorId(int id)
    {
        return _estudiantes.FirstOrDefault(e => e.Id == id);
    }

    public bool Actualizar(int id, string? nombre, int? edad, string? carrera)
    {
        var estudiante = BuscarPorId(id);
        if (estudiante is null) return false;

        if (!string.IsNullOrWhiteSpace(nombre)) estudiante.Nombre = nombre;
        if (edad.HasValue) estudiante.Edad = edad.Value;
        if (!string.IsNullOrWhiteSpace(carrera)) estudiante.Carrera = carrera;

        Guardar();
        return true;
    }

    // DELETE
    public bool Eliminar(int id)
    {
        var estudiante = BuscarPorId(id);
        if (estudiante is null) return false;

        _estudiantes.Remove(estudiante);
        Guardar();
        return true;
    }

    private List<Estudiante> CargarDesdeArchivo()
    {
        if (!File.Exists(_rutaArchivo)) return new List<Estudiante>();
        try
        {
            var json = File.ReadAllText(_rutaArchivo);
            return JsonSerializer.Deserialize<List<Estudiante>>(json) ?? new List<Estudiante>();
        }
        catch (JsonException)
        {
            return new List<Estudiante>();
        }
    }

    private void Guardar()
    {
        var opciones = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(_estudiantes, opciones);
        File.WriteAllText(_rutaArchivo, json);
    }
}

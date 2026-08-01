namespace GestionEstudiantes.Models;

public class Estudiante
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public int Edad { get; set; }
    public string Carrera { get; set; } = string.Empty;
    public DateTime FechaRegistro { get; set; }

    public override string ToString()
    {
        return $"[{Id}] {Nombre} | Edad: {Edad} | Carrera: {Carrera} | Registrado: {FechaRegistro}";
    }
}

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
        // FIX: formato de fecha fijo (yyyy-MM-dd), antes dependía de la cultura
        // del sistema y producía salidas inconsistentes entre entornos.
        string fecha = FechaRegistro.ToString("yyyy-MM-dd");
        return $"[{Id}] {Nombre} | Edad: {Edad} | Carrera: {Carrera} | Registrado: {fecha}";
    }
}

namespace Tarea3_p3.Models;

public class Estudiante
{
    public int Id { get; set; }
    public string Matricula { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Carrera { get; set; } = string.Empty;
    public double Calificacion { get; set; }
    public DateTime FechaRegistro { get; set; } = DateTime.Now;
    public string Estado => Calificacion >= 70 ? "Aprobado" : "Reprobado";
}

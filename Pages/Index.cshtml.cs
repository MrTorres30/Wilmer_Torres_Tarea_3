using Microsoft.AspNetCore.Mvc.RazorPages;
using Tarea3_p3.Models;

namespace Tarea3_p3.Pages;

public class IndexModel : PageModel
{
    public int TotalEstudiantes { get; set; } = 4;
    public int EstudiantesAprobados { get; set; } = 3;
    public int EstudiantesReprobados { get; set; } = 1;
    public double PromedioGeneral { get; set; } = 84.5;

    public List<Estudiante> EstudiantesRecientes { get; set; } = new();

    public void OnGet()
    {
        EstudiantesRecientes = new List<Estudiante>
        {
            new Estudiante { Id = 1, Matricula = "2024-0123", Nombre = "Carlos Mendoza", Carrera = "Desarrollo de Software", Calificacion = 92, FechaRegistro = DateTime.Now.AddDays(-10) },
            new Estudiante { Id = 2, Matricula = "2024-0456", Nombre = "María Santos", Carrera = "Ciberseguridad", Calificacion = 88, FechaRegistro = DateTime.Now.AddDays(-8) },
            new Estudiante { Id = 3, Matricula = "2024-0789", Nombre = "Wilmer Torres", Carrera = "Desarrollo de Software", Calificacion = 95, FechaRegistro = DateTime.Now.AddDays(-4) },
            new Estudiante { Id = 4, Matricula = "2024-0999", Nombre = "Pedro Ramírez", Carrera = "Redes de Información", Calificacion = 63, FechaRegistro = DateTime.Now.AddDays(-2) }
        };

        TotalEstudiantes = EstudiantesRecientes.Count;
        EstudiantesAprobados = EstudiantesRecientes.Count(e => e.Calificacion >= 70);
        EstudiantesReprobados = EstudiantesRecientes.Count(e => e.Calificacion < 70);
        PromedioGeneral = EstudiantesRecientes.Any() ? Math.Round(EstudiantesRecientes.Average(e => e.Calificacion), 1) : 0;
    }
}

using Tarea3_p3;
using Tarea3_p3.Models;

namespace Tarea3_p3.Services
{
    public class EstudianteService : IEstudianteService
    {
        private readonly List<Estudiante> _estudiantes = new()
        {
            new Estudiante { Id = 1, Matricula = "2024-0121" , Nombre = "Carlos Ventura", Carrera = "CiberSeguridad" ,
             Calificacion = 91, FechaRegistro = DateTime.Now.AddDays(-10) },
            new Estudiante { Id = 2, Matricula = "2024-0456", Nombre = "María Santos", Carrera = "Ciberseguridad",
             Calificacion = 88, FechaRegistro = DateTime.Now.AddDays(-8) },
            new Estudiante { Id = 3, Matricula = "2024-0789", Nombre = "Harold Velasquez", Carrera = "Desarrollo de Software",
             Calificacion = 95, FechaRegistro = DateTime.Now.AddDays(-4) },
            new Estudiante { Id = 4, Matricula = "2024-0999", Nombre = "Pedro Ramírez", Carrera = "Redes de Información",
             Calificacion = 63, FechaRegistro = DateTime.Now.AddDays(-2) }
        };

         private int _siguienteId = 5;
    public List<Estudiante> ObtenerTodos() => _estudiantes;
    public Estudiante? ObtenerPorId(int id) => _estudiantes.FirstOrDefault(e => e.Id == id);
    public void Agregar(Estudiante estudiante)
    {
        estudiante.Id = _siguienteId++;
        estudiante.FechaRegistro = DateTime.Now;
        _estudiantes.Add(estudiante);
    }
    public void Actualizar(Estudiante estudianteActualizado)
        {
            var existente = ObtenerPorId(estudianteActualizado.Id);
            if(existente != null)
            {
                existente.Matricula = estudianteActualizado.Matricula;
                existente.Nombre = estudianteActualizado.Nombre;
                existente.Carrera = estudianteActualizado.Carrera;
                existente.Calificacion = estudianteActualizado.Calificacion; 

            }
        }
        public bool Eliminar(int id)
        {
            var estudiante= ObtenerPorId(id);
            if (estudiante != null)
            {
                return _estudiantes.Remove(estudiante);

            }
                return false;
        }

    }

}
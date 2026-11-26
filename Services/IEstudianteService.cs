using System.Runtime.CompilerServices;
using Tarea3_p3;
using Tarea3_p3.Models;

namespace Tarea3_p3.Services
{
    public interface IEstudianteService
    {
        List<Estudiante> ObtenerTodos();
        Estudiante? ObtenerPorId(int id);
       void Agregar (Estudiante estudiante);
       void Actualizar (Estudiante estudiante);
       bool Eliminar (int id);

    }

}
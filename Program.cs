using Tarea3_p3.Models;
using Tarea3_p3.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton<IEstudianteService, EstudianteService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapGet("/api/estudiantes", (IEstudianteService servicio) => 
    Results.Ok(servicio.ObtenerTodos()));
app.MapGet("/api/estudiantes/{id:int}", (int id, IEstudianteService servicio) =>
{
    var estudiante = servicio.ObtenerPorId(id);
    return estudiante is not null ? Results.Ok(estudiante) : Results.NotFound();
});

app.MapPost("/api/estudiantes", (Estudiante estudiante, IEstudianteService servicio) =>
{
    servicio.Agregar(estudiante);
    return Results.Created($"/api/estudiantes/{estudiante.Id}", estudiante);
});
app.MapPut("/api/estudiantes/{id:int}", (int id, Estudiante estudiante, IEstudianteService servicio) =>
{
    var existente = servicio.ObtenerPorId(id);
    if (existente is null) return Results.NotFound();
    estudiante.Id = id;
    servicio.Actualizar(estudiante);
    return Results.NoContent();
});
app.MapDelete("/api/estudiantes/{id:int}", (int id, IEstudianteService servicio) =>
{
    var eliminado = servicio.Eliminar(id);
    return eliminado ? Results.NoContent() : Results.NotFound();
});
app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();

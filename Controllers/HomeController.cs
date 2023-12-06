using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProyectoMvc.Models;
using ProyectoMvc.Models.modelos;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Converters;
using Microsoft.EntityFrameworkCore;

namespace ProyectoMvc.Controllers;
[ApiController]
[Route("api")]  // Puedes cambiar esto según tus preferencias
public class HomeController : ControllerBase
{
    private readonly Alumnocontext context;

    public HomeController(Alumnocontext contexto)
    {
        context = contexto;
    }

    //registrar datos
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Curso>))]
    public IEnumerable<Curso> Get()
    {
        return context.cursos
                //.Include(x => x.comentariolista)
                .ToList();
    }
    
    //guardar datos
    [HttpPost]
    public IActionResult Registrar(Curso data)
    {
        try
        {
            Guid _cursoid = Guid.NewGuid();
            var curso = new Curso
            {
            CursoId = _cursoid,
            Titulo = data.Titulo,
            Descripcion = data.Descripcion,
            FechaPublicacion = DateTime.UtcNow
            };

        context.cursos.Add(curso);

        var resultado = context.SaveChanges();
        if (resultado > 0)
        {
            // Éxito en la inserción, devolver un OkObjectResult
            return Ok(new{Message = "Se insertó correctamente"});
        }
        else
        {
            // No se pudo insertar, devolver un BadRequest
            return BadRequest("No se pudo insertar el curso");
        }
        }
            catch (Exception)
        {
            // Manejar la excepción, puedes registrarla o devolver un mensaje genérico
            return StatusCode(500, "Error interno del servidor");
        }
    }

    //Eliminar datos
    [HttpDelete("{id}")]
    public IActionResult Eliminar(Guid id)
    {
        try
        {
            var comentariolista = context.comentarios.Where(x => x.Cursoid == id);
            foreach(var comentariocurso in comentariolista)
            {
                context.comentarios.Remove(comentariocurso);
            }

            var cursoelimina = context.cursos.Find(id);
            context.cursos.Remove(cursoelimina!);

            var resultado = context.SaveChanges();
            if (resultado > 0)
            {
                // Éxito en la inserción, devolver un OkObjectResult
                return Ok(new{Message = "Se elimino correctamente"});
            }
            else
            {
                // No se pudo insertar, devolver un BadRequest
                return BadRequest("No se pudo eliminar el curso");
            }
        }
        catch(Exception)
        {
            return StatusCode(500, "Error interno del servidor");
        }
    }

    //Actualizar datos
    [HttpPut("{id}")]
    public IActionResult Actualizar(Guid id, Curso data)
    {
        var cursoactualiza = context.cursos.Find(id);
        if(cursoactualiza == null)
        {
            return BadRequest("No se pudo encontrar el curso");
        }

        cursoactualiza.Titulo = data.Titulo ?? cursoactualiza.Titulo;
        cursoactualiza.Descripcion = data.Descripcion ?? cursoactualiza.Descripcion;

        var resultado = context.SaveChanges();
            if (resultado > 0)
            {
                // Éxito en la inserción, devolver un OkObjectResult
                return Ok(new{Message = "Se modifico correctamente"});
            }
            else
            {
                // No se pudo insertar, devolver un BadRequest
                return BadRequest("No se pudo modificar el curso");
            }

    }
}
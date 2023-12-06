using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoMvc.Models.modelos
{
    public class Curso
    {
        public Guid CursoId{get;set;}

        public string? Titulo{get;set;}

        public string? Descripcion{get;set;}

        public DateTime? FechaPublicacion{get;set;}
        public ICollection<Comentario>? comentariolista{get;set;}



                
    }
}
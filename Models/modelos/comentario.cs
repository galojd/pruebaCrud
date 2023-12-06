using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoMvc.Models.modelos
{
    public class Comentario
    {
        public Guid ComentarioId{get;set;}
        public Guid? Cursoid{get;set;}
        public string? ComentarioTexto{get;set;}
        public Curso? curso{get;set;}
    }
}
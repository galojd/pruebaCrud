using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoMvc.Models.modelos;

namespace ProyectoMvc.Models
{
    public class Alumnocontext : DbContext
    {
        public Alumnocontext(DbContextOptions options) : base(options){

        }
        public DbSet<Curso> cursos{get;set;}
        public DbSet<Comentario> comentarios{get;set;}
        
    }

    
}
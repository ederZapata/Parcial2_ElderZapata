using Microsoft.EntityFrameworkCore;
using Parcial2.DAL.Entities;
using System.Diagnostics.Metrics;

namespace Parcial2.DAL
{
    public class DataBaseContext : DbContext
    {
        //En este constructor, creo la refrencia de DbContextOptions que me sirve para configurar las opciones de la BD, como por ejemplo usar SQL Server y usar la cadena de conexión a la BD
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<NaturalPerson>().HasIndex(c => c.Name).IsUnique(); //Yo con esta línea controlo la duplicidad de mis países
        }
        
            
            //DbSet me sirve para convertir mi clase Country en una tabla de BD. El nombre de la tabla será "Countries"
        public DbSet<NaturalPerson> NaturalPersons { get; set; }

    }

}

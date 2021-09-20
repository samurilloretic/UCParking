using Microsoft.EntityFrameworkCore;
using UCP.App.Dominio;

namespace UCP.App.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Persona> personas {get;set;}

        public DbSet<Profesor> profesores {get;set;}

        public DbSet<Estudiante> estudiantes {get;set;}

        public DbSet<Administrativo> administrativos {get;set;}
        
        public DbSet<Visitante> visitantes {get;set;}

        public DbSet<Parqueadero> parqueaderos {get;set;}

        public DbSet<Puesto> puestos {get;set;}

        public DbSet<Transaccion> transacciones {get;set;}

        public DbSet<Vehiculo> vehiculos {get;set;}
        //Completar con las demás clases del dominio

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source =(localdb)\\MSSQLLocalDB; Initial Catalog = UCParkingExa");
            }
        }
    }
}
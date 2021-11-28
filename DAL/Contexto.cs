using Microsoft.EntityFrameworkCore;
using ProyectoFinal_ContratacionEmpleados.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ContratacionEmpleados.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Vacantes> Vacantes { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Generos> Generos { get; set; }
        public DbSet<Habilidades> Habilidades { get; set; }
        public DbSet<Departamentos> Departamentos { get; set; }
        public DbSet<Empresas> Empresas { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Permisos> Permisos { get; set; }
        public DbSet<Provincias> Provincias { get; set; }
        public DbSet<Ciudades> Ciudades { get; set; }
        public DbSet<Sectores> Sectores { get; set; }
        public DbSet<Personas> Personas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = DATA\RecursosHumanos.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permisos>().HasData(new Permisos
            {
                PermisoId = 1,
                Descripcion = "PermisoProfe"
            });

            modelBuilder.Entity<Roles>().HasData(new Roles
            {
                RolId = 1,
                Descripcion = "Administrador"
            });

            modelBuilder.Entity<Usuarios>().HasData(new Usuarios
            {
                UsuarioId = 1,
                NombreUsuario = "Admin",
                Email = "profe098@gmail.com",
                Clave = "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4",//clave: 1234
                RolId = 1
            });
        }
    }
}

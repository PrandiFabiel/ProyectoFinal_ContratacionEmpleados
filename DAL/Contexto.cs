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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = DATA\RecursosHumanos.db");
        }
    }
}

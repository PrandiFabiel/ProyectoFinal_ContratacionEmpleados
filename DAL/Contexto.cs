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
            //Agregando 5 entidades de permisos
            modelBuilder.Entity<Permisos>().HasData(new Permisos
            {
                PermisoId = 1,
                Descripcion = "PermisoProfe",
                UsuarioId = 1,
                VecesAsignado = 1
            });

            modelBuilder.Entity<Permisos>().HasData(new Permisos
            {
                PermisoId = 2,
                Descripcion = "Permiso2",
                UsuarioId = 1,
                VecesAsignado = 1

            });

            modelBuilder.Entity<Permisos>().HasData(new Permisos
            {
                PermisoId = 3,
                Descripcion = "Permiso3",
                UsuarioId = 1,
                VecesAsignado = 1
            });

            modelBuilder.Entity<Permisos>().HasData(new Permisos
            {
                PermisoId = 4,
                Descripcion = "Permiso4",
                UsuarioId = 1,
                VecesAsignado = 1
            });

            modelBuilder.Entity<Permisos>().HasData(new Permisos
            {
                PermisoId = 5,
                Descripcion = "Permiso5",
                UsuarioId = 1,
                VecesAsignado = 1
            });

            //Agregando 5 entidades de roles
            modelBuilder.Entity<Roles>().HasData(new Roles
            {
                RolId = 1,
                Descripcion = "Administrador",
                UsuarioId = 1
            });

            modelBuilder.Entity<Roles>().HasData(new Roles
            {
                RolId = 2,
                Descripcion = "Empleado",
                UsuarioId = 1
            });

            modelBuilder.Entity<Roles>().HasData(new Roles
            {
                RolId = 3,
                Descripcion = "Tester",
                UsuarioId = 1
            });

            modelBuilder.Entity<Roles>().HasData(new Roles
            {
                RolId = 4,
                Descripcion = "Programador",
                UsuarioId = 1
            });

            modelBuilder.Entity<Roles>().HasData(new Roles
            {
                RolId = 5,
                Descripcion = "Jefe",
                UsuarioId = 1
            });

            //Entidad de Usuarios por defecto del sistema 
            modelBuilder.Entity<Usuarios>().HasData(new Usuarios
            {
                UsuarioId = 1,
                NombreUsuario = "Admin",
                Email = "profe098@gmail.com",
                Clave = "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4",//clave: 1234
                RolId = 1
            });

            //Agregando 5 entidades de provincias
            modelBuilder.Entity<Provincias>().HasData(new Provincias
            {
                ProvinciaId = 1,
                Nombre = "Duarte",
                UsuarioId = 1
            });

            modelBuilder.Entity<Provincias>().HasData(new Provincias
            {
                ProvinciaId = 2,
                Nombre = "Santo Domingo",
                UsuarioId = 1
            });

            modelBuilder.Entity<Provincias>().HasData(new Provincias
            {
                ProvinciaId = 3,
                Nombre = "La Vega",
                UsuarioId = 1
            });

            modelBuilder.Entity<Provincias>().HasData(new Provincias
            {
                ProvinciaId = 4,
                Nombre = "Santiago de los Caballeros",
                UsuarioId = 1
            });

            modelBuilder.Entity<Provincias>().HasData(new Provincias
            {
                ProvinciaId = 5,
                Nombre = "Hermanas Mirabal",
                UsuarioId = 1
            });

            //Agregando 5 entidades de ciudad
            modelBuilder.Entity<Ciudades>().HasData(new Ciudades
            {
                CiudadId = 1,
                Nombre = "San Francisco de Macoris",
                ProvinciaId = 1,
                UsuarioId = 1
            });

            modelBuilder.Entity<Ciudades>().HasData(new Ciudades
            {
                CiudadId = 2,
                Nombre = "Santo Domingo Este",
                ProvinciaId = 2,
                UsuarioId = 1
            });

            modelBuilder.Entity<Ciudades>().HasData(new Ciudades
            {
                CiudadId = 3,
                Nombre = "La Vega",
                ProvinciaId = 3,
                UsuarioId = 1
            });

            modelBuilder.Entity<Ciudades>().HasData(new Ciudades
            {
                CiudadId = 4,
                Nombre = "Santiago",
                ProvinciaId = 4,
                UsuarioId = 1
            });

            modelBuilder.Entity<Ciudades>().HasData(new Ciudades
            {
                CiudadId = 5,
                Nombre = "Salcedo",
                ProvinciaId = 5,
                UsuarioId = 1
            });

            //Agregando 5 entidades de sectores
            modelBuilder.Entity<Sectores>().HasData(new Sectores
            {
                SectorId = 1,
                Nombre = "Cenovi",
                CiudadId = 1,
                UsuarioId = 1
            });

            modelBuilder.Entity<Sectores>().HasData(new Sectores
            {
                SectorId = 2,
                Nombre = "Valle del Este",
                CiudadId = 2,
                UsuarioId = 1
            });

            modelBuilder.Entity<Sectores>().HasData(new Sectores
            {
                SectorId = 3,
                Nombre = "El Ranchito",
                CiudadId = 3,
                UsuarioId = 1
            });

            modelBuilder.Entity<Sectores>().HasData(new Sectores
            {
                SectorId = 4,
                Nombre = "Bella Vista",
                CiudadId = 4,
                UsuarioId = 1
            });

            modelBuilder.Entity<Sectores>().HasData(new Sectores
            {
                SectorId = 5,
                Nombre = "Ojo de agua",
                CiudadId = 5,
                UsuarioId = 1
            });

            //Agregando entidades de Empresas
            modelBuilder.Entity<Empresas>().HasData(new Empresas
            {
                EmpresaId = 1,
                Nombre = "Ferreteria Jordan",
                Puesto = "Vendedor",
                Telefono = "(809)-290-8243",
                Duracion = 9,
                UsuarioId = 1
            });
            modelBuilder.Entity<Empresas>().HasData(new Empresas
            {
                EmpresaId = 2,
                Nombre = "Ferreteria INCOROSA",
                Puesto = "Vendedor",
                Duracion = 3,
                Telefono = "(809)-725-0577",
                UsuarioId = 1
            });
            
            //Agregando entidades de genero
            modelBuilder.Entity<Generos>().HasData(new Generos
            {
                GeneroId = 1,
                Descripcion = "Masculino",
                UsuarioId = 1
            });

            modelBuilder.Entity<Generos>().HasData(new Generos
            {
                GeneroId = 2,
                Descripcion = "Femenino",
                UsuarioId = 1
            });
            modelBuilder.Entity<Generos>().HasData(new Generos
            {
                GeneroId = 3,
                Descripcion = "Homosexual",
                UsuarioId = 1
            });
            modelBuilder.Entity<Generos>().HasData(new Generos
            {
                GeneroId = 4,
                Descripcion = "Transexual",
                UsuarioId = 1
            });
            modelBuilder.Entity<Generos>().HasData(new Generos
            {
                GeneroId = 5,
                Descripcion = "Bisexual",
                UsuarioId = 1
            });

            modelBuilder.Entity<Departamentos>().HasData(new Departamentos
            {
                DepartamentoId = 1,
                Nombre = "Ventas",
                UsuarioId = 1
            });

            modelBuilder.Entity<Departamentos>().HasData(new Departamentos
            {
                DepartamentoId = 2,
                Nombre = "Compras",
                UsuarioId = 1
            });

            modelBuilder.Entity<Departamentos>().HasData(new Departamentos
            {
                DepartamentoId = 3,
                Nombre = "TI",
                UsuarioId = 1
            });

            modelBuilder.Entity<Departamentos>().HasData(new Departamentos
            {
                DepartamentoId = 4,
                Nombre = "Recursos Humanos",
                UsuarioId = 1
            });

            modelBuilder.Entity<Departamentos>().HasData(new Departamentos
            {
                DepartamentoId = 5,
                Nombre = "Mantenimiento",
                UsuarioId = 1
            });

            modelBuilder.Entity<Habilidades>().HasData(new Habilidades
            {
                HabilidadId = 1,
                Descripcion = "Liderazgo",
                UsuarioId = 1
            });

            modelBuilder.Entity<Habilidades>().HasData(new Habilidades
            {
                HabilidadId = 2,
                Descripcion = "Actitud positiva",
                UsuarioId = 1
            });

            modelBuilder.Entity<Habilidades>().HasData(new Habilidades
            {
                HabilidadId = 3,
                Descripcion = "Adaptabilidad y flexibilidad",
                UsuarioId = 1
            });

            modelBuilder.Entity<Habilidades>().HasData(new Habilidades
            {
                HabilidadId = 4,
                Descripcion = "Comunicación",
                UsuarioId = 1
            });

            modelBuilder.Entity<Habilidades>().HasData(new Habilidades
            {
                HabilidadId = 5,
                Descripcion = "Trabajo en equipo",
                UsuarioId = 1
            });



        }
    }
}

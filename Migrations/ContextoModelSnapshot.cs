﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoFinal_ContratacionEmpleados.DAL;

namespace ProyectoFinal_ContratacionEmpleados.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("ProyectoFinal_ContratacionEmpleados.Entidades.Ciudades", b =>
                {
                    b.Property<int>("CiudadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProvinciaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CiudadId");

                    b.HasIndex("ProvinciaId");

                    b.ToTable("Ciudades");
                });

            modelBuilder.Entity("ProyectoFinal_ContratacionEmpleados.Entidades.Departamentos", b =>
                {
                    b.Property<int>("DepartamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("DepartamentoId");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("ProyectoFinal_ContratacionEmpleados.Entidades.Empresas", b =>
                {
                    b.Property<int>("EmpresaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefono")
                        .HasColumnType("TEXT");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("EmpresaId");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("ProyectoFinal_ContratacionEmpleados.Entidades.Generos", b =>
                {
                    b.Property<int>("GeneroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("GeneroId");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("ProyectoFinal_ContratacionEmpleados.Entidades.Habilidades", b =>
                {
                    b.Property<int>("HabilidadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VecesAsignada")
                        .HasColumnType("INTEGER");

                    b.HasKey("HabilidadId");

                    b.ToTable("Habilidades");
                });

            modelBuilder.Entity("ProyectoFinal_ContratacionEmpleados.Entidades.Permisos", b =>
                {
                    b.Property<int>("PermisoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VecesAsignado")
                        .HasColumnType("INTEGER");

                    b.HasKey("PermisoId");

                    b.ToTable("Permisos");
                });

            modelBuilder.Entity("ProyectoFinal_ContratacionEmpleados.Entidades.Personas", b =>
                {
                    b.Property<int>("PersonaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Apellidos")
                        .HasColumnType("TEXT");

                    b.Property<string>("Cedula")
                        .HasColumnType("TEXT");

                    b.Property<string>("Celular")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<int>("GeneroId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NombreReferenciaFamiliar")
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreReferenciaPersonal")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombres")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProvinciaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Telefono")
                        .HasColumnType("TEXT");

                    b.Property<string>("TelefonoReferenciaFamiliar")
                        .HasColumnType("TEXT");

                    b.Property<string>("TelefonoReferenciaPersonal")
                        .HasColumnType("TEXT");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VacanteId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PersonaId");

                    b.HasIndex("GeneroId");

                    b.HasIndex("ProvinciaId");

                    b.HasIndex("VacanteId");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("ProyectoFinal_ContratacionEmpleados.Entidades.PersonasDetalle", b =>
                {
                    b.Property<int>("PersonasDetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PersonaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PersonasDetalleId");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("PersonaId");

                    b.ToTable("PersonasDetalle");
                });

            modelBuilder.Entity("ProyectoFinal_ContratacionEmpleados.Entidades.Provincias", b =>
                {
                    b.Property<int>("ProvinciaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProvinciaId");

                    b.ToTable("Provincias");
                });

            modelBuilder.Entity("ProyectoFinal_ContratacionEmpleados.Entidades.Roles", b =>
                {
                    b.Property<int>("RolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("RolId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ProyectoFinal_ContratacionEmpleados.Entidades.RolesDetalle", b =>
                {
                    b.Property<int>("RolDetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DescripcionPermiso")
                        .HasColumnType("TEXT");

                    b.Property<int>("PermisoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RolId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VecesAsignado")
                        .HasColumnType("INTEGER");

                    b.HasKey("RolDetalleId");

                    b.HasIndex("RolId");

                    b.ToTable("RolesDetalle");
                });

            modelBuilder.Entity("ProyectoFinal_ContratacionEmpleados.Entidades.Sectores", b =>
                {
                    b.Property<int>("SectorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CiudadId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("SectorId");

                    b.HasIndex("CiudadId");

                    b.ToTable("Sectores");
                });

            modelBuilder.Entity("ProyectoFinal_ContratacionEmpleados.Entidades.Usuarios", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Clave")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaRegistroUsuario")
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreUsuario")
                        .HasColumnType("TEXT");

                    b.Property<int?>("RolId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UsuarioId");

                    b.HasIndex("RolId");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            UsuarioId = 1,
                            Clave = "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4",
                            Email = "profe098@gmail.com",
                            FechaRegistroUsuario = new DateTime(2021, 11, 21, 19, 35, 16, 861, DateTimeKind.Local).AddTicks(9345),
                            NombreUsuario = "Admin"
                        });
                });

            modelBuilder.Entity("ProyectoFinal_ContratacionEmpleados.Entidades.Vacantes", b =>
                {
                    b.Property<int>("VacanteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DepartamentoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<int>("Disponible")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreVacante")
                        .HasColumnType("TEXT");

                    b.Property<string>("Requisitos")
                        .HasColumnType("TEXT");

                    b.Property<int>("UsusarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("VacanteId");

                    b.HasIndex("DepartamentoId");

                    b.ToTable("Vacantes");
                });

            modelBuilder.Entity("ProyectoFinal_ContratacionEmpleados.Entidades.VacantesDetalle", b =>
                {
                    b.Property<int>("VacanteDetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("HabilidadId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VacanteId")
                        .HasColumnType("INTEGER");

                    b.HasKey("VacanteDetalleId");

                    b.HasIndex("HabilidadId");

                    b.HasIndex("VacanteId");

                    b.ToTable("VacantesDetalle");
                });

            modelBuilder.Entity("ProyectoFinal_ContratacionEmpleados.Entidades.Ciudades", b =>
                {
                    b.HasOne("ProyectoFinal_ContratacionEmpleados.Entidades.Provincias", "Provincias")
                        .WithMany()
                        .HasForeignKey("ProvinciaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Provincias");
                });

            modelBuilder.Entity("ProyectoFinal_ContratacionEmpleados.Entidades.Personas", b =>
                {
                    b.HasOne("ProyectoFinal_ContratacionEmpleados.Entidades.Generos", "Genero")
                        .WithMany()
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoFinal_ContratacionEmpleados.Entidades.Provincias", "Provincia")
                        .WithMany()
                        .HasForeignKey("ProvinciaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoFinal_ContratacionEmpleados.Entidades.Vacantes", "Vacante")
                        .WithMany()
                        .HasForeignKey("VacanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genero");

                    b.Navigation("Provincia");

                    b.Navigation("Vacante");
                });

            modelBuilder.Entity("ProyectoFinal_ContratacionEmpleados.Entidades.PersonasDetalle", b =>
                {
                    b.HasOne("ProyectoFinal_ContratacionEmpleados.Entidades.Empresas", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoFinal_ContratacionEmpleados.Entidades.Personas", null)
                        .WithMany("Detalle")
                        .HasForeignKey("PersonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("ProyectoFinal_ContratacionEmpleados.Entidades.RolesDetalle", b =>
                {
                    b.HasOne("ProyectoFinal_ContratacionEmpleados.Entidades.Roles", null)
                        .WithMany("RolesDetalle")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProyectoFinal_ContratacionEmpleados.Entidades.Sectores", b =>
                {
                    b.HasOne("ProyectoFinal_ContratacionEmpleados.Entidades.Ciudades", "Ciudades")
                        .WithMany()
                        .HasForeignKey("CiudadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ciudades");
                });

            modelBuilder.Entity("ProyectoFinal_ContratacionEmpleados.Entidades.Usuarios", b =>
                {
                    b.HasOne("ProyectoFinal_ContratacionEmpleados.Entidades.Roles", "Roles")
                        .WithMany()
                        .HasForeignKey("RolId");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("ProyectoFinal_ContratacionEmpleados.Entidades.Vacantes", b =>
                {
                    b.HasOne("ProyectoFinal_ContratacionEmpleados.Entidades.Departamentos", "Departamento")
                        .WithMany()
                        .HasForeignKey("DepartamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamento");
                });

            modelBuilder.Entity("ProyectoFinal_ContratacionEmpleados.Entidades.VacantesDetalle", b =>
                {
                    b.HasOne("ProyectoFinal_ContratacionEmpleados.Entidades.Habilidades", "Habilidad")
                        .WithMany()
                        .HasForeignKey("HabilidadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoFinal_ContratacionEmpleados.Entidades.Vacantes", null)
                        .WithMany("VacantesDetalle")
                        .HasForeignKey("VacanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Habilidad");
                });

            modelBuilder.Entity("ProyectoFinal_ContratacionEmpleados.Entidades.Personas", b =>
                {
                    b.Navigation("Detalle");
                });

            modelBuilder.Entity("ProyectoFinal_ContratacionEmpleados.Entidades.Roles", b =>
                {
                    b.Navigation("RolesDetalle");
                });

            modelBuilder.Entity("ProyectoFinal_ContratacionEmpleados.Entidades.Vacantes", b =>
                {
                    b.Navigation("VacantesDetalle");
                });
#pragma warning restore 612, 618
        }
    }
}

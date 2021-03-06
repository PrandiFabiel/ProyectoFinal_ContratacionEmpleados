// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoFinal_ContratacionEmpleados.DAL;

namespace ProyectoFinal_ContratacionEmpleados.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20211120022335_Agregando_Entidades_Habilidades_Departamentos_VacantesDetalle")]
    partial class Agregando_Entidades_Habilidades_Departamentos_VacantesDetalle
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

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

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");
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

            modelBuilder.Entity("ProyectoFinal_ContratacionEmpleados.Entidades.Vacantes", b =>
                {
                    b.Navigation("VacantesDetalle");
                });
#pragma warning restore 612, 618
        }
    }
}

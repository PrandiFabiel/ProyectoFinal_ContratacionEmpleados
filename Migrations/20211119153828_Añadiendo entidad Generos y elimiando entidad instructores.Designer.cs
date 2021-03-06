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
    [Migration("20211119153828_Añadiendo entidad Generos y elimiando entidad instructores")]
    partial class AñadiendoentidadGenerosyelimiandoentidadinstructores
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

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

                    b.Property<string>("DescripcionVacante")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaDeRegistroVacante")
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreDeVacante")
                        .HasColumnType("TEXT");

                    b.Property<string>("RequisitosVacante")
                        .HasColumnType("TEXT");

                    b.HasKey("VacanteId");

                    b.ToTable("Vacantes");
                });
#pragma warning restore 612, 618
        }
    }
}

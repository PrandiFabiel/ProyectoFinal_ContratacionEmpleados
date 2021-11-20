﻿using ProyectoFinal_ContratacionEmpleados.BLL;
using ProyectoFinal_ContratacionEmpleados.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProyectoFinal_ContratacionEmpleados.UI.Registros
{
    /// <summary>
    /// Interaction logic for rHabilidades.xaml
    /// </summary>
    public partial class rHabilidades : Window
    {
        Habilidades habilidad = new Habilidades();

        public rHabilidades()
        {
            InitializeComponent();
            this.DataContext = habilidad;
        }

        private void Limpiar()
        {
            this.habilidad = new Habilidades();
            DescripcionTextBox.Text = "";
            VecesAsignadaTextBox.Text = "";
            this.DataContext = habilidad;
        }

        private bool Validar()
        {
            bool esValido = true;

            if (DescripcionTextBox.Text.Length == 0)
            {
                esValido = false;

                MessageBox.Show("El campo Descripcion está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                DescripcionTextBox.Focus();
            }

            if (HabilidadesBLL.ExisteDescripcion(DescripcionTextBox.Text) == true)
            {
                esValido = false;

                MessageBox.Show("Ya existe una Habilidad con esta descripcion!", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                HabilidadIdTextBox.Focus();
            }

            return esValido;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var habili = HabilidadesBLL.Buscar(Utilidades.ToInt(HabilidadIdTextBox.Text));

            if (habilidad != null)
                this.habilidad = habili;
            else
                this.habilidad = new Habilidades();

            this.DataContext = this.habilidad;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = HabilidadesBLL.Guardar(habilidad);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transaccione exitosa!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Transaccion Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (HabilidadesBLL.Eliminar(Utilidades.ToInt(HabilidadIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}

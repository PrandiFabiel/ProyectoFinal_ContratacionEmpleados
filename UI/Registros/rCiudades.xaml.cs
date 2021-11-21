using ProyectoFinal_ContratacionEmpleados.BLL;
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
    /// Interaction logic for rCiudades.xaml
    /// </summary>
    public partial class rCiudades : Window
    {
        Provincias provincia = new();
        public rCiudades()
        {
            InitializeComponent();
            this.DataContext = ciudad;

            ProvinciaComboBox.ItemsSource = ProvinciasBLL.GetProvincias();
            ProvinciaComboBox.SelectedValuePath = "ProvinciaId";
            ProvinciaComboBox.DisplayMemberPath = "Nombre"; 
        }

        private Ciudades ciudad = new Ciudades();

        private void Limpiar()
        {
            this.ciudad = new Ciudades();
            NombreTextBox.Text = "";
            this.DataContext = ciudad;
        }

        private bool Validar()
        {
            bool esValido = true;

            if (NombreTextBox.Text.Length == 0)
            {
                esValido = false;

                MessageBox.Show("El campo Descripcion está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                NombreTextBox.Focus();
            }

            return esValido;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var ciudadB = CiudadesBLL.Buscar(Utilidades.ToInt(CiudadIdTextBox.Text));

            if (ciudad != null)
                this.ciudad = ciudadB;
            else
                this.ciudad = new Ciudades();

            this.DataContext = this.ciudad;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = CiudadesBLL.Guardar(ciudad);

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
            if (CiudadesBLL.Eliminar(Utilidades.ToInt(CiudadIdTextBox.Text)))
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

using ProyectoFinal_ContratacionEmpleados.BLL;
using ProyectoFinal_ContratacionEmpleados.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            if (ProvinciaComboBox.Text.Length == 0)
            {
                esValido = false;

                MessageBox.Show("Provincia está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                ProvinciaComboBox.Focus();
            }

            return esValido;
        }
        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = ciudad;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Ciudades encontrado = CiudadesBLL.Buscar(ciudad.CiudadId);

            if (encontrado != null)
            {
                ciudad = encontrado;
                Cargar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("Ciudad no existe en la base de datos", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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

        private void CiudadIdTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}

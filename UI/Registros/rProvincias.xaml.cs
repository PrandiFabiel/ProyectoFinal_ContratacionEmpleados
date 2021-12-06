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
    /// Interaction logic for rProvincias.xaml
    /// </summary>
    public partial class rProvincias : Window
    {
        private Provincias Provincia = new Provincias();
        public rProvincias()
        {
            InitializeComponent();
            this.DataContext = Provincia;
        }

        private void Limpiar()
        {
            this.Provincia = new Provincias();
            this.DataContext = Provincia;
        }

        private bool validar()
        {
            bool esValido = true;

            if (NombreTextbox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta el nombre", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                NombreTextbox.Focus();
            }

            if (ProvinciasBLL.ExisteNombre(NombreTextbox.Text) == true)
            {
                esValido = false;

                MessageBox.Show("Ya existe una Provincia con este nombre!", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                NombreTextbox.Focus();
            }


            return esValido;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var provincia = ProvinciasBLL.Buscar(Provincia.ProvinciaId);

            if (provincia != null)
            {
                this.Provincia = provincia;
                this.DataContext = Provincia;
            }
            else
            {
                Limpiar();
                MessageBox.Show("No existe en la base de datos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!validar())
                return; 

            bool paso = ProvinciasBLL.Guardar(Provincia);

            if (paso)
            {  
                Limpiar();
                MessageBox.Show("Transaccion exitosa!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Transaccion Fallida", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProvinciasBLL.Eliminar(Provincia.ProvinciaId))
            {
                Limpiar();
                MessageBox.Show("Registro Eliminado!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No fue posible eliminar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

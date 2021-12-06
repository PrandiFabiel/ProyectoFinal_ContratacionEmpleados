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
    /// Interaction logic for rSectores.xaml
    /// </summary>
    public partial class rSectores : Window
    {
        private Sectores sector = new Sectores();

        public rSectores()
        {
            InitializeComponent();
            this.DataContext = sector;

            CiudadComboBox.ItemsSource = CiudadesBLL.GetCiudades();
            CiudadComboBox.SelectedValuePath = "CiudadId";
            CiudadComboBox.DisplayMemberPath = "Nombre";
        }

        private void Limpiar()
        {
            this.sector = new Sectores();
            NombreTextBox.Text = "";
            this.DataContext = sector;
        }

        private bool Validar()
        {
            bool esValido = true;

            if (NombreTextBox.Text.Length == 0)
            {
                esValido = false;

                MessageBox.Show("El campo Nombre está vacio", "Advertencia",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                NombreTextBox.Focus();
            }

            if (CiudadComboBox.Text.Length == 0)
            {
                esValido = false;

                MessageBox.Show("El campo Ciudad está vacio", "Advertencia",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                CiudadComboBox.Focus();
            }

            if (SectoresBLL.ExisteNombre(NombreTextBox.Text) == true)
            {
                esValido = false;

                MessageBox.Show("Ya existe un Sector con este nombre!", "Advertencia",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                NombreTextBox.Focus();
            }

            return esValido;
        }


        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var Sector = SectoresBLL.Buscar(sector.SectorId);

            if (Sector != null)
            {
                this.sector = Sector;
                this.DataContext = sector;
            }
            else
            {
                Limpiar();
                MessageBox.Show("Sector no existe en la base de datos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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

            var paso = SectoresBLL.Guardar(sector);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transaccion exitosa!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Transaccion Fallida!", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (SectoresBLL.Eliminar(Utilidades.ToInt(SectorIdTextBox.Text)))
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

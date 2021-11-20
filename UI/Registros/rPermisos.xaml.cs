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
    /// Interaction logic for rPermisos.xaml
    /// </summary>
    public partial class rPermisos : Window
    {
        public rPermisos()
        {
            InitializeComponent();
        }

        private Permisos permiso = new Permisos();

        private void Limpiar()
        {
            this.permiso = new Permisos();
            DescripcionTextBox.Text = "";
            VecesAsignadoTextBox.Text = "";
            this.DataContext = permiso;
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

            if (PermisosBLL.ExisteDescripcion(DescripcionTextBox.Text) == true)
            {
                esValido = false;

                MessageBox.Show("Ya existe una Habilidad con esta descripcion!", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                PermisoIdTextBox.Focus();
            }

            return esValido;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var permisoB = PermisosBLL.Buscar(Utilidades.ToInt(PermisoIdTextBox.Text));

            if (permiso != null)
                this.permiso = permisoB;
            else
                this.permiso = new Permisos();

            this.DataContext = this.permiso;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = PermisosBLL.Guardar(permiso);

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
            if (PermisosBLL.Eliminar(Utilidades.ToInt(PermisoIdTextBox.Text)))
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

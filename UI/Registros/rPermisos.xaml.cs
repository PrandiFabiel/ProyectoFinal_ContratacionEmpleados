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
        private Permisos permiso = new Permisos();
        public rPermisos()
        {
            InitializeComponent();
            this.DataContext = permiso; 
        }


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

                MessageBox.Show("Ya existe un permiso con esta descripcion!", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                PermisoIdTextBox.Focus();
            }

            return esValido;
        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = permiso;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Permisos encontrado = PermisosBLL.Buscar(permiso.PermisoId);

            if (encontrado != null)
            {
                permiso = encontrado;
                Cargar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("Permiso no existe en la base de datos", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
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

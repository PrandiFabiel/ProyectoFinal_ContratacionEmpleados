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
    /// Interaction logic for rRoles.xaml
    /// </summary>
    public partial class rRoles : Window
    {
        private Roles Rol = new Roles();
        Permisos permisos = new();
        public rRoles()
        {
            InitializeComponent();
            this.DataContext = Rol;

            PermisoComboBox.ItemsSource = PermisosBLL.GetPermisos();
            PermisoComboBox.SelectedValuePath = "PermisoId";
            PermisoComboBox.DisplayMemberPath = "Descripcion";

        }


        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = Rol;
        }
        private void Limpiar()
        {
            this.Rol = new Roles();
            this.DataContext = Rol;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Roles encontrado = RolesBLL.Buscar(Rol.RolId);

            if (encontrado != null)
            {
                Rol = encontrado;
                Cargar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("Rol no existe en la base de datos", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AgregarFilaButton_Click(object sender, RoutedEventArgs e)
        {
            if (PermisoComboBox.Text.Length == 0)
            {
                MessageBox.Show("Debe eligir un permiso", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                Rol.RolesDetalle.Add(new RolesDetalle
                {
                    RolId = Rol.RolId,
                    PermisoId = (int)PermisoComboBox.SelectedValue,
                    DescripcionPermiso = PermisosBLL.GetDescripcion((int)PermisoComboBox.SelectedValue),
                    VecesAsignado = PermisosBLL.GetVecesAsignado((int)PermisoComboBox.SelectedValue)
                });

                Cargar();
            }
        }

        private void RemoverFilaButton_Click(object sender, RoutedEventArgs e)
        {
            if (DetalleDataGrid.Items.Count >= 1 && DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1)
            {
                Rol.RolesDetalle.RemoveAt(DetalleDataGrid.SelectedIndex);
                Cargar();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
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

            var paso = RolesBLL.Guardar(Rol);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Fallo al guardar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);


        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            Roles existe = RolesBLL.Buscar(Rol.RolId);

            if (existe == null)
            {
                MessageBox.Show("No existe el grupo en la base de datos", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                RolesBLL.Eliminar(Rol.RolId);
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
        }

        private bool Validar()
        {
            bool esValido = true;

            if (DescripcionTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Descripcion no puede está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                DescripcionTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (PermisoComboBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Permiso no puede está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                PermisoComboBox.Focus();
                GuardarButton.IsEnabled = true;
            }
            return esValido;
        }
    }
}

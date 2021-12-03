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
    /// Interaction logic for rUsuarios.xaml
    /// </summary>
    public partial class rNewUser : Window
    {
        private Usuarios usuario = new Usuarios();
        Roles roles = new();
        public rNewUser()
        {
            InitializeComponent();
            this.DataContext = usuario;

            NewRolComboBox.ItemsSource = RolesBLL.GetRoles();
            NewRolComboBox.SelectedValuePath = "RolId";
            NewRolComboBox.DisplayMemberPath = "Descripcion";
        }

        private void Limpiar()
        {
            this.usuario = new Usuarios();
            NewClavePasswordBox.Password = string.Empty;
            NewConfirmarClavePasswordBox.Password = string.Empty;
            this.DataContext = usuario;
        }


        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = UsuariosBLL.Guardar(usuario);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transaccion exitosa!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
                MessageBox.Show("Transaccion Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private bool Validar()
        {
            bool esValido = true;

            if (NewNombreUsuarioTextBox.Text.Length == 0)
            {
                esValido = false;
                NewGuardarButton.IsEnabled = false;
                MessageBox.Show("Nombres está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                NewNombreUsuarioTextBox.Focus();
                NewGuardarButton.IsEnabled = true;
            }

            if (NewEmailTextBox.Text.Length == 0)
            {
                esValido = false;
                NewGuardarButton.IsEnabled = false;
                MessageBox.Show("Apellidos está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                NewEmailTextBox.Focus();
                NewGuardarButton.IsEnabled = true;
            }

            if (NewNombreUsuarioTextBox.Text.Length == 0)
            {
                esValido = false;
                NewGuardarButton.IsEnabled = false;
                MessageBox.Show("Nombre usuario está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                NewNombreUsuarioTextBox.Focus();
                NewGuardarButton.IsEnabled = true;
            }

            if (NewClavePasswordBox.Password.Length == 0)
            {
                esValido = false;
                NewGuardarButton.IsEnabled = false;
                MessageBox.Show("Contraseña está vacia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                NewClavePasswordBox.Focus();
                NewGuardarButton.IsEnabled = true;
            }

            if (NewConfirmarClavePasswordBox.Password.Length == 0)
            {
                esValido = false;
                NewGuardarButton.IsEnabled = false;
                MessageBox.Show("Confirmar contraseña está vacia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                NewConfirmarClavePasswordBox.Focus();
                NewGuardarButton.IsEnabled = true;
            }

            if (NewConfirmarClavePasswordBox.Password != NewClavePasswordBox.Password)
            {
                esValido = false;
                NewGuardarButton.IsEnabled = false;
                MessageBox.Show("Las claves no coiciden", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                NewConfirmarClavePasswordBox.Focus();
                NewGuardarButton.IsEnabled = true;
            }


            return esValido;
        }
    }
}

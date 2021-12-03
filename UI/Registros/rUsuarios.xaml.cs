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
    public partial class rUsuarios : Window
    {
        private Usuarios usuario = new Usuarios();
        Roles roles = new(); 
        public rUsuarios()
        { 
            InitializeComponent();
            this.DataContext = usuario;

            RolComboBox.ItemsSource = RolesBLL.GetRoles();
            RolComboBox.SelectedValuePath = "RolId";
            RolComboBox.DisplayMemberPath = "Descripcion"; 
        }

        private void Limpiar()
        {
            this.usuario = new Usuarios();
            ClavePasswordBox.Password = string.Empty;
            ConfirmarClavePasswordBox.Password = string.Empty;
            this.DataContext = usuario;
        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = usuario;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Usuarios encontrado = UsuariosBLL.Buscar(usuario.UsuarioId);

            if (encontrado != null)
            {
                usuario = encontrado;
                Cargar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("Usuario no existe en la base de datos", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
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

            var paso = UsuariosBLL.Guardar(usuario);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transaccion exitosa!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Transaccion Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsuariosBLL.Eliminar(Convert.ToInt32(UsuarioIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private bool Validar()
        {
            bool esValido = true;

            if (NombreUsuarioTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Nombres está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                NombreUsuarioTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (EmailTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Apellidos está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                EmailTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (NombreUsuarioTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Nombre usuario está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                NombreUsuarioTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (ClavePasswordBox.Password.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Contraseña está vacia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                ClavePasswordBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (ConfirmarClavePasswordBox.Password.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Confirmar contraseña está vacia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                ConfirmarClavePasswordBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (ConfirmarClavePasswordBox.Password != ClavePasswordBox.Password)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Las claves no coiciden", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                ConfirmarClavePasswordBox.Focus();
                GuardarButton.IsEnabled = true;
            }


            return esValido;
        }
    }
}

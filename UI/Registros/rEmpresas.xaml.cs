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
    /// Interaction logic for rEmpresas.xaml
    /// </summary>
    public partial class rEmpresas : Window
    {
        private Empresas Empresa = new Empresas();
        public rEmpresas()
        {
            InitializeComponent();
            this.DataContext = Empresa;
        }

        private void Limpiar()
        {
            this.Empresa = new Empresas();
            this.DataContext = Empresa;
        }

        private bool validar()
        {
            bool esValido = true;

            if (NombreTextbox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta el Nombre", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                NombreTextbox.Focus();
            }

            if (TelefonoTextbox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta el Telefono", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (TelefonoTextbox.Text.Length != 14)
            {
                esValido = false;
                MessageBox.Show("Telefono no valido, debe agregar numero de telefono (xxx)-xxx-xxxx", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
           
            if (PuestoTextbox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta el campo Puesto de trabajo", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (DuracionTextbox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta el campo Duracion", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return esValido;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var empresa = EmpresasBLL.Buscar(Empresa.EmpresaId);

            if (empresa != null)
            {
                this.Empresa = empresa;
                this.DataContext = Empresa;
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
            bool paso = EmpresasBLL.Guardar(Empresa);

            if (!validar())
                return;

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
            if (EmpresasBLL.Eliminar(Empresa.EmpresaId))
            {
                Limpiar();
                MessageBox.Show("Registro Eliminado!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No fue posible eliminar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DuracionTextbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TelefonoTextbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9-()]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void EmpresaIdTextbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}

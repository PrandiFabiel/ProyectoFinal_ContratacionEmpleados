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
    /// Interaction logic for rDepartamentos.xaml
    /// </summary>
    public partial class rDepartamentos : Window
    {
        Departamentos departamento = new Departamentos();

        public rDepartamentos()
        {
            InitializeComponent();
            this.DataContext = departamento;
        }

        private void Limpiar()
        {
            this.departamento = new Departamentos();
            NombreTextBox.Text= "";
            this.DataContext = departamento;
        }

        private bool Validar()
        {
            bool esValido = true;

            if (NombreTextBox.Text.Length == 0)
            {
                esValido = false;
                
                MessageBox.Show("El campo Nombre está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                NombreTextBox.Focus();
            }

            if (DepartamentosBLL.ExisteNombre(NombreTextBox.Text) == true)
            {
                esValido = false;

                MessageBox.Show("Ya existe un departamento con este nombre!", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                NombreTextBox.Focus();
            }

            return esValido;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var Departamento = DepartamentosBLL.Buscar(departamento.DepartamentoId);

            if (Departamento != null)
            {
                this.departamento = Departamento;
                this.DataContext = departamento;
            }
            else
            {
                Limpiar();
                MessageBox.Show("Departemento no existe en la base de datos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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

            var paso = DepartamentosBLL.Guardar(departamento);

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
            if (DepartamentosBLL.Eliminar(Utilidades.ToInt(DepartamentoIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void DepartamentoIdTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}

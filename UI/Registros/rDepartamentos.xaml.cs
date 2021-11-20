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
            var depar = DepartamentosBLL.Buscar(Utilidades.ToInt(DepartamentoIdTextBox.Text));

            if (departamento != null)
                this.departamento = depar;
            else
                this.departamento = new Departamentos();

            this.DataContext = this.departamento;
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
    }
}

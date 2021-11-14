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
    /// Interaction logic for rInstructores.xaml
    /// </summary>
    public partial class rInstructores : Window
    {
        private Instructores Instructor = new Instructores();
        public rInstructores()
        {
            InitializeComponent();
            this.DataContext = Instructor;
        }


        private void Limpiar()
        {
            this.Instructor = new Instructores();
            this.DataContext = Instructor;
        }

        private bool validar()
        {
            bool esValido = true;
            if(NombreInstructorTextbox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta el Nombre", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (ApellidosInstructorTextbox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta Apellidos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (TelefonoInstructorTextbox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta el Numero telefonico", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return esValido;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var instructor = InstructoresBLL.Buscar(Utilidades.ToInt(InstructorIdTextbox.Text));

            if(instructor != null)
            {
                this.Instructor = instructor;
                this.DataContext = instructor;
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

            var paso = InstructoresBLL.Guardar(Instructor);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transaccion exitosa!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Transaccion fallida!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (InstructoresBLL.Eliminar(Utilidades.ToInt(InstructorIdTextbox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No fue posible eliminar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

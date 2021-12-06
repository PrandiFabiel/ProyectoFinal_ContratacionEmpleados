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
    /// Interaction logic for rGeneros.xaml
    /// </summary>
    public partial class rGeneros : Window
    {
        private Generos Genero = new Generos();
        public rGeneros()
        {
            InitializeComponent();
            this.DataContext = Genero;
        }

        private void Limpiar()
        {
            this.Genero = new Generos();
            this.DataContext = Genero;
        }

        private bool validar()
        {
            bool esValido = true;

            if(DescripcionTextbox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta la descripcion", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (GenerosBLL.ExisteNombre(DescripcionTextbox.Text)==true)
            {
                esValido = false;

                MessageBox.Show("Ya existe un Genero con este nombre!", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                DescripcionTextbox.Focus();
            }
            return esValido;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var genero = GenerosBLL.Buscar(Utilidades.ToInt(GeneroIdTextbox.Text));

            if(genero != null)
            {
                this.Genero = genero;
                this.DataContext = Genero;
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

            bool paso = GenerosBLL.Guardar(Genero);

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
            if (GenerosBLL.Eliminar(Utilidades.ToInt(GeneroIdTextbox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro Eliminado!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No fue posible eliminar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

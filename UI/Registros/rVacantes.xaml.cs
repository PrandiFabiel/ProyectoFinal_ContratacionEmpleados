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
    /// Interaction logic for rVacantes.xaml
    /// </summary>
    public partial class rVacantes : Window
    {
        Vacantes vacante = new Vacantes();

        public rVacantes()
        {
            InitializeComponent();
            this.DataContext = vacante;
        }

        private void Limpiar()
        {
            this.vacante = new Vacantes();
            this.DataContext = vacante;
        }

        private bool Validar()
        {
            bool esValido = true;


            if (NombreVacante_TextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("El Campo Nombre no puede estar vacio", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            /*if (DepartamentoComboBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("El Campo Departamento no puede estar vacio", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }*/
            if (Requisitos_TextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("El Campo Requisitos no Puede estar vacio", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (Descripcion_TextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("El Campo Descripcion no Puede estar vacio", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return esValido;

        }

        private void Buscar_Button_Click(object sender, RoutedEventArgs e)
        {
            var vacante = VacantesBLL.Buscar(Utilidades.ToInt(VacanteId_TextBox.Text));
            if (vacante == null)
                MessageBox.Show("No existe vacante con ese id", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            if (vacante != null)
                this.vacante = vacante;
            else
                vacante = new Vacantes();
            this.DataContext = this.vacante;
        }

        private void Nuevo_Button_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void Guardar_Button_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = VacantesBLL.Guardar(vacante);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transacion Exitosa", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void Eliminar_Button_Click(object sender, RoutedEventArgs e)
        {
            if (VacantesBLL.Eliminar(Utilidades.ToInt(VacanteId_TextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}

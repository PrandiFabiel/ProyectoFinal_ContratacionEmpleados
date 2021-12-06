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

namespace ProyectoFinal_ContratacionEmpleados.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cHabilidadesPorVacantes.xaml
    /// </summary>
    public partial class cHabilidadesPorVacantes : Window
    {
        public cHabilidadesPorVacantes()
        {
            InitializeComponent();
        }

        private void Buscar_Button_Click(object sender, RoutedEventArgs e)
        {
            List<VacantesDetalle> listado = new List<VacantesDetalle>();

            if (IdVacante_TextBox.Text.Trim().Length > 0)
            {
                try
                {
                    listado = VacantesBLL.GetListDetalle(Utilidades.ToInt(IdVacante_TextBox.Text));

                }
                catch (FormatException)
                {
                    MessageBox.Show("Debes ingresar un Critero valido.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Debes ingresar un Id de Vacante.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;

            var conteo = listado.Count;
            ConteoTextbox.Text = conteo.ToString();
            if (conteo == 0)
            {
                MessageBox.Show("No existe Vacante con este Id!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                IdVacante_TextBox.Focus();
            }
        }
    }
}

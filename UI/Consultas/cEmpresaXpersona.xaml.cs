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
    /// Interaction logic for cEmpresaXpersona.xaml
    /// </summary>
    public partial class cEmpresaXpersona : Window
    {
        public cEmpresaXpersona()
        {
            InitializeComponent();
        }

        private void Buscar_Button_Click(object sender, RoutedEventArgs e)
        {
            List<PersonasDetalle> listado = new List<PersonasDetalle>();

            if (PersonaId_TextBox.Text.Trim().Length > 0)
            {
                try
                {
                    listado = PersonasBLL.GetListDetalle(Utilidades.ToInt(PersonaId_TextBox.Text));

                }
                catch (FormatException)
                {
                    MessageBox.Show("Debes ingresar un Critero valido.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Debes ingresar un Id de Persona.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                PersonaId_TextBox.Focus();
            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;

            var conteo = listado.Count;
            ConteoTextbox.Text = conteo.ToString();
            if (conteo == 0)
            {
                MessageBox.Show("No existe Persona con este Id!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                PersonaId_TextBox.Focus();
            }
        }
    }
}

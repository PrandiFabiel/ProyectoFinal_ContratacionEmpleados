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
    /// Interaction logic for cPermisoPorRoles.xaml
    /// </summary>
    public partial class cPermisoPorRoles : Window
    {
        public cPermisoPorRoles()
        {
            InitializeComponent();
        }

        private void Buscar_Button_Click(object sender, RoutedEventArgs e)
        {
            List<RolesDetalle> listado = new List<RolesDetalle>();

            if (IdRol_TextBox.Text.Trim().Length > 0)
            {
                try
                {
                    listado = RolesBLL.GetListDetalle(Utilidades.ToInt(IdRol_TextBox.Text));

                }
                catch (FormatException)
                {
                    MessageBox.Show("Debes ingresar un Critero valido.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Debes ingresar un Id de Rol.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;

            var conteo = listado.Count;
            ConteoTextbox.Text = conteo.ToString();
            if (conteo == 0)
            {
                MessageBox.Show("No existe Rol con este Id!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

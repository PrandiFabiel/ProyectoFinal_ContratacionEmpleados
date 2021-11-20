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
    /// Interaction logic for cPermisos.xaml
    /// </summary>
    public partial class cPermisos : Window
    {
        public cPermisos()
        {
            InitializeComponent();
        }

        private void Buscar_Button_Click(object sender, RoutedEventArgs e)
        {
            List<Permisos> listado = new List<Permisos>();

            if (Criterio_TextBox.Text.Trim().Length > 0)
            {
                switch (Filtro_ComboBox.SelectedIndex)
                {
                    case 0:
                        try
                        {
                            listado = PermisosBLL.GetList(e => e.PermisoId == Utilidades.ToInt(Criterio_TextBox.Text));
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Debes ingresar un Critero valido.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        break;

                    case 1:
                        try
                        {
                            listado = PermisosBLL.GetList(d => d.Descripcion.ToLower().Contains(Criterio_TextBox.Text.ToLower()));
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Debes ingresar un Critero valido.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        break;

                    case 2:
                        try
                        {
                            listado = PermisosBLL.GetList(e => e.VecesAsignado == Utilidades.ToInt(Criterio_TextBox.Text));
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Debes ingresar un Critero valido.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        break;
                }
            }
            else
            {
                listado = PermisosBLL.GetList(x => true);
            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;

            var conteo = listado.Count;
            ConteoTextbox.Text = conteo.ToString();

        }
    }
}

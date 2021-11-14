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
    /// Interaction logic for cUsuarios.xaml
    /// </summary>
    public partial class cUsuarios : Window
    {
        public cUsuarios()
        {
            InitializeComponent();
        }

        private void Buscar_Button_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Usuarios>();

            if (Criterio_TextBox.Text.Trim().Length > 0)
            {
                switch (Filtro_ComboBox.SelectedIndex)
                {
                    case 0:
                        try
                        {
                            if (Desde_DataPicker.SelectedDate != null)
                                listado = UsuariosBLL.GetList(
                                    c => c.FechaRegistroUsuario.Date >= Desde_DataPicker.SelectedDate &&
                                    c.FechaRegistroUsuario.Date <= Hasta_DatePicker.SelectedDate &&
                                    c.UsuarioId == Utilidades.ToInt(Criterio_TextBox.Text)
                                );
                            else
                                listado = UsuariosBLL.GetList(e => e.UsuarioId == Utilidades.ToInt(Criterio_TextBox.Text));
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Debes ingresar un Critero valido.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        break;
                    case 1:
                        try
                        {
                            if (Desde_DataPicker.SelectedDate != null)
                                listado = UsuariosBLL.GetList(
                                    c => c.FechaRegistroUsuario.Date >= Desde_DataPicker.SelectedDate &&
                                    c.FechaRegistroUsuario.Date <= Hasta_DatePicker.SelectedDate &&
                                    c.NombreUsuario.ToLower().Contains(Criterio_TextBox.Text.ToLower())
                                );
                            else
                                listado = UsuariosBLL.GetList(d => d.NombreUsuario.ToLower().Contains(Criterio_TextBox.Text.ToLower()));
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
                listado = UsuariosBLL.GetList(c => true);
            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;

        }
    }
}

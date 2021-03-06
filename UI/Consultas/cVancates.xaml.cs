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
    /// Interaction logic for cVancates.xaml
    /// </summary>
    public partial class cVancates : Window
    {
        public cVancates()
        {
            InitializeComponent();
        }

        private void Buscar_Button_Click(object sender, RoutedEventArgs e)
        {
            List<Vacantes> listado = new List<Vacantes>();

            if (Criterio_TextBox.Text.Trim().Length > 0)
            {
                switch (Filtro_ComboBox.SelectedIndex)
                {
                    case 0:
                        try
                        {
                            if (Desde_DataPicker.SelectedDate != null)
                                listado = VacantesBLL.GetList(
                                    c => c.Fecha.Date >= Desde_DataPicker.SelectedDate &&
                                    c.Fecha.Date <= Hasta_DatePicker.SelectedDate &&
                                    c.VacanteId == Utilidades.ToInt(Criterio_TextBox.Text)
                                );
                            else
                                listado = VacantesBLL.GetList(e => e.VacanteId == Utilidades.ToInt(Criterio_TextBox.Text));
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
                                listado = VacantesBLL.GetList(
                                    c => c.Fecha.Date >= Desde_DataPicker.SelectedDate &&
                                    c.Fecha.Date <= Hasta_DatePicker.SelectedDate &&
                                    c.Nombre.ToLower().Contains(Criterio_TextBox.Text.ToLower())
                                );
                            else
                                listado = VacantesBLL.GetList(d => d.Nombre.ToLower().Contains(Criterio_TextBox.Text.ToLower()));
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Debes ingresar un Critero valido.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        break;

                    case 2:
                        try
                        {
                            if (Desde_DataPicker.SelectedDate != null)
                                listado = VacantesBLL.GetList(
                                    c => c.Fecha.Date >= Desde_DataPicker.SelectedDate &&
                                    c.Fecha.Date <= Hasta_DatePicker.SelectedDate &&
                                    c.Requisitos.ToLower().Contains(Criterio_TextBox.Text.ToLower())
                                );
                            else
                                listado = VacantesBLL.GetList(d => d.Requisitos.ToLower().Contains(Criterio_TextBox.Text.ToLower()));
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Debes ingresar un Critero valido.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        break;

                    case 3:
                        try
                        {
                            if (Desde_DataPicker.SelectedDate != null)
                                listado = VacantesBLL.GetList(
                                    c => c.Fecha.Date >= Desde_DataPicker.SelectedDate &&
                                    c.Fecha.Date <= Hasta_DatePicker.SelectedDate &&
                                    c.Descripcion.ToLower().Contains(Criterio_TextBox.Text.ToLower())
                                );
                            else
                                listado = VacantesBLL.GetList(d => d.Descripcion.ToLower().Contains(Criterio_TextBox.Text.ToLower()));
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
                if (Desde_DataPicker.SelectedDate != null)
                    listado = VacantesBLL.GetList(e => e.Fecha.Date >= Desde_DataPicker.SelectedDate);

                if (Desde_DataPicker.SelectedDate != null)
                    listado = VacantesBLL.GetList(e => e.Fecha.Date <= Hasta_DatePicker.SelectedDate);

                if (Desde_DataPicker.SelectedDate == null && Hasta_DatePicker.SelectedDate == null)
                    listado = VacantesBLL.GetList(x => true);
            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;

            var conteo = listado.Count;
            ConteoTextbox.Text = conteo.ToString();
        }
    }
}

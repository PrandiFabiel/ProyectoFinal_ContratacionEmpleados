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
    /// Interaction logic for cInstructor.xaml
    /// </summary>
    public partial class cInstructor : Window
    {
        public cInstructor()
        {
            InitializeComponent();
        }

        private void Buscar_Button_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Instructores>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        try
                        {
                            if (DesdeDataPicker.SelectedDate != null)
                                listado = InstructoresBLL.GetList(
                                    x => x.FechaInstructor.Date >= DesdeDataPicker.SelectedDate &&
                                    x.FechaInstructor.Date <= HastaDatePicker.SelectedDate &&
                                    x.InstructorId == Utilidades.ToInt(CriterioTextBox.Text)
                                );
                            else
                                listado = InstructoresBLL.GetList(x => x.InstructorId == Utilidades.ToInt(CriterioTextBox.Text));
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Critero no valido.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        break;
                    case 1:
                        try
                        {
                            if (DesdeDataPicker.SelectedDate != null)
                                listado = InstructoresBLL.GetList(
                                    x => x.FechaInstructor.Date >= DesdeDataPicker.SelectedDate &&
                                    x.FechaInstructor.Date <= HastaDatePicker.SelectedDate &&
                                    x.NombreInstructor.ToLower().Contains(CriterioTextBox.Text.ToLower())
                                );
                            else
                                listado = InstructoresBLL.GetList(x => x.NombreInstructor.ToLower().Contains(CriterioTextBox.Text.ToLower()));
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Critero no valido.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        break;
                    case 2:
                        try
                        {
                            if (DesdeDataPicker.SelectedDate != null)
                                listado = InstructoresBLL.GetList(
                                    x => x.FechaInstructor.Date >= DesdeDataPicker.SelectedDate &&
                                    x.FechaInstructor.Date <= HastaDatePicker.SelectedDate &&
                                    x.ApellidosInstructor.ToLower().Contains(CriterioTextBox.Text.ToLower())
                                );
                            else
                                listado = InstructoresBLL.GetList(x => x.ApellidosInstructor.ToLower().Contains(CriterioTextBox.Text.ToLower()));
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Critero no valido.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        break;
                    case 3:
                        try
                        {
                            if (DesdeDataPicker.SelectedDate != null)
                                listado = InstructoresBLL.GetList(
                                    x => x.FechaInstructor.Date >= DesdeDataPicker.SelectedDate &&
                                    x.FechaInstructor.Date <= HastaDatePicker.SelectedDate &&
                                    x.TelefonoInstructor.ToLower().Contains(CriterioTextBox.Text.ToLower())
                                );
                            else
                                listado = InstructoresBLL.GetList(x => x.TelefonoInstructor.ToLower().Contains(CriterioTextBox.Text.ToLower()));
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Critero no valido.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        break;
                    case 4:
                        try
                        {
                            if (DesdeDataPicker.SelectedDate != null)
                                listado = InstructoresBLL.GetList(
                                    x => x.FechaInstructor.Date >= DesdeDataPicker.SelectedDate &&
                                    x.FechaInstructor.Date <= HastaDatePicker.SelectedDate &&
                                    x.CantidadEmpleados == Utilidades.ToInt(CriterioTextBox.Text)
                                );
                            else
                                listado = InstructoresBLL.GetList(x => x.CantidadEmpleados == Utilidades.ToInt(CriterioTextBox.Text));
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Critero no valido.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        break;
                }
            }
            else
            {
                if (DesdeDataPicker.SelectedDate != null)
                    listado = InstructoresBLL.GetList(e => e.FechaInstructor.Date >= DesdeDataPicker.SelectedDate);

                if (HastaDatePicker.SelectedDate != null)
                    listado = InstructoresBLL.GetList(e => e.FechaInstructor.Date <= HastaDatePicker.SelectedDate);

                if(DesdeDataPicker.SelectedDate == null && HastaDatePicker.SelectedDate == null)
                    listado = InstructoresBLL.GetList(x => true);
            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;

            var conteo = listado.Count;
            ConteoTextbox.Text = conteo.ToString();
        }
    }
}

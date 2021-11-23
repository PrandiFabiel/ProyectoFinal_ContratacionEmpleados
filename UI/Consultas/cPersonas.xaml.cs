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
    /// Interaction logic for cPersonas.xaml
    /// </summary>
    public partial class cPersonas : Window
    {
        public cPersonas()
        {
            InitializeComponent();
        }

        private void Buscar_Button_Click(object sender, RoutedEventArgs e)
        {
            List<Personas> listado = new List<Personas>();

            if (Criterio_TextBox.Text.Trim().Length > 0)
            {
                switch (Filtro_ComboBox.SelectedIndex)
                {
                    case 0:
                        try
                        {
                            if (Desde_DataPicker.SelectedDate != null)
                                listado = PersonasBLL.GetList(
                                    c => c.Fecha.Date >= Desde_DataPicker.SelectedDate &&
                                    c.Fecha.Date <= Hasta_DatePicker.SelectedDate &&
                                    c.PersonaId == Utilidades.ToInt(Criterio_TextBox.Text)
                                );
                            else
                                listado = PersonasBLL.GetList(e => e.PersonaId == Utilidades.ToInt(Criterio_TextBox.Text));
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
                                listado = PersonasBLL.GetList(
                                    c => c.Fecha.Date >= Desde_DataPicker.SelectedDate &&
                                    c.Fecha.Date <= Hasta_DatePicker.SelectedDate &&
                                    c.Nombres.ToLower().Contains(Criterio_TextBox.Text.ToLower())
                                );
                            else
                                listado = PersonasBLL.GetList(d => d.Nombres.ToLower().Contains(Criterio_TextBox.Text.ToLower()));
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
                                listado = PersonasBLL.GetList(
                                    c => c.Fecha.Date >= Desde_DataPicker.SelectedDate &&
                                    c.Fecha.Date <= Hasta_DatePicker.SelectedDate &&
                                    c.Apellidos.ToLower().Contains(Criterio_TextBox.Text.ToLower())
                                );
                            else
                                listado = PersonasBLL.GetList(d => d.Apellidos.ToLower().Contains(Criterio_TextBox.Text.ToLower()));
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
                                listado = PersonasBLL.GetList(
                                    c => c.Fecha.Date >= Desde_DataPicker.SelectedDate &&
                                    c.Fecha.Date <= Hasta_DatePicker.SelectedDate &&
                                    c.Cedula.ToLower().Contains(Criterio_TextBox.Text.ToLower())
                                );
                            else
                                listado = PersonasBLL.GetList(d => d.Cedula.ToLower().Contains(Criterio_TextBox.Text.ToLower()));
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Debes ingresar un Critero valido.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        break;

                    case 4:
                        try
                        {
                            if (Desde_DataPicker.SelectedDate != null)
                                listado = PersonasBLL.GetList(
                                    c => c.Fecha.Date >= Desde_DataPicker.SelectedDate &&
                                    c.Fecha.Date <= Hasta_DatePicker.SelectedDate &&
                                    c.Telefono.ToLower().Contains(Criterio_TextBox.Text.ToLower())
                                );
                            else
                                listado = PersonasBLL.GetList(d => d.Telefono.ToLower().Contains(Criterio_TextBox.Text.ToLower()));
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Debes ingresar un Critero valido.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        break;

                    case 5:
                        try
                        {
                            if (Desde_DataPicker.SelectedDate != null)
                                listado = PersonasBLL.GetList(
                                    c => c.Fecha.Date >= Desde_DataPicker.SelectedDate &&
                                    c.Fecha.Date <= Hasta_DatePicker.SelectedDate &&
                                    c.Celular.ToLower().Contains(Criterio_TextBox.Text.ToLower())
                                );
                            else
                                listado = PersonasBLL.GetList(d => d.Celular.ToLower().Contains(Criterio_TextBox.Text.ToLower()));
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Debes ingresar un Critero valido.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        break;

                    case 6:
                        try
                        {
                            if (Desde_DataPicker.SelectedDate != null)
                                listado = PersonasBLL.GetList(
                                    c => c.Fecha.Date >= Desde_DataPicker.SelectedDate &&
                                    c.Fecha.Date <= Hasta_DatePicker.SelectedDate &&
                                    c.Email.ToLower().Contains(Criterio_TextBox.Text.ToLower())
                                );
                            else
                                listado = PersonasBLL.GetList(d => d.Celular.ToLower().Contains(Criterio_TextBox.Text.ToLower()));
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Debes ingresar un Critero valido.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        break;

                    case 7:
                        try
                        {
                            if (Desde_DataPicker.SelectedDate != null)
                                listado = PersonasBLL.GetList(
                                    c => c.Fecha.Date >= Desde_DataPicker.SelectedDate &&
                                    c.Fecha.Date <= Hasta_DatePicker.SelectedDate &&
                                    c.NombreReferenciaFamiliar.ToLower().Contains(Criterio_TextBox.Text.ToLower())
                                );
                            else
                                listado = PersonasBLL.GetList(d => d.NombreReferenciaFamiliar.ToLower().Contains(Criterio_TextBox.Text.ToLower()));
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Debes ingresar un Critero valido.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        break;

                    case 8:
                        try
                        {
                            if (Desde_DataPicker.SelectedDate != null)
                                listado = PersonasBLL.GetList(
                                    c => c.Fecha.Date >= Desde_DataPicker.SelectedDate &&
                                    c.Fecha.Date <= Hasta_DatePicker.SelectedDate &&
                                    c.TelefonoReferenciaFamiliar.ToLower().Contains(Criterio_TextBox.Text.ToLower())
                                );
                            else
                                listado = PersonasBLL.GetList(d => d.TelefonoReferenciaFamiliar.ToLower().Contains(Criterio_TextBox.Text.ToLower()));
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Debes ingresar un Critero valido.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        break;


                    case 9:
                        try
                        {
                            if (Desde_DataPicker.SelectedDate != null)
                                listado = PersonasBLL.GetList(
                                    c => c.Fecha.Date >= Desde_DataPicker.SelectedDate &&
                                    c.Fecha.Date <= Hasta_DatePicker.SelectedDate &&
                                    c.NombreReferenciaPersonal.ToLower().Contains(Criterio_TextBox.Text.ToLower())
                                );
                            else
                                listado = PersonasBLL.GetList(d => d.NombreReferenciaPersonal.ToLower().Contains(Criterio_TextBox.Text.ToLower()));
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Debes ingresar un Critero valido.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        break;

                    case 10:
                        try
                        {
                            if (Desde_DataPicker.SelectedDate != null)
                                listado = PersonasBLL.GetList(
                                    c => c.Fecha.Date >= Desde_DataPicker.SelectedDate &&
                                    c.Fecha.Date <= Hasta_DatePicker.SelectedDate &&
                                    c.TelefonoReferenciaPersonal.ToLower().Contains(Criterio_TextBox.Text.ToLower())
                                );
                            else
                                listado = PersonasBLL.GetList(d => d.TelefonoReferenciaPersonal.ToLower().Contains(Criterio_TextBox.Text.ToLower()));
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
                    listado = PersonasBLL.GetList(e => e.Fecha.Date >= Desde_DataPicker.SelectedDate);

                if (Hasta_DatePicker.SelectedDate != null)
                    listado = PersonasBLL.GetList(e => e.Fecha.Date <= Hasta_DatePicker.SelectedDate);

                if (Desde_DataPicker.SelectedDate == null && Hasta_DatePicker.SelectedDate == null)
                    listado = PersonasBLL.GetList(c => true);

            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;


            var conteo = listado.Count;
            ConteoTextbox.Text = conteo.ToString();
        }
    }
}

using ProyectoFinal_ContratacionEmpleados.BLL;
using ProyectoFinal_ContratacionEmpleados.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            DepartamentoComboBox.ItemsSource = DepartamentosBLL.GetDepartamentos();
            DepartamentoComboBox.SelectedValuePath = "DepartamentoId";
            DepartamentoComboBox.DisplayMemberPath = "Nombre";

            HabilidadComboBox.ItemsSource = HabilidadesBLL.GetHabilidades();
            HabilidadComboBox.SelectedValuePath = "HabilidadId";
            HabilidadComboBox.DisplayMemberPath = "Descripcion";
        }

        private void Cargar()
        {
            this.DataContext = null;
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
                MessageBox.Show("El Campo Nombre no puede estar vacio", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                NombreVacante_TextBox.Focus();
            }
            if (DepartamentoComboBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("El Campo Departamento no puede estar vacio", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                DepartamentoComboBox.Focus();
            }
            if (Requisitos_TextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("El Campo Requisitos no Puede estar vacio", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                Requisitos_TextBox.Focus();
            }
            if (Descripcion_TextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("El Campo Descripcion no Puede estar vacio", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                Descripcion_TextBox.Focus();
            }

            if (DisponibleVacante_TextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta llenar el campo disponible!", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                DisponibleVacante_TextBox.Focus();
            }

            if (Convert.ToInt32(DisponibleVacante_TextBox.Text) <= 0)
            {
                esValido = false;
                MessageBox.Show("El campo disponible no puede ser menor o igual que 0!", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                DisponibleVacante_TextBox.Focus();
            }

            if (DetalleDataGrid.Items.Count == 0)
            {
                esValido = false;
                MessageBox.Show("Falta llenar el datagrid", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return esValido;

        }

        private void Buscar_Button_Click(object sender, RoutedEventArgs e)
        {
            var Vacante = VacantesBLL.Buscar(vacante.VacanteId);

            if (Vacante != null)
            {
                this.vacante = Vacante;
                this.DataContext = vacante;
            }
            else
            {
                Limpiar();
                MessageBox.Show("No existe en la base de datos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            Cargar();
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

        private void AgregarFilaButton_Click(object sender, RoutedEventArgs e)
        {
            if (HabilidadComboBox.Text.Length == 0)
            {
                MessageBox.Show("Debe seleccionar una Habilidad", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                var detalle = new VacantesDetalle
                {
                    VacanteId = this.vacante.VacanteId,
                    Habilidad = (Habilidades)HabilidadComboBox.SelectedItem
                };

                vacante.VacantesDetalle.Add(detalle);

                Cargar();
            }
        }

        private void RemoverFilaButton_Click(object sender, RoutedEventArgs e)
        {
            var detalle = (VacantesDetalle)DetalleDataGrid.SelectedItem;

            if(DetalleDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una fila", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (DetalleDataGrid.Items.Count >= 1 && DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1)
            {
                vacante.VacantesDetalle.RemoveAt(DetalleDataGrid.SelectedIndex);
                Cargar();
            }
        }

        private void DisponibleVacante_TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}

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
    /// Interaction logic for rPersonas.xaml
    /// </summary>
    public partial class rPersonas : Window
    {
        private Personas Persona = new Personas();
        
        public rPersonas()
        {
            InitializeComponent();
            this.DataContext = Persona;

            EmpresaCombobox.ItemsSource = EmpresasBLL.GetEmpresas();
            EmpresaCombobox.SelectedValuePath = "EmpresaId";
            EmpresaCombobox.DisplayMemberPath = "Nombre";

            GeneroCombobox.ItemsSource = GenerosBLL.GetGeneros();
            GeneroCombobox.SelectedValuePath = "GeneroId";
            GeneroCombobox.DisplayMemberPath = "Descripcion";

            VacanteCombobox.ItemsSource = VacantesBLL.GetVacantes();
            VacanteCombobox.SelectedValuePath = "VacanteId";
            VacanteCombobox.DisplayMemberPath = "NombreVacante";

            ProvinciaCombobox.ItemsSource = ProvinciasBLL.GetProvincias();
            ProvinciaCombobox.SelectedValuePath = "ProvinciaId";
            ProvinciaCombobox.DisplayMemberPath = "Nombre";

            CiudadCombobox.ItemsSource = CiudadesBLL.GetCiudades();
            CiudadCombobox.SelectedValuePath = "ProvinciaId";
            CiudadCombobox.DisplayMemberPath = "Nombre";

            

            SectorCombobox.ItemsSource = SectoresBLL.GetSectores();
            SectorCombobox.SelectedValuePath = "CiudadId";
            SectorCombobox.DisplayMemberPath = "Nombre";
        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = Persona;
        }

        private void Limpiar()
        {
            this.Persona = new Personas();
            this.DataContext = Persona;
        }


        private bool Validar()
        {
            bool esValido = true;

            if (NombresTextbox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta el campo Nombres", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (ApellidosTextbox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta el campo Apellidos", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (CedulaTextbox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta el campo Cedula", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (TelefonoTextbox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta el campo Telefono", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (CelularTextbox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta el campo Celular", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (EmailTextbox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta el campo Email", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (GeneroCombobox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta el campo Genero", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (ProvinciaCombobox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta el campo Provincia", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (CiudadCombobox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta el campo Ciudad", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (SectorCombobox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta el campo Sector", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (NombreReferenciaFamiliarTextbox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta el campo Referencia Familiar (Nombres)", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (TelefonoReferenciaFamiliarTextbox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta el campo Referencia Familiar (Telefono)", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (NombreReferenciaPersonalTextbox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta el campo Referencia Personal (Nombres)", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (TelefonoReferenciaPersonalTextbox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta el campo Referencia Personal (Telefono)", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (VacanteCombobox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta el campo Vacante", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return esValido;
        }


        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Personas encontrado = PersonasBLL.Buscar(Persona.PersonaId);

            if (encontrado != null)
            {
                Persona = encontrado;
                Cargar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("Persona no existe en la base de datos", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = PersonasBLL.Guardar(Persona);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Fallo al guardar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (PersonasBLL.Eliminar(Persona.PersonaId))
            {
                MessageBox.Show("Registro eliminado!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No fue posible eliminar!", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            var detalle = new PersonasDetalle
            {
                PersonaId = this.Persona.PersonaId,
                EmpresaId = (int)EmpresaCombobox.SelectedValue,
                Empresa = (Empresas)EmpresaCombobox.SelectedItem
            };


            Persona.Detalle.Add(detalle);
            Cargar();
        }

        private void QuitarButton_Click(object sender, RoutedEventArgs e)
        {
            if (DetalleDataGrid.Items.Count >= 1 && DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1)
            {
                Persona.Detalle.RemoveAt(DetalleDataGrid.SelectedIndex);
                Cargar();
            }
        }
    }
}

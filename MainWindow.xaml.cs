using ProyectoFinal_ContratacionEmpleados.UI.Consultas;
using ProyectoFinal_ContratacionEmpleados.UI.Registros;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProyectoFinal_ContratacionEmpleados
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void VacantesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rVacantes rVacante = new rVacantes();
            rVacante.Show();
        }

        private void cVacantesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cVancates cVancate = new cVancates();
            cVancate.Show();
        }

        private void UsuariosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rUsuarios rUsuarios = new rUsuarios();
            rUsuarios.Show(); 
        }

        private void cUsuariosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cUsuarios cUsuarios = new cUsuarios();
            cUsuarios.Show(); 
        }

        private void EmpleadosMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PuestoDeTrabajoMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DepartamentosMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ProvinciaMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CiudadesMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SectoresMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CambiarContrasenaMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cEmpleadosMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cPuestoDeTrabajoMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cDepartamentosMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cProvinciaMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cCiudadesMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cSectoresMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GenerosMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cGenerosMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

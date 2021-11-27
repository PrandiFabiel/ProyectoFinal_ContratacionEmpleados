using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ContratacionEmpleados.Entidades
{
    public class Empresas
    {
        [Key]
        public int EmpresaId { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Puesto { get; set; }
        public int Duracion { get; set; }
        public int UsuarioId { get; set; }
    }
}

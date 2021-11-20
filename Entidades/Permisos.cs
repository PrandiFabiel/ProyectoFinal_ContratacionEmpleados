using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ContratacionEmpleados.Entidades
{
    public class Permisos
    {
        [Key]
        public int PermisoId { get; set; }
        public int UsuarioId { get; set; }
        public string Descripcion { get; set; }
        public int VecesAsignado { get; set; }
    }
}

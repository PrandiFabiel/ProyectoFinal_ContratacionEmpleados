using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ContratacionEmpleados.Entidades
{
    public class RolesDetalle
    {
        [Key]
        public int RolDetalleId { get; set; }
        public int RolId { get; set; }
        public int PermisoId { get; set; }
        public string DescripcionPermiso { get; set; }
        public int VecesAsignado { get; set; }
        public int UsuarioId { get; set; }
    }
}

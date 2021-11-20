using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ContratacionEmpleados.Entidades
{
   public class Roles
    {
        [Key]
        public int RolId { get; set; }
        public string Descripcion { get; set; }
        public int UsuarioId { get; set; }
        [ForeignKey("RolId")]
        public virtual List<RolesDetalle> RolesDetalle { get; set; } = new List<RolesDetalle>();
    }
}

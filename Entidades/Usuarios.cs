using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ContratacionEmpleados.Entidades
{
    public class Usuarios
    {
        [Key]

        public int UsuarioId { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public DateTime FechaRegistroUsuario { get; set; } = DateTime.Now;
        public string Email { get; set; }

        [ForeignKey("RolId")]
        public virtual Roles Roles { get; set; }

    }
}

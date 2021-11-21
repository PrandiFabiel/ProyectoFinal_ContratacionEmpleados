using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ContratacionEmpleados.Entidades
{
    public class PersonasDetalle
    {
        [Key]
        public int PersonasDetalleId { get; set; }
        public int EmpresaId { get; set; }
        public int PersonaId { get; set; }
        public int UsuarioId { get; set; }

        [ForeignKey("EmpresaId")]
        public virtual Empresas Empresa { get; set; }
    }
}

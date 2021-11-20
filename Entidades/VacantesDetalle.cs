using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ContratacionEmpleados.Entidades
{
    public class VacantesDetalle
    {
        [Key]
        public int VacanteDetalleId { get; set; }
        public int VacanteId { get; set; }
        public int HabilidadId { get; set; }
        public int UsuarioId { get; set; }

        [ForeignKey("HabilidadId")]
        public virtual Habilidades Habilidad { get; set; }
    }
}

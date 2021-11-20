using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ContratacionEmpleados.Entidades
{
    public class Vacantes
    {
        [Key]
        public int VacanteId { get; set; }
        public string NombreVacante { get; set; }
        public int DepartamentoId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Requisitos { get; set; }
        public string Descripcion { get; set; }
        public int Disponible { get; set; }
        public int UsusarioId { get; set; }

        [ForeignKey("DepartamentoId")]
        public virtual Departamentos Departamento { get; set; }

        [ForeignKey("VacanteId")]
        public virtual List<VacantesDetalle> VacantesDetalle { get; set; } = new List<VacantesDetalle>();
    }
}

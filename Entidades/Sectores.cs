using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ContratacionEmpleados.Entidades
{
    public class Sectores
    {
        [Key]
        public int SectorId { get; set; }
        public string Nombre { get; set; }
        public int CiudadId { get; set; }
        public int UsuarioId { get; set; }

        [ForeignKey("CiudadId")]
        public virtual Ciudades Ciudades { get; set; }
    }
}

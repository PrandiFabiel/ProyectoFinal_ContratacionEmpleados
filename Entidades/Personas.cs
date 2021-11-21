using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ContratacionEmpleados.Entidades
{
    public class Personas
    {
        [Key]
        public int PersonaId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Cedula { get; set; }
        public string Email { get; set; }
        public string  Telefono { get; set; }
        public string  Celular { get; set; }
        public string NombreReferenciaFamiliar { get; set; }
        public string TelefonoReferenciaFamiliar { get; set; }
        public string NombreReferenciaPersonal { get; set; }
        public string TelefonoReferenciaPersonal { get; set; }
        public int UsuarioId { get; set; }
        public int GeneroId { get; set; }
        public int ProvinciaId { get; set; }
        public int VacanteId { get; set; }

        [ForeignKey("GeneroId")]
        public virtual Generos Genero { get; set; }

        [ForeignKey("ProvinciaId")]
        public virtual Provincias Provincia { get; set; }

        [ForeignKey("VacanteId")]
        public virtual Vacantes Vacante { get; set; }

        [ForeignKey("PersonaId")]
        public virtual List<PersonasDetalle> Detalle { get; set; } = new List<PersonasDetalle>();
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ContratacionEmpleados.Entidades
{
    public class Instructores
    {
        [Key]
        public int InstructorId { get; set; }
        public DateTime FechaInstructor { get; set; } = DateTime.Now;
        public string NombreInstructor { get; set; }
        public string ApellidosInstructor { get; set; }
        public string TelefonoInstructor { get; set; }
        public int CantidadEmpleados { get; set; }

    }
}

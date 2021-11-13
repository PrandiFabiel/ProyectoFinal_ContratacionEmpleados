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
        public string NombreInstructor { get; set; }
        public int CantidadEmpleados { get; set; }

    }
}

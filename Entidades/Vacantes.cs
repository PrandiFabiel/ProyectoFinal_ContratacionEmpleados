﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ContratacionEmpleados.Entidades
{
    public class Vacantes
    {
        public int VacanteId { get; set; }
        public string NombreDeVacante { get; set; }
        public int DepartamentoId { get; set; }
        public DateTime FechaDeRegistroVacante { get; set; } = DateTime.Now;
        public string RequisitosVacante { get; set; }
        public string DescripcionVacante { get; set; }
    }
}

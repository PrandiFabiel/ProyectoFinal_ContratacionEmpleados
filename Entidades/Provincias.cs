﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ContratacionEmpleados.Entidades
{
    public class Provincias
    {
        [Key]
        public int ProvinciaId { get; set; }
        public string Nombre { get; set; }
        public int UsuarioId { get; set; }

    }
}

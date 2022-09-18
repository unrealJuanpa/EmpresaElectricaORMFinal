using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmpresaElectricaORMFinal.Models
{
    [Table("TablaRegistroControl")]

    public class RegistroControl
    {
        [Required]
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        [MaxLength(120)]
        public string Informacion { get; set; }

        // llave foranea 1
        public Empleado empleado { get; set; }
        public int EmpleadoId { get; set; }

        // llave foranea 2
        public TipoControl tipoControl { get; set; }
        public int TipoControlId { get; set; }
    }
}
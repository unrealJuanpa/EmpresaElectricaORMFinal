using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmpresaElectricaORMFinal.Models
{
    [Table("TablaAsignarTarea")]

    public class AsignarTarea
    {
        [Required]
        public int Id { get; set; }

        [MaxLength(120)]
        public string NombreTarea { get; set; }

        public DateTime Fecha { get; set; }

        //para llave foranea
        public Empleado empleado { get; set; }
        public int EmpleadoId { get; set; }
    }
}
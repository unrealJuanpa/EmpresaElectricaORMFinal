using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmpresaElectricaORMFinal.Models
{
    [Table("TablaRegistroIngresoSalida")]

    public class RegistroIngresoSalida
    {
        [Required]
        public int Id { get; set; }

        public DateTime FechaHoraIngreso { get; set; }

        public DateTime FechaHoraSalida { get; set; }


        // para llave foranea
        public Empleado empleado { get; set; }
        public int EmpleadoId { get; set; }
    }
}
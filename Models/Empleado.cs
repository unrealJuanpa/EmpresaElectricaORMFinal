using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmpresaElectricaORMFinal.Models
{
    [Table("TablaEmpleado")]

    public class Empleado
    {

        [Required]
        public int Id { get; set; }

        [MaxLength(120)]
        public string Nombre { get; set; }
        

        public int Telefono { get; set; }


        [MaxLength(120)]
        public string Usuario { get; set; }


        [MaxLength(120)]
        public string Contrasenia { get; set; }
        

        public DateTime FechaContratacion { get; set; }

        public float Salario { get; set; }

        [MaxLength(120)]
        public string Direccion { get; set; }


        [MaxLength(120)]
        public string DPI { get; set; }

        [MaxLength(120)]
        public string Puesto { get; set; }

        [MaxLength(120)]
        public string Estado { get; set; }

        //indica que la llave migra 
        public ICollection<RegistroIngresoSalida> registroIngresoSalidas { get; set; }
        public ICollection<AsignarTarea> asignarTareas { get; set; }
        public ICollection<RegistroControl> registroControl { get; set; }
    
    }
}
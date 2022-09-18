using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmpresaElectricaORMFinal.Models
{
    [Table("TablaTipoControl")]

    public class TipoControl
    {
        [Required]
        public int Id { get; set; }

        [MaxLength(120)]
        public string NombreControl { get; set; }

        // indica que la llave migra
        public ICollection<RegistroControl> registroControl { get; set; }
    }
}
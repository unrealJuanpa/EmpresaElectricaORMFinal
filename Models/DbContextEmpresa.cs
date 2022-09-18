using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmpresaElectricaORMFinal.Models
{
    public class DbContextEmpresa:DbContext
    {
        public DbContextEmpresa():base("ConnEmpresa")
        {

        }

        public DbSet<Empleado> Empleadoes { get; set; }
        public DbSet<TipoControl> TipoControles { get; set; }
        public DbSet<RegistroIngresoSalida> RegistroIngresoSalidaes { get; set; }
        public DbSet<AsignarTarea> AsignarTareaes { get; set; }
        public DbSet<RegistroControl> RegistroControles { get; set; }
    }
}
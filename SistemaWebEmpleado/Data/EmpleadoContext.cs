using SistemaWebEmpleado.Models;
using Microsoft.EntityFrameworkCore;

namespace SistemaWebEmpleado.Data
{
    public class EmpleadoContext : DbContext
    {
        public EmpleadoContext(DbContextOptions<EmpleadoContext> options) : base(options) { }

        public DbSet<Empleado> empleados { get; set; } 
    }
}

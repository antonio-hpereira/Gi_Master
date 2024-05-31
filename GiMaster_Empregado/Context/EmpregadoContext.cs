using GiMaster_Empregado.Entidades;
using Microsoft.EntityFrameworkCore;

namespace GIMaster_Empregado.Context
{
    public class EmpregadoContext: DbContext
    {
        public EmpregadoContext() { }
        public EmpregadoContext(DbContextOptions<EmpregadoContext> options) : base(options) { }
        public DbSet<Empregados> Empregados { get; set; }
    }
}

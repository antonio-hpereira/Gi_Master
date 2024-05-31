using GIMaster_Empregados.Entidades;
using Microsoft.EntityFrameworkCore;

namespace GIMaster_Empregados.Context
{
    public class EmpregadosContext : DbContext
    {
       
        public EmpregadosContext(DbContextOptions<EmpregadosContext> options) : base(options) { }
        public DbSet<Empregados> Empregados { get; set; }
    }
}

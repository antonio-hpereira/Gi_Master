using GIMaster_Empresa.Entidades;
using Microsoft.EntityFrameworkCore;

namespace GIMaster_Empresa.Context
{
    public class EmpresasContext: DbContext
    {
        public EmpresasContext(DbContextOptions<EmpresasContext> options) : base(options) { }

        public DbSet<Empresas> Empresas { get; set; }
    }
}

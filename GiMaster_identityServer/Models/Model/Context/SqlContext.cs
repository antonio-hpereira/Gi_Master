using GiMaster_identityServer.Models.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GiMaster_identityServerr.Model.Context
{
    public class SqlContext : IdentityDbContext<ApplicationUser>
    {
        
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {

        }

    }
}

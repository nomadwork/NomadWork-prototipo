using Microsoft.EntityFrameworkCore;
using NomadWork.Infra.Models;


namespace NomadWork.Infra.Context
{
    public class NomadWorkDbContext : DbContext
    {
        public NomadWorkDbContext(DbContextOptions<NomadWorkDbContext> options) : base(options)
        {
        }
        public DbSet<AddressDb> Addresses { get; set; }
        public DbSet<UserDb> Users { get; set; }
        public DbSet<EstablishmmentDb> Establishmments { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using NomadWork.Api.Models;


namespace NomadWork.Api.Context
{
    public class NomadWorkDbContext : DbContext
    {
        public NomadWorkDbContext(DbContextOptions<NomadWorkDbContext> options) : base(options)
        {
        }
        public DbSet<AddressModel> Address { get; set; }
        public DbSet<UserModel> User { get; set; }
        public DbSet<EstablishmmentModel> Establishmment { get; set; }
    }
}

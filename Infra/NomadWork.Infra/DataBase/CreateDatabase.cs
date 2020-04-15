using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using NomadWork.Infra.Context;

namespace NomadWork.Infra
{
    public class CreateDatabase : IDesignTimeDbContextFactory<NomadWorkDbContext>
    {
        NomadWorkDbContext IDesignTimeDbContextFactory<NomadWorkDbContext>.CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<NomadWorkDbContext>();
            optionsBuilder.UseMySql("Server=localhost;Database=NomadWork;Uid=root;Pwd=090787Je");

            return new NomadWorkDbContext(optionsBuilder.Options);
        }
    }
}

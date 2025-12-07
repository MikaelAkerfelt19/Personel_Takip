using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Personel_Takip.Data.Models.Database;

namespace Personel_Takip.Data;

public class PersonelContextFactory : IDesignTimeDbContextFactory<PersonelContext>
{
    public PersonelContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        var connectionString = configuration.GetConnectionString("PersonelConnection")
            ?? "Server=.;Database=Personel;Trusted_Connection=True;TrustServerCertificate=True;";

        var optionsBuilder = new DbContextOptionsBuilder<PersonelContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new PersonelContext(optionsBuilder.Options);
    }
}

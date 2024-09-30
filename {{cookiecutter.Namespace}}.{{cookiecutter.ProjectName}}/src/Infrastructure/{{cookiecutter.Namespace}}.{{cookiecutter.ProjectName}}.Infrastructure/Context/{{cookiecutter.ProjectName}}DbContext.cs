using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Cai.Send.Infrastructure.Context;

public class {{cookiecutter.ProjectName}}DbContext(DbContextOptions<{{cookiecutter.ProjectName}}DbContext> options)
    : DbContext(options)
{
    #region Entities

    // public DbSet<EventsDictionary> EventsDictionary { get; set; }
    // public DbSet<Event> Events { get; set; }
    //public DbSet<OutboxMessage> OutboxMessages { get; set; }

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}

public class {{cookiecutter.ProjectName}}DbContextFactory : IDesignTimeDbContextFactory<{{cookiecutter.ProjectName}}DbContext>
{
    public {{cookiecutter.ProjectName}}DbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<{{cookiecutter.ProjectName}}DbContext>();
        optionsBuilder
            .UseNpgsql("DefaultConnection")
            .UseSnakeCaseNamingConvention();

        return new {{cookiecutter.ProjectName}}DbContext(optionsBuilder.Options);
    }
}
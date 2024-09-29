using System.Reflection;
using Cai.Send.Domain.Entities.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Cai.Send.Infrastructure.Context;

public class NotificationDbContext(DbContextOptions<NotificationDbContext> options)
    : DbContext(options)
{
    #region Entities

    // public DbSet<EventsDictionary> EventsDictionary { get; set; }
    public DbSet<Event> Events { get; set; }
    //public DbSet<OutboxMessage> OutboxMessages { get; set; }

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}

public class NotificationDbContextFactory : IDesignTimeDbContextFactory<NotificationDbContext>
{
    public NotificationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<NotificationDbContext>();
        optionsBuilder
            .UseNpgsql("DefaultConnection")
            .UseSnakeCaseNamingConvention();

        return new NotificationDbContext(optionsBuilder.Options);
    }
}
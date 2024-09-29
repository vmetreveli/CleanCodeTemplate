using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Npgsql;

namespace Cai.Send.Api.HealthChecks;

public sealed class DbConnectionHealthCheck : IHealthCheck
{
    private readonly string _connectionString;

    public DbConnectionHealthCheck(DbContext dbContext)
    {
        _connectionString = dbContext.Database.GetConnectionString();
    }

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
        CancellationToken cancellationToken = new())
    {
        try
        {
            await using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync(cancellationToken);

                await using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select 1";
                    await command.ExecuteNonQueryAsync(cancellationToken);
                }
            }

            return HealthCheckResult.Healthy();
        }
        catch (DbException ex)
        {
            return HealthCheckResult.Unhealthy("Database connection failed", ex);
        }
        catch (Exception ex)
        {
            // Catch any other exceptions and return Unhealthy
            return HealthCheckResult.Unhealthy("An unexpected error occurred", ex);
        }
    }
}
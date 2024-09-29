using Asp.Versioning;
using AsynchronousAdapter;
using Cai.Send.Api;
using Cai.Send.Api.Middleware;
using Cai.Send.Api.Swagger;
using Cai.Send.Application;
using Cai.Send.Infrastructure;
using Framework.Infrastructure;
using Microsoft.Extensions.Options;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication(builder.Configuration);
builder.Services.AddCatalogIntegration(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddSerilogServices(builder.Configuration);
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();

// builder.Services
//     .AddHealthChecks()
//     .AddCheck<DbConnectionHealthCheck>("DbConnectionHealthCheck", HealthStatus.Unhealthy, new[] { "db" })
//     .AddRabbitMQ(
//         $"amqp://{builder.Configuration["AppConfiguration:RabbitMQ:Username"]}:{builder.Configuration["AppConfiguration:RabbitMQ:Password"]}@{builder.Configuration["AppConfiguration:RabbitMQ:Host"]}/{builder.Configuration["AppConfiguration:RabbitMQ:VirtualHost"]}",
//         name: "RabbitMQ",
//         failureStatus: HealthStatus.Unhealthy,
//         tags: new[] { "rabbitmq" });


// builder.Services
//     .AddHealthChecksUI(opts =>
//     {
//         opts.AddHealthCheckEndpoint(ApiRoutes.RoutForHealth, "/health");
//         opts.SetEvaluationTimeInSeconds(5);
//         opts.SetMinimumSecondsBetweenFailureNotifications(10);
//     })
//     .AddInMemoryStorage();


builder.Services.AddApiVersioning(options =>
    {
        options.DefaultApiVersion = new ApiVersion(2, 0);
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.ReportApiVersions = true;
    })
    .AddApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    });


builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
    // Add a custom operation filter which sets default values
    options.OperationFilter<SwaggerDefaultValues>();
});

builder.Services.AddSingleton<ExceptionHandlingMiddleware>();

builder.Services.AddEndpointsApiExplorer();


builder.Logging.AddSerilog();
var app = builder.Build();
//app.MapHealthChecks("_health");

// Apply the CORS policy globally

app.UseCors(options =>
{
    options.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
});

if (app.Environment.IsDevelopment())
    //app.ApplyMigration();
    app.UseDeveloperExceptionPage();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    var descriptions = app.DescribeApiVersions();

    // Build a swagger endpoint for each discovered API version
    foreach (var description in descriptions)
    {
        var url = $"/swagger/{description.GroupName}/swagger.json";
        var name = description.GroupName.ToUpperInvariant();
        options.SwaggerEndpoint(url, name);
    }
});

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseErrorHandling();


app.UseHttpsRedirection();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();

    // endpoints.MapHealthChecks("/health", new HealthCheckOptions
    // {
    //     Predicate = _ => true,
    //     ResponseWriter = async (context, report) =>
    //     {
    //         context.Response.ContentType = "application/json";
    //         var json = JsonSerializer.Serialize(new
    //         {
    //             status = report.Status.ToString(),
    //             results = report.Entries.Select(e => new
    //             {
    //                 key = e.Key,
    //                 status = e.Value.Status.ToString(),
    //                 description = e.Value.Description,
    //                 error = e.Value.Exception?.Message,
    //                 data = e.Value.Data
    //             })
    //         });
    //         await context.Response.WriteAsync(json);
    //     }
    // });
    //
    // endpoints.MapHealthChecksUI(opt =>
    // {
    //     // opt.UseRelativeApiPath = false;
    //     // opt.UseRelativeResourcesPath = false;
    //     // opt.AsideMenuOpened = false;
    //
    //     opt.UIPath = "/health-ui";
    //     //  opt.ApiPath = "/healthAPI";
    // });
});


app.Run();
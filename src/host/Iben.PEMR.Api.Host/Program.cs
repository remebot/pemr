using MongoDB.Driver;
using Serilog;
namespace Iben.PEMR.Api.Host;

public class Program
{
    public async static Task<int> Main(string[] args)
    {
        // create sink instance with custom mongodb settings.
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("Logs/core-logs.txt", rollingInterval: RollingInterval.Day, retainedFileTimeLimit: TimeSpan.FromDays(15))
            .WriteTo.MongoDBBson(cfg =>
            {
                // custom MongoDb configuration
                var mongoDbSettings = new MongoClientSettings
                {
                    UseTls = false,
                    AllowInsecureTls = true,
                    Credential = MongoCredential.CreateCredential("admin", "root", "Aa117628"),
                    Server = new MongoServerAddress("139.224.205.180", 27017),
                };

                var mongoDbInstance = new MongoClient(mongoDbSettings).GetDatabase("test");

                // sink will use the IMongoDatabase instance provided
                cfg.SetMongoDatabase(mongoDbInstance);
                cfg.SetCollectionName("20240410");
                cfg.SetRollingInternal(Serilog.Sinks.MongoDB.RollingInterval.Month);
            })
            .CreateLogger();

        try
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Host.UseAutofac();
            builder.Services.AddSerilog();
            
            // Add services to the container.
            await builder.AddApplicationAsync<ApiHostModule>();

            var app = builder.Build();
            
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSerilogRequestLogging();
            await app.InitializeApplicationAsync();
            await app.RunAsync();

            return 0;
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Application terminated unexpectedly");
            return 1;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}

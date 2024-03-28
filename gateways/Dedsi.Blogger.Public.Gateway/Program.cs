using Dedsi.Blogger.Ocelot;
using Serilog;
using Serilog.Events;

namespace Dedsi.Blogger.Public.Gateway;

public class Program
{
    public async static Task<int> Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            #if DEBUG
            .MinimumLevel.Debug()
            #else
            .MinimumLevel.Information()
            #endif
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
            .Enrich.FromLogContext()
            .WriteTo.Async(c => c.File("Logs/logs.txt",rollingInterval:RollingInterval.Day))
            .WriteTo.Async(c => c.Console())
            .CreateLogger();

        try
        {
            Log.Information("Dedsi.Blogger.Public.Gateway start.");
            var builder = WebApplication.CreateBuilder(args);
            builder.Host.UseAutofac().UseSerilog();
            builder.Configuration.AddOcelotFile(builder.Environment);
            await builder.AddApplicationAsync<DedsiBloggerPublicGatewayModule>();
            
            var app = builder.Build();
            await app.InitializeApplicationAsync();
            await app.RunAsync();
            
            return 0;
        }
        catch (Exception ex)
        {
            if (ex is HostAbortedException)
            {
                throw;
            }

            Log.Fatal(ex, "Dedsi.Blogger.Public.Gateway Error.");
            return 1;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}
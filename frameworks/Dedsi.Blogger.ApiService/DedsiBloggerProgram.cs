using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Volo.Abp.Modularity;

namespace Dedsi.Blogger.ApiService;

public class DedsiBloggerProgram
{
    protected static async Task<int> RunMain<TModule>(string apiServiceName,string[] args) where TModule : IAbpModule
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
            Log.Information(apiServiceName + " start.");
            var builder = WebApplication.CreateBuilder(args);
            builder.Host.UseAutofac().UseSerilog();
            await builder.AddApplicationAsync<TModule>();
            
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

            Log.Fatal(ex, apiServiceName + " Error.");
            return 1;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}
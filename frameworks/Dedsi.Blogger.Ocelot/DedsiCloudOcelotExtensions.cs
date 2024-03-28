using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;
using Swashbuckle.AspNetCore.SwaggerUI;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace Dedsi.Blogger.Ocelot;

public static class DedsiCloudOcelotExtensions
{
    /// <summary>
    /// 添加配置文件
    /// </summary>
    /// <param name="configuration"></param>
    /// <param name="environment"></param>
    public static void AddOcelotFile(this IConfigurationBuilder configuration,IWebHostEnvironment environment)
    {
        configuration.SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", true, true)
        .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", true, true)
        .AddJsonFile("ocelot.json",true,true)
        .AddJsonFile($"ocelot.{environment.EnvironmentName}.json", true, true);
    }

    /// <summary>
    /// 添加 Consul
    /// </summary>
    /// <param name="context"></param>
    public static IOcelotBuilder AddOcelotConsul(this ServiceConfigurationContext context)
    {
        return context.Services.AddOcelot().AddConsul();
    }

    /// <summary>
    /// UseOcelot
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public static void UseOcelotWait(this ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();

        app.UseOcelot().Wait();
    }

    /// <summary>
    /// 网关项目使用 健康检查
    /// </summary>
    /// <param name="context"></param>
    public static void UseHealthCheck(this ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();

        // 用于 Ocelot Gateway 项目，健康检查
        app.MapWhen(
            ctx => ctx.Request.Path.ToString() == "/api/Health/Check",
            app2 => {
                app2.UseRouting();
                app2.UseEndpoints(endpoints => {
                    endpoints.MapControllers();
                });
            });
    }

    /// <summary>
    /// 配置Swagger
    /// </summary>
    /// <param name="context"></param>
    /// <param name="version"></param>
    /// <param name="names"></param>
    public static void ConfigureSwaggerServices(this ServiceConfigurationContext context,string version,params string[] names)
    {
        context.Services.AddSwaggerGen(options =>
        {
            foreach (var name in names)
            {
                options.SwaggerDoc(name, new OpenApiInfo(){ Title = name + " Api", Version = version});
            }

            options.CustomSchemaIds(type => type.FullName);
            
            options.DocInclusionPredicate((doc, api) =>
            {
                if (api.GroupName == "*") { return true; }
                return doc == api.GroupName;
            });

            var directoryInfo = new DirectoryInfo(AppContext.BaseDirectory);
            var fileInfos = directoryInfo.GetFileSystemInfos()
                .Where(a => a.Extension == ".xml")
                .Where(a => a.Name.EndsWith("Application.xml") || a.Name.EndsWith("HttpApi.xml"));
        
            foreach (var info in fileInfos)
            {
                var xmlPath = Path.Combine(AppContext.BaseDirectory, info.Name);
                options.IncludeXmlComments(xmlPath,true);
            }
            
            foreach (var name in names)
            {
                var xmlPath = Path.Combine(AppContext.BaseDirectory, name + ".xml");
                // 文件存在添加
                if (File.Exists(xmlPath))
                {
                    options.IncludeXmlComments(xmlPath,true);
                }
            }
            
            options.AddSecurityDefinition("BearerToken", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                Description = "请输入Token!"
            });
        
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "BearerToken" }
                    },
                    new string[] {}
                }
            });
        });
    }
    
    
    /// <summary>
    /// UseSwaggerUI
    /// </summary>
    /// <param name="context"></param>
    public static void UseOcelotSwaggerUI(this ApplicationInitializationContext context,string version, params string[] names)
    {
        var app = context.GetApplicationBuilder();

        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            foreach (var name in names)
            {
                options.SwaggerEndpoint($"/swagger/{name}/swagger.json",name + " Api " + version);
            }
            options.DocExpansion(DocExpansion.None);
            options.DefaultModelsExpandDepth(-1);
        });
    }

}
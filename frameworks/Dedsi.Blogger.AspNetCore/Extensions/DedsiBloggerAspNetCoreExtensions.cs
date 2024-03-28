using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace Dedsi.Blogger.AspNetCore.Extensions;

public static class DedsiBloggerAspNetCoreExtensions
{
    /// <summary>
    /// 配置授权
    /// </summary>
    /// <param name="context"></param>
    /// <exception cref="UserFriendlyException"></exception>
    public static void ConfigureAuthentication(this ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();

        context.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromHours(1),
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["AuthenticationCenterOptions:Issuer"],
                    ValidAudience = configuration["AuthenticationCenterOptions:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["AuthenticationCenterOptions:SecurityKey"]!))
                };
            });
    }
    
    /// <summary>
    /// 配置Swagger
    /// </summary>
    /// <param name="context"></param>
    /// <param name="apiServiceName"></param>
    /// <param name="apiServiceVersion"></param>
    public static void ConfigureSwaggerServices(this ServiceConfigurationContext context,string apiServiceName, string apiServiceVersion)
    {
        context.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc(apiServiceName, new OpenApiInfo(){ Title = apiServiceName + " ApiService",Version = apiServiceVersion });
        
            options.CustomSchemaIds(type => type.FullName);

            var directoryInfo = new DirectoryInfo(AppContext.BaseDirectory);
            var fileInfos = directoryInfo.GetFileSystemInfos()
                .Where(a => a.Extension == ".xml")
                .Where(a => a.Name.EndsWith("Application.xml") || a.Name.EndsWith("HttpApi.xml"));
        
            foreach (var info in fileInfos)
            {
                var xmlPath = Path.Combine(AppContext.BaseDirectory, info.Name);
                options.IncludeXmlComments(xmlPath,true);
            }
            
            options.DocInclusionPredicate((doc, api) =>
            {
                if (api.GroupName == "*") { return true; }
                return doc == api.GroupName;
            });
            
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
    /// 使用 Swagger
    /// </summary>
    /// <param name="context"></param>
    /// <param name="apiServiceName"></param>
    /// <param name="apiServiceVersion"></param>
    public static void UseSwaggerServices(this ApplicationInitializationContext context,string apiServiceName, string apiServiceVersion)
    {
        var app = context.GetApplicationBuilder();
        
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint($"/swagger/{apiServiceName}/swagger.json",$"{apiServiceName} ApiService {apiServiceVersion}");
            
            options.DocExpansion(DocExpansion.None);
            options.DefaultModelsExpandDepth(-1);
        });
    }
    
}
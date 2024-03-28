using Consul;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Volo.Abp;

namespace Dedsi.Blogger.Consul;

public static class DedsiBloggerConsulExtensions
{
    /// <summary>
    /// Consul
    /// </summary>
    /// <param name="context"></param>
    /// <exception cref="Exception"></exception>
    public static void UseConsul(this ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();

        var consulConfigOptions = context.ServiceProvider.GetRequiredService<IOptions<ConsulConfigOptions>>();
        var consulConfig = consulConfigOptions.Value;
    
        // 未启用
        if (consulConfig.IsEnabled == false)
        {
            return;
        }
        
        if (string.IsNullOrWhiteSpace(consulConfig.ServiceScheme) || string.IsNullOrEmpty(consulConfig.ServiceScheme))
        {
            consulConfig.ServiceScheme = "http";
        }
        
        var consulClient = new ConsulClient(p => { p.Address = new Uri(consulConfig.ConsulAddress); });
            
        //心跳检测设置
        var httpCheck = new AgentServiceCheck()
        {
            Interval = TimeSpan.FromSeconds(10), //间隔多久心跳检测一次
            Timeout = TimeSpan.FromSeconds(10),  //心跳检测超时时间
            DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(1), //心跳检测失败多久后注销

            HTTP = $"{consulConfig.ServiceScheme}://{consulConfig.ServiceIP}:{consulConfig.ServicePort}" + consulConfig.ServiceCheckUrl
        };
        
        //注册信息
        var registration = new AgentServiceRegistration()
        {
            ID = $"{consulConfig.ServiceName}-{Guid.NewGuid().ToString().Replace("-","")}", //服务ID，唯一
            Name = consulConfig.ServiceName, //服务名（如果服务搭集群，它们的服务名应该是一样的，但是ID不一样）
            Address = consulConfig.ServiceIP, //服务地址
            Port = consulConfig.ServicePort, //服务端口
            Tags = consulConfig.ServiceTags, //服务标签，一般可以用来设置权重等本地服务特有信息
            Check = httpCheck, //心跳检测设置
        };

        //向Consul注册服务
        consulClient.Agent.ServiceRegister(registration).Wait();
        
        // 应用程序终止时，注销服务
        var lifetime = app.ApplicationServices.GetRequiredService<IHostApplicationLifetime>();
        lifetime.ApplicationStopping.Register(() => {
            consulClient.Agent.ServiceDeregister(registration.ID).Wait();
        });
    }
    
}
using Dedsi.Blogger.Consul;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Dedsi.Blogger.FileCenter.ApiService.Controllers;

public class HealthController(IOptions<ConsulConfigOptions> consulConfigOption) : FileCenterController
{
    /// <summary>
    /// 心跳检查接口
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public Task<string> CheckAsync() => Task.FromResult(consulConfigOption.Value.ServiceName + " is Ok!!!");
}
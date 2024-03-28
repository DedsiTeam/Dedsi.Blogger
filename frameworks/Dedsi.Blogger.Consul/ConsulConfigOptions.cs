namespace Dedsi.Blogger.Consul;

public class ConsulConfigOptions
{
    public const string Key = "ConsulConfigOptions";

    /// <summary>
    /// 是否启用
    /// </summary>
    public bool IsEnabled { get; set; } = true;

    /// <summary>
    /// Consul地址
    /// </summary>
    public string ConsulAddress { get; set; }

    /// <summary>
    /// http / https
    /// </summary>
    public string ServiceScheme { get; set; }
    /// <summary>
    /// 服务IP
    /// </summary>
    public string ServiceIP { get; set; }

    /// <summary>
    /// 服务端口
    /// </summary>
    public int ServicePort { get; set; }

    /// <summary>
    /// 服务名字
    /// </summary>
    public string ServiceName { get; set; }

    /// <summary>
    /// 健康检查地址
    /// </summary>
    public string ServiceCheckUrl { get; set; }

    /// <summary>
    /// 服务标签
    /// </summary>
    public string[] ServiceTags { get; set; }
}
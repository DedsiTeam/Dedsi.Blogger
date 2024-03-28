namespace Dedsi.Blogger.FileCenter;

public static class FileCenterDbProperties
{
    public static string DbTablePrefix { get; set; } = "FileCenter";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "FileCenterDB";
}

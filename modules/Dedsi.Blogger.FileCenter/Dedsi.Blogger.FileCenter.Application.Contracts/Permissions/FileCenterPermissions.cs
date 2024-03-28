using Volo.Abp.Reflection;

namespace Dedsi.Blogger.FileCenter.Permissions;

public class FileCenterPermissions
{
    public const string GroupName = "FileCenter";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(FileCenterPermissions));
    }
}

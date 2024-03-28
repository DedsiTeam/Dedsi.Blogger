using Dedsi.Blogger.FileCenter.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Dedsi.Blogger.FileCenter.Permissions;

public class FileCenterPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(FileCenterPermissions.GroupName, L("Permission:FileCenter"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<FileCenterResource>(name);
    }
}

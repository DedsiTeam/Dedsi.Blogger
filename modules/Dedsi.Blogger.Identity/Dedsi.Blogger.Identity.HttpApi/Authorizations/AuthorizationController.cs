using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Dedsi.Blogger.Identity.Authorizations;

public class AuthorizationController(IAuthorizationAppService authorizationAppService) : IdentityBaseController
{
    /// <summary>
    /// 登录
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public Task<LoginResultDto> LoginAsync(LoginInputDto input)
    {
        return authorizationAppService.LoginAsync(input);
    }
}
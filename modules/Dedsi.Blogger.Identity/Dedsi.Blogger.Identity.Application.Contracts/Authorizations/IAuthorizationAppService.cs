using System.Threading.Tasks;

namespace Dedsi.Blogger.Identity.Authorizations;

public interface IAuthorizationAppService
{
    /// <summary>
    /// 登录
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<LoginResultDto> LoginAsync(LoginInputDto input);
}
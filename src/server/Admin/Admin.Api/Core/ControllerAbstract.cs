using Microsoft.AspNetCore.Mvc;

namespace Admin.Api.Core
{
    /// <summary>
    /// 控制器抽象
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [PermissionValidate]
    public abstract class ControllerAbstract : ControllerBase
    {
    }
}

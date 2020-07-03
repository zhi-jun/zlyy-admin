using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ZLYY.Framework.Dependency;
using ZLYY.Utils.Extensions;

namespace Admin.Api.Core
{
    public class PermissionValidateHandler : IPermissionValidateHandler, ISingletonDependency
    {
        private readonly ILoginInfo _loginInfo;
        private readonly IAccountPermissionResolver _permissionResolver;

        public PermissionValidateHandler(ILoginInfo loginInfo, IAccountPermissionResolver permissionResolver)
        {
            _loginInfo = loginInfo;
            _permissionResolver = permissionResolver;
        }

        public async Task<bool> Validate(IDictionary<string, string> routeValues, HttpMethod httpMethod)
        {
            var permissions = await _permissionResolver.Resolve(_loginInfo.UserId, _loginInfo.Platform);

            var area = routeValues["area"];
            var controller = routeValues["controller"];
            var action = routeValues["action"];
            return permissions.Any(m => m.EqualsIgnoreCase($"{area}_{controller}_{action}_{httpMethod}"));
        }
    }
}

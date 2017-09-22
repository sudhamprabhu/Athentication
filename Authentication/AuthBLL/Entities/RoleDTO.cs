using Microsoft.AspNet.Identity.EntityFramework;

namespace AuthBLL.Entities
{
    public class RoleDTO : IdentityRole<long, UserRoleDTO>
    {
    }
}

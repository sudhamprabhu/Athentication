using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImsApi.Entities.User
{
    public class LoggedUser
    {
        public long UserId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int? OrgId { get; set; }
        public string Role { get; set; }
        public List<UserClaim> UserClaimList { get; set;}
    }

    public class UserClaim
    {
        public string Type { get; set; }
        public string  Value { get; set; }
    }
}

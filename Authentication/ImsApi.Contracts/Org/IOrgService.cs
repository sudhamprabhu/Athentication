using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImsApi.Entities.Org;
//using IMSBLL.Entities;

namespace ImsApi.Contracts.Org
{
   public interface IOrgService
    {
       // List<OrganizationModel> GetOrgList();

        OrganizationModel GetOrgDetail(int OrganizationId);

    }
}

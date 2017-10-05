using AuthBLL.Entities;
using AuthBLL;
using IMSBLL;
using IMSBLL.Entities;
using ImsApi.Contracts.Org;
using ImsApi.Entities.Org;

namespace ImsApi.Services.Org
{
    public class OrgService : ApiServiceBase,IOrgService
    {
        IMSRepository iMSRepository;
        public OrgService() : base()
        {
            iMSRepository = new IMSRepository();
        }

        public OrganizationModel GetOrgDetail(int OrganizationId)
        {
           
            var OrganizationDTO =  iMSRepository.GetOrganizationOnId(OrganizationId);
            var organizationModel = new OrganizationModel()
            {
                OrgId = OrganizationDTO.OrganizationId,
                Address = OrganizationDTO.Address + ' ' + OrganizationDTO.Country + ' ' + OrganizationDTO.State,
                Phone = OrganizationDTO.PhoneNo,
                Name=OrganizationDTO.Name,
                Code=OrganizationDTO.Code
            };
            return organizationModel;
        }
    }
}

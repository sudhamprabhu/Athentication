using System;
using System.Threading.Tasks;
using IMSBLL.Entities;
using AutoMapper;
using IMSBLL.Model;

namespace IMSBLL
{
    public class IMSRepository : IDisposable
    {
        private readonly IMSDbContext dbContext;

        public IMSRepository()
        {
            dbContext = new IMSDbContext();
        }
        ~IMSRepository()
        {
            Dispose();
        }

        public async Task<OrganizationDTO> SaveOrganizationDetails(OrganizationDTO organizationDTO)
        {
            var organization = dbContext.Organizations.Create<Organization>();          
            organization = Mapper.Map<OrganizationDTO, Organization>(organizationDTO);
            dbContext.Organizations.Add(organization);
            dbContext.SaveChanges();
            organizationDTO = Mapper.Map<Organization, OrganizationDTO>(organization);
            return  organizationDTO;
        }

        public void Dispose()
        {
           dbContext.Dispose();
        }
    }
        
}

using System;
using System.Threading.Tasks;
using AuthBLL.Model;
using AuthBLL.Entities;
using AutoMapper;

namespace AuthBLL
{
    public class IMSRepository : IDisposable
    {
        private readonly IMSDbContext dbContext;

        public IMSRepository()
        {
            dbContext = new IMSDbContext();
           

        }

        public OrganizationDTO SaveOrganizationDetails(OrganizationDTO organizationDTO)
        {


            var organization =  dbContext.Organizations.Create<Organization>();          
            //var organization = new Organization();
            organization =  Mapper.Map<OrganizationDTO, Organization>(organizationDTO);
            dbContext.Organizations.Add(organization);
            dbContext.SaveChanges();
            organizationDTO =  Mapper.Map<Organization, OrganizationDTO>(organization);
            return  organizationDTO;
        }

        public void Dispose()
        {
           dbContext.Dispose();
        }
    }
        
}

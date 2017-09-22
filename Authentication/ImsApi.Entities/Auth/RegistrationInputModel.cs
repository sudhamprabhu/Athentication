
namespace ImsApi.Entities.Auth
{
    public class RegistrationInputModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Email { get; set; }

        public OrganizationInputModel OrganizationInputModel { get; set; }

    }

    public class OrganizationInputModel
    {
        public int OrganizationId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Type { get; set; }
        public string PhoneNo { get; set; }
        public int Country { get; set; }
        public int State { get; set; }
    }
}

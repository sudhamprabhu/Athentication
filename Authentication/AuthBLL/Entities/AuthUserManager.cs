using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace AuthBLL.Entities
{
    public class AuthUserManager : UserManager<UserDTO, long>
    {
        #region constructors and destructors

        public AuthUserManager(IUserStore<UserDTO, long> store) : base(store)
        {

        }

        #endregion

        #region methods

        public static AuthUserManager Create(IdentityFactoryOptions<AuthUserManager> options, IOwinContext context)
        {
            var manager = new AuthUserManager(new UserStore<UserDTO, RoleDTO, long,LoginDTO,UserRoleDTO,ClaimDTO>(context.Get<AuthDbContext>()));

            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<UserDTO, long>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug in here.
            manager.RegisterTwoFactorProvider(
                "PhoneCode",
                new PhoneNumberTokenProvider<UserDTO, long>
                {
                    MessageFormat = "Your security code is: {0}"
                });
            manager.RegisterTwoFactorProvider(
                "EmailCode",
                new EmailTokenProvider<UserDTO, long>
                {
                    Subject = "Security Code",
                    BodyFormat = "Your security code is: {0}"
                });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<UserDTO, long>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }

        #endregion
    }
}
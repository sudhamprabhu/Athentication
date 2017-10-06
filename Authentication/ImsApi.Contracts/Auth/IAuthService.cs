using Owin;
using ImsApi.Entities.Auth;
using ImsApi.Entities.User;
using AuthBLL.Entities;
using System.Threading.Tasks;

namespace ImsApi.Contracts.Auth
{
   public interface IAuthService
    {
        Task<bool> RegisterUser(RegistrationInputModel registrationInputModel);

        bool GetUser(UserInputModel userInputModel);

        LoggedUser GetUser(int UserId);

        Task<UserDTO> GetUser(string userName, string password);
    }
}

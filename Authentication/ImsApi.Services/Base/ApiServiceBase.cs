using AuthBLL;

namespace ImsApi.Services
{
   public  abstract class ApiServiceBase
    {
        AuthRepository authRepository;

        public ApiServiceBase(AuthRepository _authRepository)
        {
            authRepository = _authRepository;
        }

        public ApiServiceBase()
        {
            authRepository = null;
        }
    }
}



namespace Utill
{
   public  class CallContaxt
    {
        private int _userId;
        private string _userName;
        private string _userEmail;
        private string _homeTown;

        public CallContaxt(int UserId)
        {
            UserId = _userId;
        }

        public string UserName
        {
            
            get
            {
                SetProperty();
                return  _userName;
            }
        }

        private void SetProperty()
        {

        }
    }
}

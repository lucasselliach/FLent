using FLentProject.Infra.CrossCutting.Auth.Interfaces;

namespace FLentProject.Infra.CrossCutting.Auth
{
    public class UserIdentity : IUserIdentity
    {
        private string _userId;
        private string _role;

        public void SetUserId(string userId)
        {
            _userId = userId;
        }

        public void SetRole(string role)
        {
            _role = role;
        }

        public string GetUserId()
        {
            return _userId;
        }

        public string GetRole()
        {
            return _role;
        }
    }
}

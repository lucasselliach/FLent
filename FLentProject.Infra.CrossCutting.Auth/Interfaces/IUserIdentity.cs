namespace FLentProject.Infra.CrossCutting.Auth.Interfaces
{
    public interface IUserIdentity
    {
        void SetUserId(string userId);
        void SetRole(string role);
        string GetUserId();
        string GetRole();
    }
}

using System.Threading.Tasks;

namespace VideoVault.WebUI.Services
{
    public interface IIdentityService
    {
        Task<bool> AuthenticateAsync(string userName, string password);
        string GetToken();
        void Logout();
    }
}
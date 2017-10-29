using System.Threading.Tasks;

namespace Domain
{
    public interface IAccountService
    {
        Task CreateBooker(string aspUserId);
        Task CreateRestouranteor(string aspUserId);
        int GetUserProfileId(string id);
    }
}
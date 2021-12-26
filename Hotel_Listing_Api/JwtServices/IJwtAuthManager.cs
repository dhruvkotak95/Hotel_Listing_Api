using Hotel_Listing_Api.DTO_Models;
using System.Threading.Tasks;

namespace Hotel_Listing_Api.JwtServices
{
    public interface IJwtAuthManager
    {
        Task<bool> ValidateUser(LoginDTO login);
        Task<string> CreateToken();
    }
}

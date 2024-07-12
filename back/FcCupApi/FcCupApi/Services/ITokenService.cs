using FcCupApi.Models;
using Microsoft.AspNetCore.Identity;

namespace FcCupApi.Services
{
    public interface ITokenService
    {
        string CreateToken(User user, List<IdentityRole<long>> role);
    }
}

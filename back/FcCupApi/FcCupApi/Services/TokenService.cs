using FcCupApi.Extensions;
using FcCupApi.Models;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace FcCupApi.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateToken(User user, List<IdentityRole<long>> roles)
        {
            var token = user
                .CreateClaims(roles)
                .CreateJwtToken(_configuration);
            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }
    }
}

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using IntermediateLab_Backend.Application.Interfaces.Security;
using Microsoft.IdentityModel.Tokens;
using SmartHealth_Domain.Enums;

namespace SmartHealth_Application.Security;

public class TokenManager(TokenManager.Config config): ITokenManager
{
    public class Config
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int Duration { get; set; }
    }
    public string GenerateToken(int id, string name, RolesEnum role)
    {
        JwtSecurityTokenHandler tokenHandler = new ();
        JwtSecurityToken securityToken = new 
        (
            config.Issuer,
            config.Audience,
            CreateClaims(id, name, role),
            DateTime.Now,
            DateTime.Now.AddSeconds(config.Duration),
            new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.Secret)), SecurityAlgorithms.HmacSha256)
            );
        return tokenHandler.WriteToken(securityToken);
    }

    private IEnumerable<Claim> CreateClaims(int id, string name, RolesEnum role)
    {
        yield return new Claim(ClaimTypes.Name, name);
        yield return new Claim(ClaimTypes.Role, role.ToString());
        yield return new Claim(ClaimTypes.NameIdentifier, id.ToString(), ClaimValueTypes.Integer32);
    }
    
    public int validateTokenWithoutLifetime(string token)
    {
        JwtSecurityTokenHandler tokenHandler = new ();
        TokenValidationParameters validationParameters = new()
        {
            ValidIssuer = config.Issuer,
            ValidateAudience = true,
            ValidAudience = config.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.Secret)),
            ValidateLifetime = false,
        };
        ClaimsPrincipal? result = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken securityToken);
        return int.Parse(result?.FindFirst(ClaimTypes.NameIdentifier)?.Value??"-1");
    }
}

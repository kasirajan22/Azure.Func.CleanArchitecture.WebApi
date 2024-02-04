using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DomainLayer;
using Microsoft.IdentityModel.Tokens;

namespace ApplicationLayer;

public static class JwtManager
{
    public static string Generate(User user, Guid sessionId)
    {
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("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"));
        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.Now.AddMinutes(480);
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Sid, Convert.ToString(user.Id) ?? ""),
            new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
            new Claim(ClaimTypes.Email, user.UserName),
            new Claim(ClaimTypes.NameIdentifier, user.NameIdentifier),
            new Claim(ClaimTypes.Hash, Convert.ToString(sessionId) ?? ""),
            new Claim(ClaimTypes.Expiration, expires.ToString()),
        };
        var token = new JwtSecurityToken(
            issuer: "https://localhost:7024",
            audience: "https://localhost:7024",
            claims: claims,
            notBefore: DateTime.Now,
            expires: expires,
            signingCredentials: signinCredentials
        );
        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
        return tokenString;
    }
}
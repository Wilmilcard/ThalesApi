using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ThalesApi.Utils
{
    public class JWTHelper
    {
        private readonly byte[] secret;

        public JWTHelper(string secretKey)
        {
            this.secret = Encoding.ASCII.GetBytes(secretKey);
        }

        public string CreateToken(string _username, DateTime _expiration_date)
        {
            var claims = new ClaimsIdentity();

            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, _username));

            var _siginCredentials = new SigningCredentials(new SymmetricSecurityKey(this.secret), SecurityAlgorithms.HmacSha256Signature);

            var tokenDescription = new SecurityTokenDescriptor()
            {
                Subject = claims,
                NotBefore = Globals.SystemDate(),
                Expires = _expiration_date,
                SigningCredentials = _siginCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescription);

            return tokenHandler.WriteToken(createdToken);
        }
    }
}

using LoginRegister.DBO.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LoginRegisterAPI.Helper
{
    public class Helper
    {
        public string GetJWTToken(string username)
        {

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("f4LZOS1MJ+lwLI+NZDSatxQffwf4CMnCUyAJaEcd/tm5tcLhXkuV9bO+bYF+NgdmrJqE69LDDiQotz0rQIfJqw=="));
            //var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWTCoreSettings:SecretKey"]));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: "http://localhost:5000",
                audience: "http://localhost:5000",
                claims: new List<Claim>() ,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return tokenString;
        }

        internal string GetUserId()
        {
            throw new NotImplementedException();
        }

        internal string EncryptPassword()
        {
            throw new NotImplementedException();
        }
    }
}

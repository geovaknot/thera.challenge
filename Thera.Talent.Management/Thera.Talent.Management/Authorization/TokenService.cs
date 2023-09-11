using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Thera.Talent.Management.Domain.Entities;

namespace Thera.Talent.Management.Authorization
{
    public static class TokenService
    {
        public static object GetToken(User user)
        {
            var key = ConfigurationManager.AppSettings["JwtKey"];

            var issuer = ConfigurationManager.AppSettings["JwtIssuer"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //Create a List of Claims, Keep claims name short    
            var permClaims = new List<Claim>();
            permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            permClaims.Add(new Claim("userId", user.Id.ToString()));
            permClaims.Add(new Claim(JwtRegisteredClaimNames.Name, user.Name));
            permClaims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            permClaims.Add(new Claim(ClaimTypes.Role, user.Profile.ToString()));


            //Create Security Token object by giving required parameters
            var expires = DateTime.Now.AddMinutes(30);

            var token = new JwtSecurityToken(issuer,
                                            issuer,
                                            permClaims,
                                            expires: expires,
                                            signingCredentials: credentials);
            var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);

            var response = new TokenData()
            {
                AcessToken = jwt_token,
                Expires = expires
            };

            return response;
        }
    }
}
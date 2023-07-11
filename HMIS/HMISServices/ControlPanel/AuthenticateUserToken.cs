using HMIS.Data.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HMIS.Common.Helpers;
using HMIS.Common.BindingModels.ControlPanel;
using HMIS.Common.BindingModels.Common;
using HMIS.Data.Entities.ControlPanel;
using HMISData.Models;

namespace HMIS.Services.ControlPanel
{
    public class AuthenticateUserToken : IAuthenticateUserToken
    {
        #region Fields
        private readonly HMIS_dbContext _HMISdbContext;
        private IConfiguration _config;
        #endregion
        #region ctor
        public AuthenticateUserToken
            (
            IConfiguration Configuration,
            HMIS_dbContext HMISdbContext
            )
        {
            _HMISdbContext = HMISdbContext;
            _config = Configuration;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Create a User Based Token 
        /// </summary>
        /// <returns>JWT Token on Authenticate User</returns>
        public string GenerateTokenJWT(string userName, string Id,List<Roles> roles)
        {
            var authClaims = new List<Claim>
                {
                    new Claim("UserId",Id),
                    new Claim("UserName", userName),
                    new Claim(JwtRegisteredClaimNames.UniqueName, userName),
                 


        };

            foreach (var item in roles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, item.Name));
            }


            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var expiry = DateTime.Now.AddMinutes(120);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer: issuer, audience: audience,
                expires: expiry, claims: authClaims, signingCredentials: credentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }

        /// <summary>
        /// Check Valid User 
        /// </summary>
        /// <param name="loginDetalhes"></param>
        /// <returns>Return Authenticate User/Password</returns>
        public async Task<AuthenticateUserResponse> ValidarUser(AuthernticateUserToken loginDetails)
        {
            // var user = new Users();
            var user = await Task.Run(() => _HMISdbContext.HREmployee
            .Where(x => x.UserName == loginDetails.Name)
            .Select(x => new {
                x.EmployeeId,
                x.UserName,
                x.Password
            }).SingleOrDefault());



            // user = _mapper.Map<Users>(getAuthenticate);
            if (user != null)
            {
                HashingHelper hashHelper = HashingHelper.GetInstance();

                string pwdHash = hashHelper.ComputeHash(loginDetails.Password);
                if (pwdHash == user.Password)

                    return new AuthenticateUserResponse() { User = new HREmployee { EmployeeId = user.EmployeeId, UserName = user.UserName } };
            }

            return new AuthenticateUserResponse(); ;//"User Not Valid";
        }



        #endregion


    }
}

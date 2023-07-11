using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMIS.Common.BindingModels.Common;
using HMIS.Common.BindingModels.ControlPanel;

namespace HMIS.Services.ControlPanel
{
    public interface IAuthenticateUserToken
    {
        /// <summary>
        /// Create a User Based Token 
        /// </summary>
        /// <returns>JWT Token on Authenticate User</returns>
        public string GenerateTokenJWT(string userName, string Id, List<Roles> roles);

        /// <summary>
        /// Check Valid User 
        /// </summary>
        /// <param name="loginDetalhes"></param>
        /// <returns>Return Authenticate User/Password</returns>
        Task<AuthenticateUserResponse> ValidarUser(AuthernticateUserToken loginDetails);

    }
}

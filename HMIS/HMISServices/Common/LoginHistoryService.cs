using Dapper;
using HMIS.Common.Logger;
using HMIS.Common.ORM;
using HMIS.Data.Entities.Common;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMIS.Services.Common
{
    public static class LoginHistoryService
    {

        public static void LogHistory(LoginUserHistory userlogin)
        {
			try
			{
                DynamicParameters param = new DynamicParameters();
                param.Add("@Token", $"{userlogin.Token}");
                param.Add("@LoginUserName", $"{userlogin.LoginUserName}");

                param.Add("@IPAddress", $"{userlogin.IPAddress}");
                param.Add("@LoginTime", $"{userlogin.LoginTime}");


                param.Add("@LogoffTime", $"{userlogin.LogoffTime}");
                param.Add("@LastActivityTime", $"{userlogin.LastActivityTime}");



                param.Add("@UserLogOut", $"{userlogin.UserLogOut}");
                param.Add("@CreatedOn", $"{userlogin.CreatedOn}");


                param.Add("@CreatedBy", $"{userlogin.CreatedBy}");


                param.Add("@UpdatedOn", $"{userlogin.UpdatedOn}");

                param.Add("@UpdatedBy", $"{userlogin.UpdatedBy}");


                DapperHelper.ExcecuteSPByParams("[dbo].[SEC_LoginHistoryUpdate]", param);



            }
			catch (Exception ex)
			{
              

            }
        }

       

    }
}

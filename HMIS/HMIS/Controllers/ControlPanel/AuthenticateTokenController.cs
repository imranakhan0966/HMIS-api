using HMIS.Common.BindingModels.Common;
using HMIS.Common.BindingModels.ControlPanel;
using HMIS.Common.Logger;
using HMIS.Data.Entities.Common;
using HMIS.Services.Common;
using HMIS.Services.ControlPanel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace HMIS.Controllers.ControlPanel
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticateTokenController : ControllerBase
    {
        #region feilds
        private IAuthenticateUserToken _authenticateUserToken;
        #endregion

        #region ctor
        public AuthenticateTokenController(IAuthenticateUserToken authenticateUserToken)
        {
            _authenticateUserToken = authenticateUserToken;
        }
        #endregion

        #region methods


        [Route("RoleTester")]
        [Authorize(Roles="Admin")]
        [HttpGet]
     
        public async Task<IActionResult> Test()
        {
            return Ok("Test done");
        }

        [Route("Login")]
        //[RequireHttps]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] AuthernticateUserToken user)
        {

            try
            {
                //FILE BASED
                NLogHelper.WriteLog(new LogParameter() { Message = "User landed at Login", ActionDetails = $"Login > user  = {user.ToString()}", ActionId = 1, ActionTime = DateTime.Now, FormName = "Login", ModuleName = "AuthenticateTokenController.cs", UserName = "System", TablesReadOrModified = 0, UserLoginHistoryId = 17 }, (short)NLog.LogLevel.Info.Ordinal, "User landed at Login");


                var remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress;


                var result = await _authenticateUserToken.ValidarUser(user);
                //var splitResult = result.Split(':');
                if (result.User != null)
                {

                    //FILE BASED
                    NLogHelper.WriteLog(new LogParameter() { Message = "User validated ok", ActionDetails = $"Login > user  = {result.User.ToString()}", ActionId = 1, ActionTime = DateTime.Now, FormName = "Login", ModuleName = "AuthenticateTokenController.cs", UserName = "System", TablesReadOrModified = 0, UserLoginHistoryId = 17 }, (short)NLog.LogLevel.Info.Ordinal, $"Login > user  = {result.User.ToString()}");



                    //Dynamic log


                    string username = result.User.UserName;
                    long empId = result.User.EmployeeId;
                    var permissions = await PermissionService.GetPermissionByEmpIdandUserId(empId, username);



                    //FILE BASED
                    NLogHelper.WriteLog(new LogParameter() { Message = "Got permissions", ActionDetails = $"Login > permissionsModulesCount  = {permissions?.Modules?.Count} , permissionsRoleCount = {permissions?.Roles?.Count}", ActionId = 1, ActionTime = DateTime.Now, FormName = "Login", ModuleName = "AuthenticateTokenController.cs", UserName = "System", TablesReadOrModified = 0, UserLoginHistoryId = 17 }, (short)NLog.LogLevel.Info.Ordinal, $"Login > permissionsModulesCount  = {permissions?.Modules?.Count} , permissionsRoleCount = {permissions?.Roles?.Count}");



                    var tokenString = _authenticateUserToken.GenerateTokenJWT(user.Name, result.User.EmployeeId.ToString(), permissions?.Roles == null?new List<Roles>(): permissions?.Roles);




                    //FILE BASED
                    NLogHelper.WriteLog(new LogParameter() { Message = "Got token", ActionDetails = $"Login > token  = {tokenString}", ActionId = 1, ActionTime = DateTime.Now, FormName = "Login", ModuleName = "AuthenticateTokenController.cs", UserName = "System", TablesReadOrModified = 0, UserLoginHistoryId = 17 }, (short)NLog.LogLevel.Info.Ordinal, $"Login > token  = {tokenString}");



                    LoginUserHistory userlogin = new LoginUserHistory()
                    {

                        Token = tokenString,
                        LoginUserName = user.Name,
                        LogoffTime = null,
                        IPAddress = remoteIpAddress.ToString(),
                        UpdatedOn = DateTime.Now,
                        UpdatedBy = "system",
                        LoginTime = DateTime.Now,
                        LastActivityTime = null,
                        UserLogOut = false,
                        CreatedOn = DateTime.Now,
                        CreatedBy = "system"





                    };




                    LoginHistoryService.LogHistory(userlogin);




                    return Ok(new { token = tokenString, allowscreens = permissions?.Permissions, userId = user.Name, success = true });
                }

                else
                {
                    //FILE BASED
                    NLogHelper.WriteLog(new LogParameter() { Message = "User response empty", ActionDetails = $"Login", ActionId = 1, ActionTime = DateTime.Now, FormName = "Login", ModuleName = "AuthenticateTokenController.cs", UserName = "System", TablesReadOrModified = 0, UserLoginHistoryId = 17 }, (short)NLog.LogLevel.Info.Ordinal, "User response empty");



                    return BadRequest(result);
                }
            }
            catch (Exception ex)
            {
                //FILE BASED
                NLogHelper.WriteLog(new LogParameter() { Message = "Login exception", ActionDetails = $"Login > exception = {ex.InnerException} {ex.Message}", ActionId = 1, ActionTime = DateTime.Now, FormName = "Login", ModuleName = "AuthenticateTokenController.cs", UserName = "System", TablesReadOrModified = 0, UserLoginHistoryId = 17 }, (short)NLog.LogLevel.Error.Ordinal, $"Login > exception = {ex.InnerException} {ex.Message}");

                return StatusCode(500);
            }
          
        }
        #endregion


        [Route("Logout")]
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> LogOff()
        {


            try
            {
                Request.Headers.TryGetValue("Authorization", out var _token);
                var remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress;


                //FILE BASED
                NLogHelper.WriteLog(new LogParameter() { Message = "Logout fired", ActionDetails = $"Logout > _token  = {_token.ToString()}", ActionId = 1, ActionTime = DateTime.Now, FormName = "Logout", ModuleName = "AuthenticateTokenController.cs", UserName = "System", TablesReadOrModified = 0, UserLoginHistoryId = 17 }, (short)NLog.LogLevel.Info.Ordinal, $"Logout > _token  = {_token.ToString()}");

               
               // var token = new JwtSecurityToken(jwtEncodedString: _token);

                string username = User.Claims.First(c => c.Type == "UserName").Value;




                //FILE BASED
                NLogHelper.WriteLog(new LogParameter() { Message = "Logout fired", ActionDetails = $"Logout > decoded token  = {_token.ToString()}", ActionId = 1, ActionTime = DateTime.Now, FormName = "Logout", ModuleName = "AuthenticateTokenController.cs", UserName = "System", TablesReadOrModified = 0, UserLoginHistoryId = 17 }, (short)NLog.LogLevel.Info.Ordinal, $"Logout > decoded token  = {_token.ToString()}");



                LoginUserHistory userlogin = new LoginUserHistory()
                {

                    Token = _token,
                    LoginUserName = username,
                    LogoffTime = DateTime.Now,
                    IPAddress = remoteIpAddress.ToString(),
                    UpdatedOn = DateTime.Now,
                    UpdatedBy = "system",
                    LoginTime = null,
                    LastActivityTime = null,
                    UserLogOut = true,
                    CreatedOn = null,
                    CreatedBy = ""




                };


                LoginHistoryService.LogHistory(userlogin);



                return Ok(new { token = _token, name = username, success = true });

            }
            catch (Exception ex)
            {


                //FILE BASED
                NLogHelper.WriteLog(new LogParameter() { Message = "Logout fired", ActionDetails = $"Logout > exception = {ex.InnerException} {ex.Message}", ActionId = 1, ActionTime = DateTime.Now, FormName = "Logout", ModuleName = "AuthenticateTokenController.cs", UserName = "System", TablesReadOrModified = 0, UserLoginHistoryId = 17 }, (short)NLog.LogLevel.Error.Ordinal, $"Logout > exception = {ex.InnerException} {ex.Message}");


                return StatusCode(500);
            }
        
        }


    }







}

using HMISData.Models;
using HMISServices.ControlPanel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using System.Text.Json.Serialization;
using System.Text.Json;
using NuGet.Protocol;
using Newtonsoft.Json;
using HMIS.Data.Entities.ControlPanel;
using Microsoft.AspNetCore.Identity;
using HMIS.Common.Logger;
using Microsoft.AspNetCore.Authorization;
using HMIS.Common.BindingModels.ControlPanel;
using static Dapper.SqlMapper;
using System.Security.Claims;

namespace HMIS.Controllers.ControlPanel
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {

        //This will be injected
        UserManager obj = new UserManager();


        public UserController() { }

        [HttpPost("SaveLicense")]
        public async Task<IActionResult> InsertLicense(HRLicenseInfo license)
        {
            try
            {

              //string name =   User.Claims.Where(a => a.Type == "UserName").FirstOrDefault().Value;
                var result = await obj.InsertLicense(license);

                if (result)
                {
                    return Ok(new { Success = true });
                }
                else
                {
                    return Ok(new { Success = false });

                }

            }
            catch (Exception ex)
            {
                return StatusCode(500);
               
            }
        }

        [HttpPost("InsertUsers")]
        public async Task<IActionResult> InsertUsers(HREmployee employee)
        {

            //FILE BASED
            NLogHelper.WriteLog(new LogParameter() { Message = "Insert user", ActionDetails = $"Insert User", ActionId = 1, ActionTime = DateTime.Now, FormName = "Insert User", ModuleName = "UserController.cs", UserName = "System", TablesReadOrModified = 0, UserLoginHistoryId = 17 }, (short)NLog.LogLevel.Info.Ordinal, $"Insert user > object  = {employee.ToString()}");




          //  long employeeId = Convert.ToInt64(User.Claims.Where(c => c.Type == "UserId")
             //                .First().Value);


            employee.CreatedBy = User.Claims.Where(c => c.Type == "UserName").First().Value;

            foreach (var EmployeeFacility in employee.EmployeeFacility)
            {
                EmployeeFacility.CreatedBy = User.Claims.Where(c => c.Type == "UserName").First().Value;
            }

            foreach (var EmployeeRole in employee.EmployeeRole)
            {
                EmployeeRole.CreatedBy = User.Claims.Where(c => c.Type == "UserName").First().Value;
            }

            //foreach (var LicenseInfo in employee.LicenseInfo)
            //{
            //    LicenseInfo.CreatedBy = User.Claims.Where(c => c.Type == "UserName").First().Value;
            //}




       //     employee.EmployeeId = employeeId;

            var result = await obj.InsertUserDB(employee);


            //FILE BASED
            NLogHelper.WriteLog(new LogParameter() { Message = "Insert user", ActionDetails = $"Insert User", ActionId = 1, ActionTime = DateTime.Now, FormName = "Insert User", ModuleName = "UserController.cs", UserName = "System", TablesReadOrModified = 0, UserLoginHistoryId = 17 }, (short)NLog.LogLevel.Info.Ordinal, $"Insert user > result  = {result}");


            if (result)
            {
                return Ok(new { Success = true });
            }

            return BadRequest(result);
        }

        [HttpGet("{EmployeeId}")]
        public async Task<IActionResult> GetUsersByID(long EmployeeId)
        {


            //FILE BASED
            NLogHelper.WriteLog(new LogParameter() { Message = "GetUsersByID", ActionDetails = $"GetUsersByID", ActionId = 1, ActionTime = DateTime.Now, FormName = "GetUsersByID", ModuleName = "UserController.cs", UserName = "System", TablesReadOrModified = 0, UserLoginHistoryId = 17 }, (short)NLog.LogLevel.Info.Ordinal, $"GetUsersByID > Id  = {EmployeeId}");


            DataSet result = await obj.GetUserByIDDB(EmployeeId);



            //FILE BASED
            NLogHelper.WriteLog(new LogParameter() { Message = "GetUsersByID", ActionDetails = $"GetUsersByID", ActionId = 1, ActionTime = DateTime.Now, FormName = "GetUsersByID", ModuleName = "UserController.cs", UserName = "System", TablesReadOrModified = 0, UserLoginHistoryId = 17 }, (short)NLog.LogLevel.Info.Ordinal, $"GetUsersByID > data is empty?  = {result.Tables.Count==0}");



            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }




        [HttpGet("GetLicense/{HRlicenseID}")]
        public async Task<IActionResult> GetLicenseByID(long HRlicenseID)
        {


            //FILE BASED
            NLogHelper.WriteLog(new LogParameter() { Message = "GetLicenseByID", ActionDetails = $"GetUsersByID", ActionId = 1, ActionTime = DateTime.Now, FormName = "GetLicense", ModuleName = "UserController.cs", UserName = "System", TablesReadOrModified = 0, UserLoginHistoryId = 17 }, (short)NLog.LogLevel.Info.Ordinal, $"GetLicense > Id  = {HRlicenseID}");


            DataSet result = await obj.GetLicenseByID(HRlicenseID);



            //FILE BASED
            NLogHelper.WriteLog(new LogParameter() { Message = "GetLicense", ActionDetails = $"GetUsersByID", ActionId = 1, ActionTime = DateTime.Now, FormName = "GetLicense", ModuleName = "UserController.cs", UserName = "System", TablesReadOrModified = 0, UserLoginHistoryId = 17 }, (short)NLog.LogLevel.Info.Ordinal, $"GetLicense > data is empty?  = {result.Tables.Count == 0}");



            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("List")]
        public async Task<IActionResult> SearchUsers(string? FullName, string? Gender, string? Phone, string? CellNo, DateTime? JoiningDate, string? Email, int? EmployeeType,bool? Active , bool? isRefProvider,bool? IsEmployee, int? Page, int? Size, string? SortColumn, string? SortOrder)
        {
            
            


            //FILE BASED
            NLogHelper.WriteLog(new LogParameter() { Message = "SearchUsers", ActionDetails = $"SearchUsers", ActionId = 1, ActionTime = DateTime.Now, FormName = "SearchUsers", ModuleName = "UserController.cs", UserName = "System", TablesReadOrModified = 0, UserLoginHistoryId = 17 }, (short)NLog.LogLevel.Info.Ordinal, $"SearchUsers > params  = { FullName}, {Gender}, {Phone},  {CellNo},  {JoiningDate},  {Email}, {EmployeeType}");



            DataSet result = await obj.SearchUserDB(FullName, Gender, Phone, CellNo, JoiningDate, Email, EmployeeType,Active, isRefProvider, IsEmployee, Page, Size, SortColumn, SortOrder);



            //FILE BASED
            NLogHelper.WriteLog(new LogParameter() { Message = "SearchUsers", ActionDetails = $"SearchUsers", ActionId = 1, ActionTime = DateTime.Now, FormName = "SearchUsers", ModuleName = "UserController.cs", UserName = "System", TablesReadOrModified = 0, UserLoginHistoryId = 17 }, (short)NLog.LogLevel.Info.Ordinal, $"SearchUsers > params  = {FullName}, {Gender}, {Phone},  {CellNo},  {JoiningDate},  {Email}, {EmployeeType}");


            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest(result);


        }

        [HttpPut("{UpdateByEmployeeId}")]
        public async Task<IActionResult> UpdateUsers(HREmployee hremp)
        {

            //FILE BASED
            NLogHelper.WriteLog(new LogParameter() { Message = "UpdateUsers", ActionDetails = $"UpdateUsers", ActionId = 1, ActionTime = DateTime.Now, FormName = "UpdateUsers", ModuleName = "UserController.cs", UserName = "System", TablesReadOrModified = 0, UserLoginHistoryId = 17 }, (short)NLog.LogLevel.Info.Ordinal, $"UpdateUsers > params  = {hremp.ToString()}");




            //long employeeId = Convert.ToInt64(User.Claims.Where(c => c.Type == "UserId")
            //                .First().Value);

            hremp.CreatedBy = User.Claims.Where(c => c.Type == "UserName").First().Value;

            foreach (var EmployeeFacility in hremp.EmployeeFacility)
            {
                EmployeeFacility.UpdatedBy = User.Claims.Where(c => c.Type == "UserName").First().Value;
            }

            foreach (var EmployeeRole in hremp.EmployeeRole)
            {
                EmployeeRole.UpdatedBy = User.Claims.Where(c => c.Type == "UserName").First().Value;
            }

            //foreach (var LicenseInfo in hremp.LicenseInfo)
            //{
            //    LicenseInfo.UpdatedB = User.Claims.Where(c => c.Type == "UserName").First().Value;
            //}
            // hremp.EmployeeId = employeeId;

            string result = await obj.UpdateUserDB(hremp);



            //FILE BASED
            NLogHelper.WriteLog(new LogParameter() { Message = "UpdateUsers", ActionDetails = $"UpdateUsers", ActionId = 1, ActionTime = DateTime.Now, FormName = "UpdateUsers", ModuleName = "UserController.cs", UserName = "System", TablesReadOrModified = 0, UserLoginHistoryId = 17 }, (short)NLog.LogLevel.Info.Ordinal, $"UpdateUsers > result  = {result}");


            if (result == "OK")
            {
                return Ok();
            }

            return BadRequest(result);

        }




        [HttpDelete("Delete/{EmployeeId}")]
        public async Task<IActionResult> Delete(long employeeId)
        {

            //FILE BASED
            NLogHelper.WriteLog(new LogParameter() { Message = "Delete", ActionDetails = $"Delete", ActionId = 1, ActionTime = DateTime.Now, FormName = "UpdateUsers", ModuleName = "UserController.cs", UserName = "System", TablesReadOrModified = 0, UserLoginHistoryId = 17 }, (short)NLog.LogLevel.Info.Ordinal, $"Delete > params  = {employeeId.ToString()}");



            bool result = await obj.Delete(employeeId);



            //FILE BASED
            NLogHelper.WriteLog(new LogParameter() { Message = "Delete", ActionDetails = $"Delete", ActionId = 1, ActionTime = DateTime.Now, FormName = "UpdateUsers", ModuleName = "UserController.cs", UserName = "System", TablesReadOrModified = 0, UserLoginHistoryId = 17 }, (short)NLog.LogLevel.Info.Ordinal, $"Delete > result  = {result}");


            if (result)
            {
                return Ok(new { Success=true});
            }

            return BadRequest(result);

        }




        [HttpDelete("DeleteLicense/{HRlicenseID}")]
        public async Task<IActionResult> DeleteLicense(long HRlicenseID)
        {

            //FILE BASED
            NLogHelper.WriteLog(new LogParameter() { Message = "DeleteLicense", ActionDetails = $"DeleteLicense", ActionId = 1, ActionTime = DateTime.Now, FormName = "UpdateUsers", ModuleName = "UserController.cs", UserName = "System", TablesReadOrModified = 0, UserLoginHistoryId = 17 }, (short)NLog.LogLevel.Info.Ordinal, $"DeleteLicense > params  = {HRlicenseID.ToString()}");



            bool result = await obj.DeleteLicense(HRlicenseID);



            //FILE BASED
            NLogHelper.WriteLog(new LogParameter() { Message = "DeleteLicense", ActionDetails = $"DeleteLicense", ActionId = 1, ActionTime = DateTime.Now, FormName = "UpdateUsers", ModuleName = "UserController.cs", UserName = "System", TablesReadOrModified = 0, UserLoginHistoryId = 17 }, (short)NLog.LogLevel.Info.Ordinal, $"DeleteLicense > result  = {result}");


            if (result)
            {
                return Ok(new { Success = true });
            }

            return BadRequest(result);

        }


    }
}

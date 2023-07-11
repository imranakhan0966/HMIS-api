using HMIS.Common.Logger;
using HMIS.Data.Entities.ControlPanel;
using HMIS.Data.Entities.Scheduling;
using HMIS.Services.ControlPanel;
using HMIS.Services.Scheduling;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HMIS.Controllers.Scheduling
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AppointmentController : ControllerBase
    {
        AppointmentManager obj = new AppointmentManager();



        [HttpGet("SearchAppointment")]
        public async Task<IActionResult> SearchAppointment(DateTime FromDate, DateTime ToDate, int? ProviderID, int? LocationID , int? SpecialityID , int? SiteID , int? FacilityID,  int? ReferredProviderId, long? PurposeOfVisitId, int? AppTypeId, int? VisitTypeId, string? LastUpdatedBy, [FromQuery(Name = "ids")] List<int> AppStatusId , int? Page   , int? Size )
        {


            //FILE BASED
            NLogHelper.WriteLog(new LogParameter() { Message = "SearchAppointmentControllerError", ActionDetails = $"SearchAppointment", ActionId = 1, ActionTime = DateTime.Now, FormName = "SearchAppointment", ModuleName = "AppointmentController.cs", UserName = "System", TablesReadOrModified = 0, UserLoginHistoryId = 17 }, (short)NLog.LogLevel.Info.Ordinal, $"SearchAppointment > param  = {FromDate},{ToDate}");


            DataSet result = await obj.SearchAppointmentDB(FromDate,ToDate,ProviderID,LocationID, SpecialityID,SiteID,FacilityID, ReferredProviderId, PurposeOfVisitId, AppTypeId, VisitTypeId, LastUpdatedBy, AppStatusId, Page,Size);



            //FILE BASED
            NLogHelper.WriteLog(new LogParameter() { Message = "GetTaskToDo", ActionDetails = $"GetTaskToDo", ActionId = 1, ActionTime = DateTime.Now, FormName = "GetUsersByID", ModuleName = "WelcomeController.cs", UserName = "System", TablesReadOrModified = 0, UserLoginHistoryId = 17 }, (short)NLog.LogLevel.Info.Ordinal, $"GetTaskToDoByParameters > data is empty?  = {result.Tables.Count == 0}");




            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("GetAppointmentDetailsByVisitAccountNo")]
        public async Task<IActionResult> GetAppointmentDetails(long VisitAccountNo)
        {
            //table1 = REG_GetUniquePatientOld
            DataSet result = await obj.GetAppointmentDetailsDB(VisitAccountNo);


            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }



        [HttpPost("InsertAppointment")]
        public async Task<IActionResult> InsertAppointment(SchAppointment schApp)
        {

            //FILE BASED
            NLogHelper.WriteLog(new LogParameter() { Message = "Insert Appointment", ActionDetails = $"InsertAppointment", ActionId = 1, ActionTime = DateTime.Now, FormName = "SchAppointment table", ModuleName = "AppointmentController.cs", UserName = "System", TablesReadOrModified = 0, UserLoginHistoryId = 17 }, (short)NLog.LogLevel.Info.Ordinal, $"Insert Appointment > object  = {schApp.ToString()}");




                   schApp.EnteredBy = User.Claims.Where(c => c.Type == "UserName").First().Value;

            DataSet result1 = await obj.ValidateAppointmentDB(schApp);
            if (result1.Tables[0].Rows.Count > 0)
            {
                string res = result1.Tables[0].Rows[0]["ErrorMessage"].ToString();
                if (res == "SUCCESS")
                {
                    var result = await obj.InsertAppointmentDB(schApp);


                    //FILE BASED
                    NLogHelper.WriteLog(new LogParameter() { Message = "Insert Appointment", ActionDetails = $"InsertAppointment", ActionId = 1, ActionTime = DateTime.Now, FormName = "SchAppointment table", ModuleName = "AppointmentController.cs", UserName = "System", TablesReadOrModified = 0, UserLoginHistoryId = 17 }, (short)NLog.LogLevel.Info.Ordinal, $"Insert Appointment > object  = {schApp.ToString()}");


                    if (result != null)
                    {
                        return Ok(result);
                    }
                    return BadRequest(result);


                }
                
               
            }
            return BadRequest(result1);

        }

            //DataSet result1 = await obj.ValidateAppointmentDB(schApp);
            //if (result1 == "success")
            //{
            //    var result = await obj.InsertAppointmentDB(schApp);


            //    //FILE BASED
            //    NLogHelper.WriteLog(new LogParameter() { Message = "Insert Appointment", ActionDetails = $"InsertAppointment", ActionId = 1, ActionTime = DateTime.Now, FormName = "SchAppointment table", ModuleName = "AppointmentController.cs", UserName = "System", TablesReadOrModified = 0, UserLoginHistoryId = 17 }, (short)NLog.LogLevel.Info.Ordinal, $"Insert Appointment > object  = {schApp.ToString()}");


            //    if (result != null)
            //    {
            //        return Ok(result);
            //    }

            //    return BadRequest(result);
            //}
           




        [HttpPut("UpdateByAppId")]
        public async Task<IActionResult> UpdateAppointment(SchAppointment schApp)
        {

            NLogHelper.WriteLog(new LogParameter() { Message = "Update Appointment", ActionDetails = $"UpdateAppointment", ActionId = 1, ActionTime = DateTime.Now, FormName = "SchAppointment table", ModuleName = "AppointmentController.cs", UserName = "System", TablesReadOrModified = 0, UserLoginHistoryId = 17 }, (short)NLog.LogLevel.Info.Ordinal, $"Update Appointment > object  = {schApp.ToString()}");

            var result = await obj.UpdateAppointmentDB(schApp);

            NLogHelper.WriteLog(new LogParameter() { Message = "Update Appointment", ActionDetails = $"UpdateAppointment", ActionId = 1, ActionTime = DateTime.Now, FormName = "SchAppointment table", ModuleName = "AppointmentController.cs", UserName = "System", TablesReadOrModified = 0, UserLoginHistoryId = 17 }, (short)NLog.LogLevel.Info.Ordinal, $"Update Appointment > object  = {schApp.ToString()}");

            if (result)
            {
                return Ok(new { Success = true });
            }

            return BadRequest(result);

        }



        [HttpGet("SearchAppointmentHistory")]
        public async Task<IActionResult> SearchAppointmentHistory(string MRNo, int? ProviderId, int? PatientStatusId, int? AppStatusId, int? Page, int? Size, string? SortColumn, string? SortOrder)
        {


            //FILE BASED
          //  NLogHelper.WriteLog(new LogParameter() { Message = "SearchAppointmentHistoryControllerError", ActionDetails = $"SearchAppointmentHistory", ActionId = 1, ActionTime = DateTime.Now, FormName = "SearchAppointmentHistory", ModuleName = "AppointmentController.cs", UserName = "System", TablesReadOrModified = 0, UserLoginHistoryId = 17 }(short)NLog.LogLevel.Info.Ordinal, $"SearchAppointmentHistory > params  = {MRNo}, {ProviderId}, {PatientStatusId},  {AppStatusId},  {Page},  {Size}, {SortColumn}, {SortOrder}");


            //FILE BASED
            NLogHelper.WriteLog(new LogParameter() { Message = "SearchUsers", ActionDetails = $"SearchUsers", ActionId = 1, ActionTime = DateTime.Now, FormName = "SearchUsers", ModuleName = "UserController.cs", UserName = "System", TablesReadOrModified = 0, UserLoginHistoryId = 17 }, (short)NLog.LogLevel.Info.Ordinal, $"SearchAppointmentHistory > params  = {MRNo}, {ProviderId}, {PatientStatusId},  {AppStatusId},  {Page},  {Size}, {SortColumn}, {SortOrder}");



            DataSet result = await obj.SearchAppointmentHistoryDB(MRNo, ProviderId, PatientStatusId, AppStatusId, Page, Size, SortColumn, SortOrder);


            //FILE BASED
            NLogHelper.WriteLog(new LogParameter() { Message = "SearchUsers", ActionDetails = $"SearchUsers", ActionId = 1, ActionTime = DateTime.Now, FormName = "SearchUsers", ModuleName = "UserController.cs", UserName = "System", TablesReadOrModified = 0, UserLoginHistoryId = 17 }, (short)NLog.LogLevel.Info.Ordinal, $"SearchAppointmentHistory > params  = {MRNo}, {ProviderId}, {PatientStatusId},  {AppStatusId},  {Page},  {Size}, {SortColumn}, {SortOrder}");


            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }




        [HttpGet("CancelOrRescheduleAppointment")]
        public async Task<IActionResult> CancelOrRescheduleAppointment(long AppId, int AppStatusId, bool ByProvider, int RescheduledId)
        {

            NLogHelper.WriteLog(new LogParameter() { Message = "CancelOrRescheduleAppointment", ActionDetails = $"CancelOrRescheduleAppointment", ActionId = 1, ActionTime = DateTime.Now, FormName = "SchAppointment table", ModuleName = "AppointmentController.cs", UserName = "System", TablesReadOrModified = 0, UserLoginHistoryId = 17 }, (short)NLog.LogLevel.Info.Ordinal, $"SearchAppointment > param  = {AppId},{RescheduledId}");

            var result = await obj.CancelOrRescheduleAppointmentDB(AppId, AppStatusId, ByProvider, RescheduledId);

            NLogHelper.WriteLog(new LogParameter() { Message = "CancelOrRescheduleAppointment", ActionDetails = $"CancelOrRescheduleAppointment", ActionId = 1, ActionTime = DateTime.Now, FormName = "SchAppointment table", ModuleName = "AppointmentController.cs", UserName = "System", TablesReadOrModified = 0, UserLoginHistoryId = 17 }, (short)NLog.LogLevel.Info.Ordinal, $"SearchAppointment > param  = {AppId},{RescheduledId}");
            if (result)
            {
                return Ok(new { Success = true });
            }

            return BadRequest(result);

        }


        //[HttpGet("ValidateAppointmentOnHoliday")]
        //public async Task<IActionResult> ValidateAppointmentOnHoliday(DateTime AppointmentDate,int SiteID)
        //{


        //    // result = await obj.ValidateAppointmentOnHolidayDB(AppointmentDate,SiteID);

        //    if (result != null)
        //    {
        //        return Ok(result);
        //    }

        //    return BadRequest(result);

        //}


    }
}

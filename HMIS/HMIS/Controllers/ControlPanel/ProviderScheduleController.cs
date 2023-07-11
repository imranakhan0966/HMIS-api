using HMIS.Data.Entities.ControlPanel;
using HMIS.Services.ControlPanel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Policy;

namespace HMIS.Controllers.ControlPanel
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProviderScheduleController : ControllerBase
    {
        ProviderScheduleManager obj = new ProviderScheduleManager();


        [HttpGet("GetProviderScheduleList")]
        public async Task<IActionResult> GetProviderScheduleList(long? ProviderId, int? SiteId, int? FacilityId, int? UsageId, bool? Sunday, bool? Monday, bool? Tuesday, bool? Wednesday, bool? Thursday, bool? Friday, bool? Saturday, string? StartTime, string? EndTime)
        {

            DataSet result = await obj.GetProviderScheduleListDB(ProviderId, SiteId, FacilityId, UsageId, Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, StartTime, EndTime);


            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("GetProviderScheduleByProviderId")]
        public async Task<IActionResult> GetProviderSchedule(long ProviderId, int SiteId, int FacilityId, int UsageId)
        {
            
            DataSet result = await obj.GetProviderScheduleDB(ProviderId, SiteId, FacilityId, UsageId);


            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("GetProviderScheduleByPSId")]
        public async Task<IActionResult> GetProviderSingleSchedule(long PSId)
        {

            DataSet result = await obj.GetProviderSingleScheduleDB(PSId);


            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("GetProviderFacilityByProviderId")]
        public async Task<IActionResult> GetProviderFacility(long ProviderId)
        {

            DataSet result = await obj.GetProviderFacilityDB(ProviderId);


            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("GetProviderSiteByFacilityId")]
        public async Task<IActionResult> GetProviderSite(int FacilityId)
        {

            DataSet result = await obj.GetProviderSiteDB(FacilityId);


            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("InsertProviderSchedule")]
        public async Task<IActionResult> InsertProviderSchedule(ProviderSchedule PS)
        {
            PS.CreatedBy = User.Claims.Where(c => c.Type == "UserName").First().Value;

            var result = await obj.InsertProviderScheduleDB(PS);

            if (result)
            {
                return Ok(new { Success = true });
            }

            return BadRequest(result);
        }

        [HttpPut("UpdateProviderScheduleByPSId")]
        public async Task<IActionResult> UpdateProviderSchedule(ProviderSchedule PS)
        {
            PS.UpdatedBy = User.Claims.Where(c => c.Type == "UserName").First().Value;

            var result = await obj.UpdateProviderScheduleDB(PS);

            if (result)
            {
                return Ok(new { Success = true });
            }

            return BadRequest(result);
        }

        [HttpDelete("DeleteProviderSchedule/{PSId}")]
        public async Task<IActionResult> Delete(long PSId)
        {

            bool result = await obj.DeleteProviderSchedule(PSId);

            if (result)
            {
                return Ok(new { Success = true });
            }

            return BadRequest(result);

        }
    }
}

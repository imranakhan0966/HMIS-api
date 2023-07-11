using HMIS.Data.Entities.ControlPanel;
using HMIS.Services.ControlPanel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Xml.Linq;
using System.Security.Policy;

namespace HMIS.Controllers.ControlPanel
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HolidayScheduleController : ControllerBase
    {
        HolidayScheduleManager obj = new HolidayScheduleManager();

        [HttpGet("GetHolidaySchedule")]
        public async Task<IActionResult> HolidaySchedule()
        {

            DataSet result = await obj.GetHolidayScheduleDB();
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("InsertHolidaySchedule")]
        public async Task<IActionResult> InsertProviderSchedule(bool? IsHoliday, string? HolidayName, string? Comments, int? SiteID, string? Years, string? MonthDay, string? StartingTime, string? EndingTime, bool? IsActive)
        {
         string CreatedBy = User.Claims.Where(c => c.Type == "UserName").First().Value;

            var result = await obj.InsertHolidayScheduleDB( IsHoliday,  HolidayName,  Comments,  SiteID,  Years,  MonthDay,  StartingTime,  EndingTime, IsActive,  CreatedBy);

            if (result)
            {
                return Ok(new { Success = true });
            }

            return BadRequest(result);
        }


        [HttpPut("UpdateHolidayScheduleByHSId")]
        public async Task<IActionResult> UpdateHolidaySchedule(long HolidayScheduleId,bool? IsHoliday,string? HolidayName,string? Comments,int? SiteID,string? Years,string? MonthDay,string? StartingTime,string? EndingTime,bool? IsActive)
        {
          string  UpdateBy = User.Claims.Where(c => c.Type == "UserName").First().Value;

            var result = await obj.UpdateHolidayScheduleDB(HolidayScheduleId,  IsHoliday,  HolidayName,  Comments,  SiteID,  Years,  MonthDay,  StartingTime,  EndingTime,  IsActive,  UpdateBy);

            if (result)
            {
                return Ok(new { Success = true });
            }

            return BadRequest(result);
        }

    }
}

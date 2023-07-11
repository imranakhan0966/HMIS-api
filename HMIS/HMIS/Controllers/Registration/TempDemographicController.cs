using Microsoft.AspNetCore.Mvc;
using HMIS.Data.Entities.ControlPanel;
using HMIS.Data.Entities.Registration;
using HMIS.Services.Registration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Data;
using System.Drawing;
namespace HMIS.Controllers.Registration
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TempDemographicController : ControllerBase
    {
       TempDemographicManager obj = new TempDemographicManager();

        [HttpGet("GetTempDemographics")]
        public async Task<IActionResult> TempDemographics(long? TempId, string? Name, string? Address, int? PersonEthnicityTypeId, string? Mobile, string? DOB, string? Gender, int? Country, int? State, int? City, string? ZipCode, int? InsuredId, int? CarrierId)
        {

            DataSet result = await obj.TempDemoDB(TempId, Name, Address, PersonEthnicityTypeId, Mobile, DOB, Gender, Country, State, City, ZipCode, InsuredId, CarrierId);


            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpPost("InsertTempPatientRecord")]
        public async Task<IActionResult> InsertTempDemographic(RegTempPatient regTempInsert)
        {
            regTempInsert.CreatedBy = User.Claims.Where(c => c.Type == "UserName").First().Value;

            var result = await obj.InsertTempDemoDB(regTempInsert);

            if (result)
            {
                return Ok(new { Success = true });
            }

            return BadRequest(result);
        }

        [HttpPut("UpdateTempPatientRecord")]
        public async Task<IActionResult> UpdateTempDemographic(RegTempPatient regTempUpdate)
        {
            regTempUpdate.UpdatedBy = User.Claims.Where(c => c.Type == "UserName").First().Value;

            var result = await obj.UpdateTempDemoDB(regTempUpdate);

            if (result)
            {
                return Ok(new { Success = true });
            }

            return BadRequest(result);
        }


    }
}

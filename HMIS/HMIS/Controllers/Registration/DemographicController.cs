using HMIS.Data.Entities.ControlPanel;
using HMIS.Data.Entities.Registration;
using HMIS.Services.Registration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Drawing;

namespace HMIS.Controllers.Registration
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class DemographicController : ControllerBase
    {
        DemographicManager obj = new DemographicManager();

        [HttpGet("GetDemographics")]
        public async Task<IActionResult> GetDemoByMRNo(string MRNo)
        {
            //table1 = [REG_InsuredCoverageGet] , table2 = [REG_GetUniquePatient] , table3=[REG_PatientGetEmployer] , table4=[REG_GetUniqueAssignments] ,table5= [REG_GetPatientFamilyMembers]
            DataSet result = await obj.GetDemoByMRNoDB(MRNo);

            //1554
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("GetPatientHistory")]
        public async Task<IActionResult> GetPatientHistoryByMRNo(string MRNo)
        {
            //table1 = REG_GetUniquePatientOld
            DataSet result = await obj.GetHistoryByMRNoDB(MRNo);


            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

    



        [HttpPost("InsertPatientRecord")]
        public async Task<IActionResult> InsertDemographic(RegInsert regInsert)
        {
             regInsert.UpdatedBy = User.Claims.Where(c => c.Type == "UserName").First().Value;

            var result = await obj.InsertDemographicDB(regInsert);

            if (result)
            {
                return Ok(new { Success = true });
            }

            return BadRequest(result);
        }

        [HttpPut("UpdatePatientRecordByMRNo")]
        public async Task<IActionResult> UpdateDemographic(RegInsert regUpdate)
        {
            regUpdate.UpdatedBy = User.Claims.Where(c => c.Type == "UserName").First().Value;

            var result = await obj.UpdateDemographicDB(regUpdate);

            if (result)
            {
                return Ok(new { Success = true });
            }

            return BadRequest(result);
        }


    }
}

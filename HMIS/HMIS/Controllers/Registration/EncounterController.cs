
using Azure.Core;
using HMIS.Common;
using HMIS.Common.BindingModels.Common;
using HMIS.Common.BindingModels.Scheduling;
using HMIS.Services.Common;
using HMIS.Services.Registration;
using HMISData.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Drawing.Printing;
using System.Text.Json.Nodes;

namespace HMIS.Controllers.Registration
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]

    public class EncounterController : ControllerBase
    {
        EncounterManager obj = new EncounterManager();

        [HttpGet("GetEncountersByMRNo")]
        public async Task<IActionResult> GetEncounterByMRNo(string MRNo, int? PageNumber, int? PageSize)
        {
            //table1 = REG_GetUniquePatientOld
            DataSet result = await obj.GetEncounterByMRNoDB(MRNo, PageNumber, PageSize);


            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}

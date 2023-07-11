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
using System.Text.Json.Nodes;

namespace HMIS.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

        public class CommonController : ControllerBase
    {
        CommonManager obj = new CommonManager();

        [HttpGet("GetPatientFamily")]
        public async Task<IActionResult> GetPatientFamilyByMRNo(string MRNo)
        {
            

            DataSet result = await obj.GetFamilyByMRNoDB(MRNo);


            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("GetCoverageAndRegPatient")]
        public async Task<IActionResult> GetCoverageAndRegPatient(string MRNo="")
        {
            //table1 = REG_GetUniquePatientOld
            
            MRNo = MRNo=="-1"?string.Empty:MRNo; 
            DataSet result = await obj.GetCoverageAndRegPatientDB(MRNo);


            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }




        [HttpGet("GetInsurrancePayerInfo")]
        public async Task<IActionResult> GetInsurrancePayerInfo(long MRNo)
        {
            //table1 = REG_GetUniquePatientOld

            DataSet result = await obj.GetInsurrancePayerInfo(MRNo);


            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }







        [HttpGet]

        [Route("GetEmployeeFacilityFromCache")]
        public IActionResult GetEmployeeFacilityFromCache()
        {
            List<HrEmployeeFacility> filtered = new List<HrEmployeeFacility>();

            Dictionary<string, JArray> cache = CacheHelper.Instance.ReadInMemoryCache(new List<string>() { "hremployeefacility" });
           long userId =  Convert.ToInt64(User.Claims.Where(c => c.Type == "UserId").First().Value);
            if (cache.Count>0)
            {
                //EmployeeId = 


                foreach (KeyValuePair<string, JArray> entry in cache)
                {

                    filtered = entry.Value.ToObject<List<HrEmployeeFacility>>();
                }

                if (filtered.Count>0)
                {
                    filtered = filtered.Where(a => a.EmployeeId == userId).ToList();

                }

                return Ok(new { cache = JsonConvert.SerializeObject(filtered) });
                


                //filter cache

            }

            return Ok(new { });
        }
    }
}

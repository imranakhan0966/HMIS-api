using Microsoft.AspNetCore.Mvc;
using HMIS.Data.Entities.ControlPanel;
using HMIS.Data.Entities.Registration;
using HMIS.Services.Registration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.Intrinsics.X86;
using HMIS.Data.Entities.Registration.Coverage;

namespace HMIS.Controllers.Registration
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CoveragesController : ControllerBase
    {
        CoveragesManager obj = new CoveragesManager();

        [HttpGet("GetSearch")]
        public async Task<IActionResult> GetSearch(Byte? CompanyOrIndividual, string? LastName, string? SSN, string? InsuredIDNo, string? MRNo, int PageNumber, int PageSize)
        {
            
            if (string.IsNullOrEmpty(MRNo))
            {
                MRNo = null; 
            }

            //if (DateTime.)
            //{
            //    MRNo = null;
            //}

            DataSet result = await obj.GetSearchDB(CompanyOrIndividual, LastName, SSN, InsuredIDNo, MRNo, PageNumber, PageSize);

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("BLEligibilityLogs")]
        public async Task<IActionResult> GetBLEligibilityLogs(string? MRNo, long? VisitAccountNo, int? EligibilityId, int? ELStatusId, string? MessageRequestDate, string? MessageResponseDate)
        {

            //if (string.IsNullOrEmpty(MRNo))
            //{
            //    MRNo = null;
            //}

            DataSet result = await obj.GetBLEligibilityLogsDB(MRNo, VisitAccountNo, EligibilityId, ELStatusId, MessageRequestDate, MessageResponseDate);

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("GetSubscriberDatails{InsuredIDNo}")]
        public async Task<IActionResult> GetSubcriberDetails(string InsuredIDNo)
        {
            DataSet result = await obj.GetSubcriberDetailsDB(InsuredIDNo);


            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpGet("GetCoverage{MRNo}")]
        public async Task<IActionResult> GetCoverageDB(string MRNo)
        {
            DataSet result = await obj.GetCoverageDB(MRNo);


            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpPost("InsertSubscriber")]
        public async Task<IActionResult> InsertSubscriber(InsuranceSubscriber regInsert)
        {
            // regInsert.EnteredBy = User.Claims.Where(c => c.Type == "UserName").First().Value;

            var result = await obj.InsertSubscriberDB(regInsert);

            if (result == "OK")
            {
                return Ok(new { Success = true });
            }


            return BadRequest(result);
        }

        [HttpPost("GetImageData")]
        public async Task<IActionResult> GetImageData([FromForm] InsuranceCardModel insuranceCardModel)
        {
            try
            {
                long PayerId = insuranceCardModel.PayerId;


                var result = await obj.ReadImage(insuranceCardModel.image, PayerId);

                return Ok(result);

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPut("UpdateSubscriber")]
        public async Task<IActionResult> UpdateSubscriber(InsuranceSubscriber regUpdate)
        {
            // regInsert.EnteredBy = User.Claims.Where(c => c.Type == "UserName").First().Value;

            var result = await obj.UpdateSubscriberDB(regUpdate);

            if (result == "OK")
            {
                return Ok(new { Success = true });
            }
        

            return BadRequest(result);



        }
    }
    }

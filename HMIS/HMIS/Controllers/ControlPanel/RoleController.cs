using HMIS.Data.Entities.ControlPanel;
using HMIS.Services.ControlPanel;
using HMISData.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HMIS.Controllers.ControlPanel
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoleController : ControllerBase
    {
        
        RoleManager obj = new RoleManager();
        [HttpPost]
        public async Task<IActionResult> InsertRoles(SecRole secrole)
        {
            secrole.CreatedBy = User.Claims.Where(c => c.Type == "UserName").First().Value;

            foreach (var secPrivilege in secrole.SecPrivilegesAssignedRoleList)
            {
                secPrivilege.CreatedBy = User.Claims.Where(c => c.Type == "UserName").First().Value;
            }

            foreach (var secroleformlist in secrole.SecRoleFormList)
            {
                secroleformlist.CreatedBy = User.Claims.Where(c => c.Type == "UserName").First().Value;
            }



            var result = await obj.InsertRoleDB(secrole);

            if (result)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("{RoleId}")]
        public async Task<IActionResult> GetRoleByID(long RoleId)
        {


            DataSet result = await obj.GetRoleByIDDB(RoleId);


            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet]
        public async Task<IActionResult> SearchRole(string? RoleName, bool? IsActive, int? Page, int? Size, string? SortColumn, string? SortOrder)
        {
            DataSet result = await obj.SearchRoleDB(RoleName, IsActive,Page, Size, SortColumn, SortOrder);

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest(result);


        }

        [HttpPut("{UpdateByRoleId}")]
        public async Task<IActionResult> UpdateRole(SecRole secrole)
        {

            secrole.CreatedBy = User.Claims.Where(c => c.Type == "UserName").First().Value;

            foreach (var secPrivilege in secrole.SecPrivilegesAssignedRoleList)
            {
                secPrivilege.UpdatedBy = User.Claims.Where(c => c.Type == "UserName").First().Value;
            }

            foreach (var secroleformlist in secrole.SecRoleFormList)
            {
                secroleformlist.UpdatedBy = User.Claims.Where(c => c.Type == "UserName").First().Value;
            }
            var result = await obj.UpdateRoleDB(secrole);

            if (result)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }



        [HttpGet("GetPermissionTree")]
        public async Task<IActionResult> GetPermissionTree()
        {
            try
            {
                long employeeId = Convert.ToInt64(User.Claims.Where(c => c.Type == "UserId")
                   .First().Value);


                string userName = User.Claims.Where(c => c.Type == "UserName").First().Value;



                var permissionsTree = await PermissionService.GetPermissionTreeByEmpIdandUserId(employeeId, userName);
                string treeJsons = "";
                if (permissionsTree != null)
                {
                    if (permissionsTree.Count > 0)
                    {
                        treeJsons = Newtonsoft.Json.JsonConvert.SerializeObject(permissionsTree);
                    }
                }

                return Ok(new { Success = true, Tree = treeJsons });
            }
            catch (Exception ex)
            {

                throw;
            }



        }


    }
}

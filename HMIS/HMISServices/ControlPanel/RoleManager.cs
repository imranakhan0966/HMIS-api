using Dapper;
using HMIS.Common.BindingModels.ControlPanel;
using HMIS.Common.ORM;
using HMIS.Data.Entities.ControlPanel;
using HMISCommon.Helpers;
using HMISData.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMIS.Services.ControlPanel
{
    public class RoleManager
    {
        public async Task<bool> InsertRoleDB(SecRole secrole)
        {
            try

            {
                DataTable SecRoleFormDT = ConversionHelper.ToDataTable(secrole.SecRoleFormList);

                DataTable SecPrivilegesAssignedRoleDT = ConversionHelper.ToDataTable(secrole.SecPrivilegesAssignedRoleList);

                SecRole role = new SecRole();

                role = secrole;

                DynamicParameters parameters = new DynamicParameters();


                parameters.Add("@RoleName", role.RoleName, DbType.String);

                parameters.Add("@IsActive", role.IsActive, DbType.Boolean);

                parameters.Add("@CreatedBy", role.CreatedBy, DbType.String);

                parameters.Add("@SecRoleFormTypeVar", SecRoleFormDT, DbType.Object);

                parameters.Add("@SecPrivilegesAssignedRoleTypeVar", SecPrivilegesAssignedRoleDT, DbType.Object);


                bool res = await DapperHelper.ExcecuteSPByParams("CP_InsertRole", parameters);

                
                    return res;
                
         
            

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<DataSet> GetRoleByIDDB(long RoleId)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@RoleId", RoleId, DbType.Int64);

                DataSet ds = await DapperHelper.GetDataSetBySPWithParams("CP_GetRoleById", parameters);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    return new DataSet();
                }

                return ds;
            }
            catch (Exception ex)
            {
                return new DataSet();
            }
        }

        public async Task<DataSet> SearchRoleDB(string? RoleName, bool? IsActive, int? Page=1, int? Size=100, string? SortColumn="RoleId", string? SortOrder = "ASC")
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@RoleName", RoleName, DbType.String);

                param.Add("@IsActive", IsActive, DbType.Boolean);
                param.Add("@IsActive",IsActive, DbType.Boolean);
                param.Add("@Page", Page, DbType.Int64);
                param.Add("@Size", Size, DbType.Int64);
                param.Add("@SortColumn", SortColumn, DbType.String);
                param.Add("@SortOrder", SortOrder, DbType.String);


                DataSet ds = await DapperHelper.GetDataSetBySPWithParams("CP_SearchRole", param);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return new DataSet();
                }

                return ds;
            }
            catch (Exception ex)
            {
                return new DataSet();
            }

        }

        public async Task<bool> UpdateRoleDB(SecRole secrole)
        {
  
            DataTable SecRoleFormDT = ConversionHelper.ToDataTable(secrole.SecRoleFormList);

            DataTable SecPrivilegesAssignedRoleDT = ConversionHelper.ToDataTable(secrole.SecPrivilegesAssignedRoleList);
            try
            {
                HREmployee EMP = new HREmployee();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@RoleId", secrole.RoleId, DbType.Int64);

                parameters.Add("@RoleName", secrole.RoleName, DbType.String);

                parameters.Add("@IsActive", secrole.IsActive, DbType.Boolean);

                parameters.Add("@UpdatedBy", secrole.UpdatedBy, DbType.String);

                parameters.Add("@SecRoleFormTypeVar", SecRoleFormDT, DbType.Object);

                parameters.Add("@SecPrivilegesAssignedRoleTypeVar", SecPrivilegesAssignedRoleDT, DbType.Object);

                bool res = await DapperHelper.ExcecuteSPByParams("CP_UpdateRole", parameters);

                if (res == true)
                {
                    return true;
                }

                    return false;
            }
            catch (Exception ex)
            {
                return false;
            
            }




        }




    }



}

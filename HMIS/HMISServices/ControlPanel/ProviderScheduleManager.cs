using Dapper;
using HMIS.Common.ORM;
using HMIS.Data.Entities.ControlPanel;
using HMIS.Data.Entities.Registration;
using HMISCommon.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMIS.Services.ControlPanel
{
    public class ProviderScheduleManager
    {
        
        public async Task<DataSet> GetProviderFacilityDB(long ProviderId)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();

                param.Add("@ProviderId", ProviderId, DbType.Int64);
                
                DataSet ds = await DapperHelper.GetDataSetBySPWithParams("CP_ProviderFacilityDetailsGet", param);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    throw new Exception("No data found");
                }

                return ds;
            }
            catch (Exception ex)
            {
                return new DataSet();
            }

        }

        public async Task<DataSet> GetProviderSiteDB(int FacilityId)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();

                param.Add("@FacilityId", FacilityId, DbType.Int64);

                DataSet ds = await DapperHelper.GetDataSetBySPWithParams("CP_SiteByFacilityIdGet", param);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    throw new Exception("No data found");
                }

                return ds;
            }
            catch (Exception ex)
            {
                return new DataSet();
            }

        }

        public async Task<DataSet> GetProviderScheduleListDB(long? ProviderId, int? SiteId, int? FacilityId, int? UsageId, bool? Sunday, bool? Monday, bool? Tuesday, bool? Wednesday, bool? Thursday, bool? Friday, bool? Saturday, string? StartTime, string? EndTime)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();

                param.Add("@ProviderId", ProviderId.HasValue ? ProviderId.Value : -1, DbType.Int64);
                param.Add("@SiteId", SiteId.HasValue ? SiteId.Value : -1, DbType.Int32);
                param.Add("@FacilityId", FacilityId.HasValue ? FacilityId.Value : -1, DbType.Int32);
                param.Add("@UsageId", UsageId.HasValue ? UsageId.Value : -1, DbType.Int32);
                param.Add("@Sunday", Sunday, DbType.Boolean);
                param.Add("@Monday", Monday, DbType.Boolean);
                param.Add("@Tuesday", Tuesday, DbType.Boolean);
                param.Add("@Wednesday", Wednesday, DbType.Boolean);
                param.Add("@Thursday", Thursday, DbType.Boolean);
                param.Add("@Friday", Friday, DbType.Boolean);
                param.Add("@Saturday", Saturday, DbType.Boolean);
                param.Add("@StartTime", string.IsNullOrEmpty(StartTime) ? null : StartTime, DbType.String);
                param.Add("@EndTime", string.IsNullOrEmpty(EndTime) ? null : EndTime, DbType.String);

                DataSet ds = await DapperHelper.GetDataSetBySPWithParams("CP_ProviderScheduleListGet", param);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    throw new Exception("No data found");
                }

                return ds;
            }
            catch (Exception ex)
            {
                return new DataSet();
            }
        }

        public async Task<DataSet> GetProviderScheduleDB(long ProviderId, int SiteId, int FacilityId, int UsageId)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();

                param.Add("@ProviderId", ProviderId, DbType.Int64);
                param.Add("@SiteId", SiteId, DbType.Int32);
                param.Add("@FacilityId", FacilityId, DbType.Int32);
                param.Add("@UsageId", UsageId, DbType.Int32);
                param.Add("@PSIdOut", SqlDbType.VarChar, (DbType?)ParameterDirection.Output);


                DataSet ds = await DapperHelper.GetDataSetBySPWithParams("CP_ProviderScheduleGet", param);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    throw new Exception("No data found");
                }

                return ds;
            }
            catch (Exception ex)
            {
                return new DataSet();
            }

        }

        public async Task<DataSet> GetProviderSingleScheduleDB(long PSId)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();

                param.Add("@PSId", PSId, DbType.Int64);
                
                DataSet ds = await DapperHelper.GetDataSetBySPWithParams("CP_ProviderSingleScheduleGet", param);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    throw new Exception("No data found");
                }

                return ds;
            }
            catch (Exception ex)
            {
                return new DataSet();
            }

        }

        public async Task<bool> InsertProviderScheduleDB(ProviderSchedule ps)
        {
            try

            {
                DataTable ProviderScheduleByAppTypeDT = ConversionHelper.ToDataTable(ps.providerScheduleByAppType);

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@PSId", SqlDbType.BigInt, (DbType?)ParameterDirection.Output);
                parameters.Add("@ProviderId", ps.ProviderId, DbType.Int64);
                parameters.Add("@SiteId", ps.SiteId, DbType.Int32);
                parameters.Add("@UsageId", ps.UsageId, DbType.Int32);
                parameters.Add("@StartTime", ps.StartTime, DbType.String);//mr1 mrs 0 
                parameters.Add("@EndTime", ps.EndTime, DbType.String);//0
                parameters.Add("@StartDate", ps.StartDate, DbType.DateTime);
                parameters.Add("@EndDate", ps.EndDate, DbType.DateTime);
                parameters.Add("@BreakStartTime", ps.BreakStartTime, DbType.String);
                parameters.Add("@BreakEndTime", ps.BreakEndTime, DbType.String);
                parameters.Add("@BreakReason", ps.BreakReason, DbType.String);
                parameters.Add("@AppPerHour", ps.AppPerHour, DbType.Int16);
                parameters.Add("@MaxOverloadApps", ps.MaxOverloadApps, DbType.Int16);//contact
                parameters.Add("@Priority", ps.Priority, DbType.Int32);
                parameters.Add("@Active", ps.Active, DbType.Boolean);
                parameters.Add("@CreatedBy", ps.CreatedBy, DbType.String);
                parameters.Add("@Sunday", ps.Sunday, DbType.Boolean);
                parameters.Add("@Monday", ps.Monday, DbType.Boolean);
                parameters.Add("@Tuesday", ps.Tuesday, DbType.Boolean);
                parameters.Add("@Wednesday", ps.Wednesday, DbType.Boolean);
                parameters.Add("@Thursday", ps.Thursday, DbType.Boolean);
                parameters.Add("@Friday", ps.Friday, DbType.Boolean);
                parameters.Add("@Saturday", ps.Saturday, DbType.Boolean);
                parameters.Add("@ProviderScheduleByAppTypeVar", ProviderScheduleByAppTypeDT, DbType.Object);


                bool res = await DapperHelper.ExcecuteSPByParams("CP_ProviderScheduleInsert", parameters);


                return res;




            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<bool> UpdateProviderScheduleDB(ProviderSchedule ps)
        {
            try

            {
                DataTable ProviderScheduleByAppTypeDT = ConversionHelper.ToDataTable(ps.providerScheduleByAppType);


                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@PSId", ps.PSId, DbType.Int64);
                parameters.Add("@ProviderId", ps.ProviderId, DbType.Int64);
                parameters.Add("@SiteId", ps.SiteId, DbType.Int32);
                parameters.Add("@UsageId", ps.UsageId, DbType.Int32);
                parameters.Add("@StartTime", ps.StartTime, DbType.String);//mr1 mrs 0 
                parameters.Add("@EndTime", ps.EndTime, DbType.String);//0
                parameters.Add("@StartDate", ps.StartDate, DbType.DateTime);
                parameters.Add("@EndDate", ps.EndDate, DbType.DateTime);
                parameters.Add("@BreakStartTime", ps.BreakStartTime, DbType.String);
                parameters.Add("@BreakEndTime", ps.BreakEndTime, DbType.String);
                parameters.Add("@BreakReason", ps.BreakReason, DbType.String);
                parameters.Add("@AppPerHour", ps.AppPerHour, DbType.Int16);
                parameters.Add("@MaxOverloadApps", ps.MaxOverloadApps, DbType.Int16);//contact
                parameters.Add("@Priority", ps.Priority, DbType.Int32);
                parameters.Add("@Active", ps.Active, DbType.Boolean);
                parameters.Add("@UpdatedBy", ps.UpdatedBy, DbType.String);
                parameters.Add("@Sunday", ps.Sunday, DbType.Boolean);
                parameters.Add("@Monday", ps.Monday, DbType.Boolean);
                parameters.Add("@Tuesday", ps.Tuesday, DbType.Boolean);
                parameters.Add("@Wednesday", ps.Wednesday, DbType.Boolean);
                parameters.Add("@Thursday", ps.Thursday, DbType.Boolean);
                parameters.Add("@Friday", ps.Friday, DbType.Boolean);
                parameters.Add("@Saturday", ps.Saturday, DbType.Boolean);
                parameters.Add("@ProviderScheduleByAppTypeVar", ProviderScheduleByAppTypeDT, DbType.Object);

                bool res = await DapperHelper.ExcecuteSPByParams("CP_ProviderScheduleUpdate", parameters);

                return res;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<bool> DeleteProviderSchedule(long PSId)
        {
            DynamicParameters param = new DynamicParameters();

            try
            {
                param.Add("@PSId", PSId, DbType.Int64);



                bool result = await DapperHelper.ExcecuteSPByParams("CP_ProviderScheduleDelete", param);

                return result;
            }
            catch (Exception ex)
            {

                return false;
            }


        }

    }
}

using Dapper;
using HMIS.Common.ORM;
using HMIS.Data.Entities.ControlPanel;
using HMISCommon.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMIS.Services.ControlPanel
{
    public class HolidayScheduleManager
    {
        public async Task<DataSet> GetHolidayScheduleDB()
        {
            try
            {
                DynamicParameters param = new DynamicParameters();

                

                DataSet ds = await DapperHelper.GetDataSetBySPWithParams("CP_HolidayScheduleGet", param);
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

        public async Task<bool> InsertHolidayScheduleDB(bool? IsHoliday, string? HolidayName, string? Comments, int? SiteID, string? Years, string? MonthDay, string? StartingTime, string? EndingTime, bool? IsActive, string? CreatedBy)
        {
            try

            {

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@IsHoliday", IsHoliday);
                parameters.Add("@HolidayName", HolidayName);
                parameters.Add("@Comments", Comments);
                parameters.Add("@SiteID", SiteID);
                parameters.Add("@Years", Years);
                parameters.Add("@MonthDay", MonthDay);
                parameters.Add("@StartingTime", StartingTime);
                parameters.Add("@EndingTime", EndingTime);
                parameters.Add("@IsActive", IsActive);
                parameters.Add("@CreatedBy", CreatedBy);

                bool res = await DapperHelper.ExcecuteSPByParams("CP_HolidayScheduleInsert", parameters);


                return res;




            }
            catch (Exception ex)
            {
                return false;
            }

        }


        public async Task<bool> UpdateHolidayScheduleDB(long HolidayScheduleId, bool? IsHoliday, string? HolidayName, string? Comments, int? SiteID, string? Years, string? MonthDay, string? StartingTime, string? EndingTime, bool? IsActive, string? UpdateBy)
        {
            try

            {

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@HolidayScheduleId", HolidayScheduleId);
                parameters.Add("@IsHoliday", IsHoliday);
                parameters.Add("@HolidayName", HolidayName);
                parameters.Add("@Comments", Comments);
                parameters.Add("@SiteID", SiteID);
                parameters.Add("@Years", Years);
                parameters.Add("@MonthDay", MonthDay);
                parameters.Add("@StartingTime", StartingTime);
                parameters.Add("@EndingTime", EndingTime);
                parameters.Add("@IsActive", IsActive);
                parameters.Add("@UpdateBy", UpdateBy);
                

                bool res = await DapperHelper.ExcecuteSPByParams("CP_HolidayScheduleUpdate", parameters);

                return res;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}

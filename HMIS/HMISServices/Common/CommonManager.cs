using Dapper;
using HMIS.Common.ORM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMIS.Services.Common
{
    public class CommonManager
    {

        public async Task<DataSet> GetFamilyByMRNoDB(string MRNo)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@MRNo", MRNo, DbType.String);

                DataSet ds = await DapperHelper.GetDataSetBySPWithParams("REG_GetPatientFamilyMembers", param);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    throw new Exception("No data found");
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DataSet> GetCoverageAndRegPatientDB(string MRNo)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@MRNo", MRNo, DbType.String);

                DataSet ds = await DapperHelper.GetDataSetBySPWithParams("Common_CoverageAndRegPatientGet", param);
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



        public async Task<DataSet> GetInsurrancePayerInfo(long  MRNo)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@MRNo", MRNo, DbType.Int64);

                DataSet ds = await DapperHelper.GetDataSetBySPWithParams("SCH_GETPAYERINFOBYMR", param);
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

    }
}

using Dapper;
using HMIS.Common.ORM;
using HMIS.Data.Entities.Registration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HMIS.Services.Registration
{
    public class TempDemographicManager
    {
        public async Task<DataSet> TempDemoDB(long? TempId, string? Name, string? Address, int? PersonEthnicityTypeId, string? Mobile, string? DOB, string? Gender, int? Country, int? State, int? City, string? ZipCode, int? InsuredId, int? CarrierId)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@TempId", TempId, DbType.Int64);

                param.Add("@Name", Name, DbType.String);

                param.Add("@Address", Address, DbType.String);

                param.Add("@PersonEthnicityTypeId", PersonEthnicityTypeId, DbType.Int32);

                param.Add("@Mobile", Mobile, DbType.String);

                param.Add("@DOB", DOB, DbType.String);

                param.Add("@Gender", Gender, DbType.String);

                param.Add("@Country", Country, DbType.Int32);

                param.Add("@State", State, DbType.Int32);

                param.Add("@City", City, DbType.Int32);

                param.Add("@ZipCode", ZipCode, DbType.String);

                param.Add("@InsuredId", InsuredId, DbType.Int32);

                param.Add("@CarrierId", CarrierId, DbType.Int32);




                DataSet ds = await DapperHelper.GetDataSetBySPWithParams("REG_GetTempDemographic", param);
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

        public async Task<bool> InsertTempDemoDB(RegTempPatient reg)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                
                parameters.Add("@PersonTitleId", reg.PersonTitleId, DbType.Byte);
                parameters.Add("@PersonNationalityId", reg.PersonNationalityId, DbType.Int32);
                parameters.Add("@PersonFirstName", reg.PersonFirstName, DbType.String);
                parameters.Add("@PersonMiddleName", reg.PersonMiddleName, DbType.String);
                parameters.Add("@PersonLastName", reg.PersonLastName, DbType.String);
                parameters.Add("@PersonSex", reg.PersonSex, DbType.String);
                parameters.Add("@PersonCellPhone", reg.PersonCellPhone, DbType.String);
                parameters.Add("@PersonAddress1", reg.PersonAddress1, DbType.String);
                parameters.Add("@PersonAddress2", reg.PersonAddress2, DbType.String);
                parameters.Add("@PersonCountryId", reg.PersonCountryId, DbType.Int32);
                parameters.Add("@PersonStateId", reg.PersonStateId, DbType.Int32);
                parameters.Add("@PersonCityId", reg.PersonCityId, DbType.Int32);
                parameters.Add("@PersonZipCode", reg.PersonZipCode, DbType.String);
                parameters.Add("@PersonHomePhone1", reg.PersonHomePhone1, DbType.String);
                parameters.Add("@PersonWorkPhone1", reg.PersonWorkPhone1, DbType.String);
                parameters.Add("@PersonEmail", reg.PersonEmail, DbType.String);
                parameters.Add("@NOKFirstName", reg.NOKFirstName, DbType.String);
                parameters.Add("@NOKMiddleName", reg.NOKMiddleName, DbType.String);
                parameters.Add("@NOKLastName", reg.NOKLastName, DbType.String);
                parameters.Add("@NOKRelationshipId", reg.NOKRelationshipId, DbType.Byte);
                parameters.Add("@NOKHomePhone", reg.NOKHomePhone, DbType.String);
                parameters.Add("@NOKWorkPhone", reg.NOKWorkPhone, DbType.String);
                parameters.Add("@NOKCellNo", reg.NOKCellNo, DbType.String);
                parameters.Add("@NOKSocialSecurityNo", reg.NOKSocialSecurityNo, DbType.String);
                parameters.Add("@NOKAddress1", reg.NOKAddress1, DbType.String);
                parameters.Add("@NOKAddress2", reg.NOKAddress2, DbType.String);
                parameters.Add("@NOKCountryId", reg.NOKCountryId, DbType.Int32);
                parameters.Add("@NOKStateId", reg.NOKStateId, DbType.Int32);
                parameters.Add("@NOKCityId", reg.NOKCityId, DbType.Int32);
                parameters.Add("@NOKZipCode", reg.NOKZipCode, DbType.String);
                parameters.Add("@Comments", reg.Comments, DbType.String);
                parameters.Add("@CreatedBy", reg.CreatedBy, DbType.String);
                parameters.Add("@UpdatedBy", reg.UpdatedBy, DbType.String);
                parameters.Add("@Active", reg.Active, DbType.Boolean);
                parameters.Add("@PatientBirthDate", reg.PatientBirthDate, DbType.DateTime);



                bool res = await DapperHelper.ExcecuteSPByParams("REG_InsertTempDemographic", parameters);
                return res;


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<bool> UpdateTempDemoDB(RegTempPatient reg)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@TempId", reg.TempId, DbType.Int64);
                parameters.Add("@PersonTitleId", reg.PersonTitleId, DbType.Byte);
                parameters.Add("@PersonNationalityId", reg.PersonNationalityId, DbType.Int32);
                parameters.Add("@PersonFirstName", reg.PersonFirstName, DbType.String);
                parameters.Add("@PersonMiddleName", reg.PersonMiddleName, DbType.String);
                parameters.Add("@PersonLastName", reg.PersonLastName, DbType.String);
                parameters.Add("@PersonSex", reg.PersonSex, DbType.String);
                parameters.Add("@PersonCellPhone", reg.PersonCellPhone, DbType.String);
                parameters.Add("@PersonAddress1", reg.PersonAddress1, DbType.String);
                parameters.Add("@PersonAddress2", reg.PersonAddress2, DbType.String);
                parameters.Add("@PersonCountryId", reg.PersonCountryId, DbType.Int32);
                parameters.Add("@PersonStateId", reg.PersonStateId, DbType.Int32);
                parameters.Add("@PersonCityId", reg.PersonCityId, DbType.Int32);
                parameters.Add("@PersonZipCode", reg.PersonZipCode, DbType.String);
                parameters.Add("@PersonHomePhone1", reg.PersonHomePhone1, DbType.String);
                parameters.Add("@PersonWorkPhone1", reg.PersonWorkPhone1, DbType.String);
                parameters.Add("@PersonEmail", reg.PersonEmail, DbType.String);
                parameters.Add("@NOKFirstName", reg.NOKFirstName, DbType.String);
                parameters.Add("@NOKMiddleName", reg.NOKMiddleName, DbType.String);
                parameters.Add("@NOKLastName", reg.NOKLastName, DbType.String);
                parameters.Add("@NOKRelationshipId", reg.NOKRelationshipId, DbType.Byte);
                parameters.Add("@NOKHomePhone", reg.NOKHomePhone, DbType.String);
                parameters.Add("@NOKWorkPhone", reg.NOKWorkPhone, DbType.String);
                parameters.Add("@NOKCellNo", reg.NOKCellNo, DbType.String);
                parameters.Add("@NOKSocialSecurityNo", reg.NOKSocialSecurityNo, DbType.String);
                parameters.Add("@NOKAddress1", reg.NOKAddress1, DbType.String);
                parameters.Add("@NOKAddress2", reg.NOKAddress2, DbType.String);
                parameters.Add("@NOKCountryId", reg.NOKCountryId, DbType.Int32);
                parameters.Add("@NOKStateId", reg.NOKStateId, DbType.Int32);
                parameters.Add("@NOKCityId", reg.NOKCityId, DbType.Int32);
                parameters.Add("@NOKZipCode", reg.NOKZipCode, DbType.String);
                parameters.Add("@Comments", reg.Comments, DbType.String);
                parameters.Add("@CreatedBy", reg.CreatedBy, DbType.String);
                parameters.Add("@UpdatedBy", reg.UpdatedBy, DbType.String);
                parameters.Add("@Active", reg.Active, DbType.Boolean);
                parameters.Add("@PatientBirthDate", reg.PatientBirthDate, DbType.DateTime);



                bool res = await DapperHelper.ExcecuteSPByParams("REG_UpdateTempDemographic", parameters);
                return res;


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}

using Dapper;
using HMIS.Common.ORM;
using HMIS.Data.Entities.ControlPanel;
using HMIS.Data.Entities.Registration;
using HMISCommon.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HMIS.Services.Registration
{
    public class DemographicManager
    {

        public async Task<DataSet> GetDemoByMRNoDB(string MRNo)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@MRNo", MRNo, DbType.String);

                DataSet ds = await DapperHelper.GetDataSetBySPWithParams("REG_GetDemographic", param);
                if (ds.Tables[0].Rows.Count == 0)
                {

                    return new DataSet();
//                    throw new Exception("No data found");
                }

                return ds;
            }
            catch (Exception ex)
            {
                return new DataSet();
            }
        }

        public async Task<DataSet> GetHistoryByMRNoDB(string MRNo)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@MRNo", MRNo, DbType.String);

                DataSet ds = await DapperHelper.GetDataSetBySPWithParams("REG_GetUniquePatientOld", param);
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

      

        public async Task<bool> UpdateDemographicDB(RegInsert regUpdate)
        {
            try

            {
                DataTable RegPatientEmployerDT = ConversionHelper.ToDataTable(regUpdate.regPatientEmployer);

                DataTable RegAccountDT = ConversionHelper.ToDataTable(regUpdate.regAccount);

                DataTable RegAssignmentDT = ConversionHelper.ToDataTable(regUpdate.regAssignments);

                RegInsert reg = new RegInsert();

                reg = regUpdate;

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@MRno", reg.MRno, DbType.String);
                parameters.Add("@PersonFirstName", reg.PersonFirstName, DbType.String);
                parameters.Add("@PersonMiddleName", reg.PersonMiddleName, DbType.String);
                parameters.Add("@PersonLastName", reg.PersonLastName, DbType.String);
                parameters.Add("@PersonTitleId", reg.PersonTitleId, DbType.Int32);
                parameters.Add("@PersonSocialSecurityNo", reg.PersonSocialSecurityNo, DbType.String);
                parameters.Add("@VIPPatient", reg.VIPPatient, DbType.Boolean);
                parameters.Add("@PersonSex", reg.PersonSex, DbType.String);
                parameters.Add("@PersonMaritalStatus", reg.PersonMaritalStatus, DbType.Int32);
                parameters.Add("@PersonEthnicityTypeId", reg.PersonEthnicityTypeId, DbType.Int32);
                parameters.Add("@PatientBirthDate", reg.PatientBirthDate, DbType.DateTime);
                parameters.Add("@PersonDriversLicenseNo", reg.PersonDriversLicenseNo, DbType.String);
                parameters.Add("@PersonAddress1", reg.PersonAddress1, DbType.String);
                parameters.Add("@PersonAddress2", reg.PersonAddress2, DbType.String);
                parameters.Add("@PersonZipCode", reg.PersonZipCode, DbType.String);
                parameters.Add("@PersonCityId", reg.PersonCityId, DbType.Int32);
                parameters.Add("@PersonStateId", reg.PersonStateId, DbType.Int32);
                parameters.Add("@PersonCountryId", reg.PersonCountryId, DbType.Int32);
                parameters.Add("@PersonHomePhone1", reg.PersonHomePhone1, DbType.String);
                parameters.Add("@PersonCellPhone", reg.PersonCellPhone, DbType.String);
                parameters.Add("@PersonWorkPhone1", reg.PersonWorkPhone1, DbType.String);
                parameters.Add("@PersonFax", reg.PersonFax, DbType.String);
                parameters.Add("@PersonEmail", reg.PersonEmail, DbType.String);
                parameters.Add("@PatientBloodGroupId", reg.PatientBloodGroupId, DbType.Int32);
                parameters.Add("@PatientPicture", reg.PatientPicture, DbType.Binary);
                parameters.Add("@ParentType", reg.ParentType, DbType.Boolean);
                parameters.Add("@ParentFirstName", reg.ParentFirstName, DbType.String);
                parameters.Add("@ParentMiddleName", reg.ParentMiddleName, DbType.String);
                parameters.Add("@ParentLastName", reg.ParentLastName, DbType.String);
                parameters.Add("@FatherHomePhone", reg.FatherHomePhone, DbType.String);
                parameters.Add("@FatherCellPhone", reg.FatherCellPhone, DbType.String);
                parameters.Add("@FatherEmailAddress", reg.FatherEmailAddress, DbType.String);
                parameters.Add("@MotherFirstName", reg.MotherFirstName, DbType.String);
                parameters.Add("@MotherMiddleName", reg.MotherMiddleName, DbType.String);
                parameters.Add("@MotherLastName", reg.MotherLastName, DbType.String);
                parameters.Add("@MotherHomePhone", reg.MotherHomePhone, DbType.String);
                parameters.Add("@MotherCellPhone", reg.MotherCellPhone, DbType.String);
                parameters.Add("@MotherEmailAddress", reg.MotherEmailAddress, DbType.String);
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
                parameters.Add("@NOKZipCode", reg.NOKZipCode, DbType.String);
                parameters.Add("@NOKCityId", reg.NOKCityId, DbType.Int32);
                parameters.Add("@NOKStateId", reg.NOKStateId, DbType.Int32);
                parameters.Add("@NOKCountryId", reg.NOKCountryId, DbType.Int32);
                parameters.Add("@SpouseFirstName", reg.SpouseFirstName, DbType.String);
                parameters.Add("@SpouseMiddleName", reg.SpouseMiddleName, DbType.String);
                parameters.Add("@SpouseLastName", reg.SpouseLastName, DbType.String);
                parameters.Add("@SpouseSex", reg.SpouseSex, DbType.String);
                parameters.Add("@EContactFirstName", reg.EContactFirstName, DbType.String);
                parameters.Add("@EContactMiddleName", reg.EContactMiddleName, DbType.String);
                parameters.Add("@EContactLastName", reg.EContactLastName, DbType.String);
                parameters.Add("@EContactRelationship", reg.EContactRelationship, DbType.String);
                parameters.Add("@EContactHomePhone", reg.EContactHomePhone, DbType.String);
                parameters.Add("@EContactWorkPhone", reg.EContactWorkPhone, DbType.String);
                parameters.Add("@EContactCellPhone", reg.EContactCellPhone, DbType.String);
                parameters.Add("@EContactSocialSecurityNo", reg.EContactSocialSecurityNo, DbType.String);
                parameters.Add("@EContactAddress1", reg.EContactAddress1, DbType.String);
                parameters.Add("@EContactAddress2", reg.EContactAddress2, DbType.String);
                parameters.Add("@EContactZipCode", reg.EContactZipCode, DbType.String);
                parameters.Add("@EContactCityId", reg.EContactCityId, DbType.Int32);
                parameters.Add("@EContactStateId", reg.EContactStateId, DbType.Int32);
                parameters.Add("@EContactCountryId", reg.EContactCountryId, DbType.Int32);
                parameters.Add("@SignedDate", reg.SignedDate, DbType.DateTime);
                parameters.Add("@ExpiryDate", reg.ExpiryDate, DbType.DateTime);
                parameters.Add("@IsNewPatient", reg.IsNewPatient, DbType.Boolean);
                parameters.Add("@UpdatedBy", reg.UpdatedBy, DbType.String);
                parameters.Add("@PassportNo", reg.PassportNo, DbType.String);
                parameters.Add("@PersonTempAddress1", reg.PersonTempAddress1, DbType.String);
                parameters.Add("@PersonTempAddress2", reg.PersonTempAddress2, DbType.String);
                parameters.Add("@PersonTempZipCode", reg.PersonTempZipCode, DbType.String);
                parameters.Add("@PersonTempCityId", reg.PersonTempCityId, DbType.Int32);
                parameters.Add("@PersonTempStateId", reg.PersonTempStateId, DbType.Int32);
                parameters.Add("@PersonTempCountryId", reg.PersonTempCountryId, DbType.Int32);
                parameters.Add("@PersonTempWorkPhone", reg.PersonTempWorkPhone, DbType.String);
                parameters.Add("@PersonTempCellPhone", reg.PersonTempCellPhone, DbType.String);
                parameters.Add("@PersonTempFax", reg.PersonTempFax, DbType.String);
                parameters.Add("@PersonTempHomePhone", reg.PersonTempHomePhone, DbType.String);
                parameters.Add("@PersonOtherAddress1", reg.PersonOtherAddress1, DbType.String);
                parameters.Add("@PersonOtherAddress2", reg.PersonOtherAddress2, DbType.String);
                parameters.Add("@PersonOtherZipCode", reg.PersonOtherZipCode, DbType.String);
                parameters.Add("@PersonOtherCityId", reg.PersonOtherCityId, DbType.Int32);
                parameters.Add("@PersonOtherStateId", reg.PersonOtherStateId, DbType.Int32);
                parameters.Add("@PersonOtherCountryId", reg.PersonOtherCountryId, DbType.Int32);
                parameters.Add("@PersonOtherHomePhone", reg.PersonOtherHomePhone, DbType.String);
                parameters.Add("@PersonOtherCellPhone", reg.PersonOtherCellPhone, DbType.String);
                parameters.Add("@PersonOtherWorkPhone", reg.PersonOtherWorkPhone, DbType.String);
                parameters.Add("@PersonOtherFax", reg.PersonOtherFax, DbType.String);
                parameters.Add("@ResidenceVisaNo", reg.ResidenceVisaNo, DbType.String);
                parameters.Add("@LaborCardNo", reg.LaborCardNo, DbType.String);
                parameters.Add("@Religion", reg.Religion, DbType.Int32);
                parameters.Add("@PrimaryLanguage", reg.PrimaryLanguage, DbType.Int32);
                parameters.Add("@Nationality", reg.Nationality, DbType.Int32);
                parameters.Add("@EMPI", reg.EMPI, DbType.String);
                parameters.Add("@IsReport", reg.IsReport, DbType.Boolean);
                parameters.Add("@MediaChannelId", reg.MediaChannelId, DbType.Int64);
                parameters.Add("@MediaItemId", reg.MediaItemId, DbType.Int64);
                parameters.Add("@TempId", reg.TempId, DbType.Int64);
                parameters.Add("@EmiratesIDN", reg.EmiratesIDN, DbType.String);
                parameters.Add("@FacilityName", reg.FacilityName, DbType.String);
                parameters.Add("@PersonNameArabic", reg.PersonNameArabic, DbType.String);
               
                parameters.Add("@RegPatientEmployerTypeVar", RegPatientEmployerDT, DbType.Object);

                parameters.Add("@RegAccountTypeVar", RegAccountDT, DbType.Object);

                parameters.Add("@RegAssignmentTypeVar", RegAssignmentDT, DbType.Object);


                bool res = await DapperHelper.ExcecuteSPByParams("REG_UpdateDemographic", parameters);


                return res;




            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<bool> InsertDemographicDB(RegInsert regInsert)
        {
            try

            {
                DataTable RegPatientEmployerDT = ConversionHelper.ToDataTable(regInsert.regPatientEmployer);

                DataTable RegAccountDT = ConversionHelper.ToDataTable(regInsert.regAccount);

                DataTable RegAssignmentDT = ConversionHelper.ToDataTable(regInsert.regAssignments);

                RegInsert reg = new RegInsert();

                reg = regInsert;

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@MRNo", SqlDbType.VarChar, (DbType?)ParameterDirection.Output);
                parameters.Add("@PersonFirstName", reg.PersonFirstName, DbType.String);
                parameters.Add("@PersonMiddleName", reg.PersonMiddleName, DbType.String);
                parameters.Add("@PersonLastName", reg.PersonLastName, DbType.String);
                parameters.Add("@PersonTitleId", reg.PersonTitleId, DbType.Int32);//mr1 mrs 0 
                parameters.Add("@PersonSocialSecurityNo", reg.PersonSocialSecurityNo, DbType.String);//0
                parameters.Add("@VIPPatient", reg.VIPPatient, DbType.Boolean);
                parameters.Add("@PersonSex", reg.PersonSex, DbType.String);
                parameters.Add("@PersonMaritalStatus", reg.PersonMaritalStatus, DbType.Int32);
                parameters.Add("@PersonEthnicityTypeId", reg.PersonEthnicityTypeId, DbType.Int32);
                parameters.Add("@PatientBirthDate", reg.PatientBirthDate, DbType.DateTime);
                parameters.Add("@PersonDriversLicenseNo", reg.PersonDriversLicenseNo, DbType.String);
                parameters.Add("@PersonAddress1", reg.PersonAddress1, DbType.String);//contact
                parameters.Add("@PersonAddress2", reg.PersonAddress2, DbType.String);
                parameters.Add("@PersonZipCode", reg.PersonZipCode, DbType.String);
                parameters.Add("@PersonCityId", reg.PersonCityId, DbType.Int32);
                parameters.Add("@PersonStateId", reg.PersonStateId, DbType.Int32);
                parameters.Add("@PersonCountryId", reg.PersonCountryId, DbType.Int32);
                parameters.Add("@PersonHomePhone1", reg.PersonHomePhone1, DbType.String);//contact
                parameters.Add("@PersonCellPhone", reg.PersonCellPhone, DbType.String);
                parameters.Add("@PersonWorkPhone1", reg.PersonWorkPhone1, DbType.String);
                parameters.Add("@PersonFax", reg.PersonFax, DbType.String);//contact
                parameters.Add("@PersonEmail", reg.PersonEmail, DbType.String);//contact
                parameters.Add("@PatientBloodGroupId", reg.PatientBloodGroupId, DbType.Int32);
                parameters.Add("@PatientPicture", reg.PatientPicture, DbType.Binary);
                parameters.Add("@ParentType", reg.ParentType, DbType.Boolean);
                parameters.Add("@ParentFirstName", reg.ParentFirstName, DbType.String);
                parameters.Add("@ParentMiddleName", reg.ParentMiddleName, DbType.String);
                parameters.Add("@ParentLastName", reg.ParentLastName, DbType.String);

                parameters.Add("@FatherHomePhone", reg.FatherHomePhone, DbType.String);//family member
                parameters.Add("@FatherCellPhone", reg.FatherCellPhone, DbType.String);
                parameters.Add("@FatherEmailAddress", reg.FatherEmailAddress, DbType.String);
                parameters.Add("@MotherFirstName", reg.MotherFirstName, DbType.String);
                parameters.Add("@MotherMiddleName", reg.MotherMiddleName, DbType.String);
                parameters.Add("@MotherLastName", reg.MotherLastName, DbType.String);
                parameters.Add("@MotherHomePhone", reg.MotherHomePhone, DbType.String);
                parameters.Add("@MotherCellPhone", reg.MotherCellPhone, DbType.String);
                parameters.Add("@MotherEmailAddress", reg.MotherEmailAddress, DbType.String);
                //Relatives
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
                parameters.Add("@NOKZipCode", reg.NOKZipCode, DbType.String);
                parameters.Add("@NOKCityId", reg.NOKCityId, DbType.Int32);
                parameters.Add("@NOKStateId", reg.NOKStateId, DbType.Int32);
                parameters.Add("@NOKCountryId", reg.NOKCountryId, DbType.Int32);

                parameters.Add("@SpouseFirstName", reg.SpouseFirstName, DbType.String);
                parameters.Add("@SpouseMiddleName", reg.SpouseMiddleName, DbType.String);
                parameters.Add("@SpouseLastName", reg.SpouseLastName, DbType.String);
                parameters.Add("@SpouseSex", reg.SpouseSex, DbType.String);
                //Emergency
                parameters.Add("@EContactFirstName", reg.EContactFirstName, DbType.String);
                parameters.Add("@EContactMiddleName", reg.EContactMiddleName, DbType.String);
                parameters.Add("@EContactLastName", reg.EContactLastName, DbType.String);
                parameters.Add("@EContactRelationship", reg.EContactRelationship, DbType.String);
                parameters.Add("@EContactHomePhone", reg.EContactHomePhone, DbType.String);
                parameters.Add("@EContactWorkPhone", reg.EContactWorkPhone, DbType.String);
                parameters.Add("@EContactCellPhone", reg.EContactCellPhone, DbType.String);
                parameters.Add("@EContactSocialSecurityNo", reg.EContactSocialSecurityNo, DbType.String);
                parameters.Add("@EContactAddress1", reg.EContactAddress1, DbType.String);
                parameters.Add("@EContactAddress2", reg.EContactAddress2, DbType.String);
                parameters.Add("@EContactZipCode", reg.EContactZipCode, DbType.String);
                parameters.Add("@EContactCityId", reg.EContactCityId, DbType.Int32);
                parameters.Add("@EContactStateId", reg.EContactStateId, DbType.Int32);
                parameters.Add("@EContactCountryId", reg.EContactCountryId, DbType.Int32);
                parameters.Add("@SignedDate", reg.SignedDate, DbType.DateTime);
                parameters.Add("@ExpiryDate", reg.ExpiryDate, DbType.DateTime);

                parameters.Add("@IsNewPatient", reg.IsNewPatient, DbType.Boolean);
                parameters.Add("@UpdatedBy", reg.UpdatedBy, DbType.String);
                parameters.Add("@PassportNo", reg.PassportNo, DbType.String);
                parameters.Add("@PersonTempAddress1", reg.PersonTempAddress1, DbType.String);
                parameters.Add("@PersonTempAddress2", reg.PersonTempAddress2, DbType.String);
                parameters.Add("@PersonTempZipCode", reg.PersonTempZipCode, DbType.String);
                parameters.Add("@PersonTempCityId", reg.PersonTempCityId, DbType.Int32);
                parameters.Add("@PersonTempStateId", reg.PersonTempStateId, DbType.Int32);
                parameters.Add("@PersonTempCountryId", reg.PersonTempCountryId, DbType.Int32);
                parameters.Add("@PersonTempWorkPhone", reg.PersonTempWorkPhone, DbType.String);
                parameters.Add("@PersonTempCellPhone", reg.PersonTempCellPhone, DbType.String);
                parameters.Add("@PersonTempFax", reg.PersonTempFax, DbType.String);
                parameters.Add("@PersonTempHomePhone", reg.PersonTempHomePhone, DbType.String);
                parameters.Add("@PersonOtherAddress1", reg.PersonOtherAddress1, DbType.String);
                parameters.Add("@PersonOtherAddress2", reg.PersonOtherAddress2, DbType.String);
                parameters.Add("@PersonOtherZipCode", reg.PersonOtherZipCode, DbType.String);
                parameters.Add("@PersonOtherCityId", reg.PersonOtherCityId, DbType.Int32);
                parameters.Add("@PersonOtherStateId", reg.PersonOtherStateId, DbType.Int32);
                parameters.Add("@PersonOtherCountryId", reg.PersonOtherCountryId, DbType.Int32);
                parameters.Add("@PersonOtherHomePhone", reg.PersonOtherHomePhone, DbType.String);
                parameters.Add("@PersonOtherCellPhone", reg.PersonOtherCellPhone, DbType.String);
                parameters.Add("@PersonOtherWorkPhone", reg.PersonOtherWorkPhone, DbType.String);
                parameters.Add("@PersonOtherFax", reg.PersonOtherFax, DbType.String);
                parameters.Add("@ResidenceVisaNo", reg.ResidenceVisaNo, DbType.String);
                parameters.Add("@LaborCardNo", reg.LaborCardNo, DbType.String);
                parameters.Add("@Religion", reg.Religion, DbType.Int32);
                parameters.Add("@PrimaryLanguage", reg.PrimaryLanguage, DbType.Int32);
                parameters.Add("@Nationality", reg.Nationality, DbType.Int32);
                parameters.Add("@EMPI", reg.EMPI, DbType.String);
                parameters.Add("@IsReport", reg.IsReport, DbType.Boolean);
                parameters.Add("@MediaChannelId", reg.MediaChannelId, DbType.Int64);
                parameters.Add("@MediaItemId", reg.MediaItemId, DbType.Int64);
                parameters.Add("@TempId", reg.TempId, DbType.Int64);
                parameters.Add("@EmiratesIDN", reg.EmiratesIDN, DbType.String);
                parameters.Add("@FacilityName", reg.FacilityName, DbType.String);
                parameters.Add("@PersonNameArabic", reg.PersonNameArabic, DbType.String);

                parameters.Add("@RegPatientEmployerTypeVar", RegPatientEmployerDT, DbType.Object);

                parameters.Add("@RegAccountTypeVar", RegAccountDT, DbType.Object);

                parameters.Add("@RegAssignmentTypeVar", RegAssignmentDT, DbType.Object);


                bool res = await DapperHelper.ExcecuteSPByParams("REG_InsertDemographic", parameters);


                return res;




            }
            catch (Exception ex)
            {
                return false;
            }

        }

       


    }
}

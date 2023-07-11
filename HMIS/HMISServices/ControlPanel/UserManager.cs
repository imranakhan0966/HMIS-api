using Dapper;
using HMIS.Common;
using HMIS.Common.BindingModels.ControlPanel;
using HMIS.Common.Helpers;
using HMIS.Common.ORM;
using HMIS.Data.Entities.ControlPanel;
using HMISCommon.Helpers;
using HMISData.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HMISServices.ControlPanel
{
    public class UserManager
    {


        public async Task<bool> InsertLicense(HRLicenseInfo license)
        {
            try
            {

            
                DataTable empLicense = ConversionHelper.ObjectToData(license);


                DynamicParameters parameters = new DynamicParameters();


                parameters.Add("@HRLicenseInfoTypeVar", empLicense, DbType.Object);

                
                bool res = await DapperHelper.ExcecuteSPByParams("CP_InsertHRLicense", parameters);

                if (res)
                {
                    return res;
                }
            }
            catch (Exception ex)
            {

                return false;
            
            }

            return false;
        }

            public async Task<bool> InsertUserDB(HREmployee hremployee)
        {

            try
            {


               
                HashingHelper hashHelper = HashingHelper.GetInstance();

                string pwdHash = hashHelper.ComputeHash(hremployee.Password);
                hremployee.Password = pwdHash;



                DataTable EmployeeFacilityDT = ConversionHelper.ToDataTable(hremployee.EmployeeFacility!=null? hremployee.EmployeeFacility:new List<HREmployeeFacility>());

                DataTable LicenseInfoDT = ConversionHelper.ToDataTable(hremployee.LicenseInfo != null ? hremployee.LicenseInfo:new List<HRLicenseInfo>());

                DataTable SecEmployeeRoleDT = ConversionHelper.ToDataTable(hremployee.EmployeeRole != null ?hremployee.EmployeeRole:new List<SecEmployeeRole>());


                HREmployee EMP = new HREmployee();
                EMP = hremployee;


                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("EmployeeType", EMP.EmployeeType, DbType.Int64);

                parameters.Add("Prefix", EMP.Prefix, DbType.String);

                parameters.Add("FullName", EMP.FullName, DbType.String);

                parameters.Add("ArFullName", EMP.ArFullName, DbType.String);

                parameters.Add("IsEmployee", EMP.IsEmployee, DbType.Boolean);

                parameters.Add("Credential", EMP.Credential, DbType.String);

                parameters.Add("Nic", EMP.Nic, DbType.String);

                parameters.Add("CityID", EMP.CityID, DbType.Int64);

                parameters.Add("CountryID", EMP.CountryID, DbType.Int64);

                parameters.Add("StateID", EMP.StateID, DbType.String);

                parameters.Add("ZipCode", EMP.ZipCode, DbType.String);

                parameters.Add("CellNo", EMP.CellNo, DbType.String);

                parameters.Add("Phone", EMP.Phone, DbType.String);

                parameters.Add("Email", EMP.Email, DbType.String);

                parameters.Add("Fax", EMP.Fax, DbType.String);

                parameters.Add("DriversLicenseNo", EMP.DriversLicenseNo, DbType.String);

                parameters.Add("DOB", EMP.DOB, DbType.DateTime);

                parameters.Add("Gender", EMP.Gender, DbType.String);

                parameters.Add("BloodGroup", EMP.BloodGroup, DbType.String);

                parameters.Add("MaritalStatus", EMP.MaritalStatus, DbType.String);

                parameters.Add("Active", EMP.Active, DbType.Boolean);

                parameters.Add("UserName", EMP.UserName, DbType.String);

                parameters.Add("Password", EMP.Password, DbType.String);

                parameters.Add("HomeAddress1", EMP.HomeAddress1, DbType.String);

                parameters.Add("HomeAddress2", EMP.HomeAddress2, DbType.String);

                parameters.Add("IsAdmin", EMP.IsAdmin, DbType.Boolean);

                parameters.Add("HomePager", EMP.HomePager, DbType.String);

                parameters.Add("EmerRelationship", EMP.EmerRelationship, DbType.String);

                parameters.Add("EmerFullName", EMP.EmerFullName, DbType.String);

                parameters.Add("EmerAddress1", EMP.EmerAddress1, DbType.String);

                parameters.Add("EmerAddress2", EMP.EmerAddress2, DbType.String);

                parameters.Add("EmerCountryId", EMP.EmerCountryId, DbType.Int64);

                parameters.Add("EmerStateId", EMP.EmerStateId, DbType.Int64);

                parameters.Add("EmerCityId", EMP.EmerCityId, DbType.Int64);

                parameters.Add("EmerZipCode", EMP.EmerZipCode, DbType.String);

                parameters.Add("EmerEmail", EMP.EmerEmail, DbType.String);

                parameters.Add("EmerPhone", EMP.EmerPhone, DbType.String);

                parameters.Add("EmerCellPhone", EMP.EmerCellPhone, DbType.String);

                parameters.Add("EmerPager", EMP.EmerPager, DbType.String);

                parameters.Add("EmerFax", EMP.EmerFax, DbType.String);

                parameters.Add("UserPicture", EMP.UserPicture, DbType.Binary);

                parameters.Add("ProvRemAddress2", EMP.ProvRemAddress2, DbType.String);

                parameters.Add("ProvStateLicNo", EMP.ProvStateLicNo, DbType.String);

                parameters.Add("ProvDeaNo", EMP.ProvDeaNo, DbType.String);

                parameters.Add("ProvCtrlSubsNo", EMP.ProvCtrlSubsNo, DbType.String);

                parameters.Add("ProvUpin", EMP.ProvUpin, DbType.String);

                parameters.Add("ProvTaxonomy", EMP.ProvTaxonomy, DbType.String);

                parameters.Add("IsPerson", EMP.IsPerson, DbType.String);

                parameters.Add("IsRefProvider", EMP.IsRefProvider, DbType.Boolean);

                parameters.Add("PasswordResetByAdmin", EMP.PasswordResetByAdmin, DbType.Boolean);

                parameters.Add("PasswordUpdatedDate", EMP.PasswordUpdatedDate, DbType.DateTime);

                parameters.Add("ProvNPI", EMP.ProvNPI, DbType.String);

                parameters.Add("Initials", EMP.Initials, DbType.String);

                parameters.Add("DHCCCode", EMP.DHCCCode, DbType.String);

                parameters.Add("ProviderSPID", EMP.ProviderSPID, DbType.Int64);

                parameters.Add("VIPPatientAccess", EMP.VIPPatientAccess, DbType.Boolean);

                parameters.Add("JoiningDate", EMP.JoiningDate, DbType.DateTime);

                parameters.Add("AllowChgCap", EMP.AllowChgCap, DbType.Boolean);

                parameters.Add("ErxUserName", EMP.ErxUserName, DbType.String);

                parameters.Add("ErxPass", EMP.ErxPass, DbType.String);

                parameters.Add("HaadLicType", EMP.HaadLicType, DbType.String);

                parameters.Add("DrCashPrice", EMP.DrCashPrice, DbType.String);

                parameters.Add("GrantAccessToMalaffi", EMP.GrantAccessToMalaffi, DbType.Boolean);

                parameters.Add("MalaffiRoleLevel", EMP.MalaffiRoleLevel, DbType.Int64);

                parameters.Add("EnableMBR", EMP.EnableMBR, DbType.Boolean);

                parameters.Add("SignatureImage", EMP.SignatureImage, DbType.Binary);

                parameters.Add("CreatedBy", EMP.CreatedBy, DbType.String);

                parameters.Add("UpdatedBy", EMP.UpdatedBy, DbType.String);

                parameters.Add("PassPortNo", EMP.PassPortNo, DbType.String);

                parameters.Add("BusAddress1", EMP.BusAddress1, DbType.String);

                parameters.Add("BusAddress2", EMP.BusAddress2, DbType.String);

                parameters.Add("BusCountryId", EMP.BusCountryId, DbType.Int64);

                parameters.Add("BusCityId", EMP.BusCityId, DbType.Int64);

                parameters.Add("BusStateId", EMP.BusStateId, DbType.Int64);

                parameters.Add("BusZipCode", EMP.BusZipCode, DbType.String);

                parameters.Add("BusEmail", EMP.BusEmail, DbType.String);

                parameters.Add("BusPhone", EMP.BusPhone, DbType.String);

                parameters.Add("BusCellPhone", EMP.BusCellPhone, DbType.String);

                parameters.Add("BusPager", EMP.BusPager, DbType.String);

                parameters.Add("BusFax", EMP.BusFax, DbType.String);

                parameters.Add("@HREmployeeFacilityTypeVar", EmployeeFacilityDT, DbType.Object);

                parameters.Add("@HRLicenseInfoTypeVar", LicenseInfoDT, DbType.Object);

                parameters.Add("@SecEmployeeRoleTypeVar", SecEmployeeRoleDT, DbType.Object);


                bool res = await DapperHelper.ExcecuteSPByParams("CP_InsertHREmployee", parameters);

                if (res)
                {
                    return res;
                }
            }
            catch (Exception ex)
            {

                return false;
            }


              return false;
        }


        public async Task<DataSet> GetUserByIDDB(long EmployeeId)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", EmployeeId, DbType.Int64);

                DataSet ds = await DapperHelper.GetDataSetBySPWithParams("CP_GetHREmployeeById", parameters);


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



        public async Task<DataSet> SearchUserDB(string? FullName, string? Gender, string? Phone, string? CellNo, DateTime? JoiningDate, string? Email, int? EmployeeType,bool? Active,bool? isRefProvider,bool? IsEmployee, int? Page=1, int? Size=100, string? SortColumn= "EmployeeId", string? SortOrder="ASC")

        {
            DynamicParameters param=   new DynamicParameters();
            DataSet ds = new DataSet();
            try
            {
                param.Add("@FullName", FullName, DbType.String);
                param.Add("@Gender", Gender, DbType.String);
                param.Add("@JoiningDate", JoiningDate, DbType.Date);
                param.Add("@Employeetype", EmployeeType,DbType.Int64);
                param.Add("@Email", Email, DbType.String);
                param.Add("@Phone", Phone, DbType.String);
                param.Add("@CellNo", CellNo, DbType.String);
                param.Add("@Active", Active, DbType.Boolean);
                param.Add("@isRefProvider", isRefProvider, DbType.Boolean);
                param.Add("@IsEmployee", IsEmployee, DbType.Boolean);
                param.Add("@Page", Page, DbType.Int64);
                param.Add("@Size", Size, DbType.Int64);
                param.Add("@SortColumn", SortColumn, DbType.String);
                param.Add("@SortOrder",SortOrder, DbType.String);




                ds = await DapperHelper.GetDataSetBySPWithParams("CP_SearchHREmployee", param);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    throw new Exception("No data exist");
                }

            }
            catch (Exception ex)
            {

               // throw ex;
            }
         
            return ds;

        }


        public async Task<bool> Delete(long employeeId)
        {
            DynamicParameters param = new DynamicParameters();

            try
            {
                param.Add("@EmployeeId", employeeId, DbType.Int64);



                bool result = await DapperHelper.ExcecuteSPByParams("CP_DeleteHREmployee", param);

                return result;
            }
            catch (Exception ex)
            {

return false;             }
        

        }



        public async Task<bool> DeleteLicense(long HRlicenseID)
        {
            DynamicParameters param = new DynamicParameters();

            try
            {
                param.Add("@HRlicenseID", HRlicenseID, DbType.Int64);



                bool result = await DapperHelper.ExcecuteSPByParams("CP_DeleteHRLicense", param);

                return result;
            }
            catch (Exception ex)
            {

                return false;
            
            }


        }
        public  async Task<string> UpdateUserDB( HREmployee hremp)
        {
          
            try
            {

                  DataTable EmployeeFacilityDT = ConversionHelper.ToDataTable(hremp.EmployeeFacility);

            DataTable LicenseInfoDT = ConversionHelper.ToDataTable(hremp.LicenseInfo);

            DataTable SecEmployeeRoleDT = ConversionHelper.ToDataTable(hremp.EmployeeRole);
                HREmployee EMP = new HREmployee();
                EMP = hremp;

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("EmployeeId", EMP.EmployeeId, DbType.Int64);

                parameters.Add("EmployeeType", EMP.EmployeeType, DbType.Int64);

                parameters.Add("FullName", EMP.FullName, DbType.String);

                parameters.Add("ArFullName", EMP.ArFullName, DbType.String);

                parameters.Add("IsEmployee", EMP.IsEmployee, DbType.Boolean);

                parameters.Add("Credential", EMP.Credential, DbType.String);

                parameters.Add("Nic", EMP.Nic, DbType.String);

                parameters.Add("CityID", EMP.CityID, DbType.Int64);

                parameters.Add("CountryID", EMP.CountryID, DbType.Int64);

                parameters.Add("StateID", EMP.StateID, DbType.String);

                parameters.Add("ZipCode", EMP.ZipCode, DbType.String);

                parameters.Add("CellNo", EMP.CellNo, DbType.String);
   
                parameters.Add("Phone", EMP.Phone, DbType.String);

                parameters.Add("Fax", EMP.Fax, DbType.String);

                parameters.Add("DriversLicenseNo", EMP.DriversLicenseNo, DbType.String);

                parameters.Add("DOB", EMP.DOB, DbType.DateTime);

                parameters.Add("Gender", EMP.Gender, DbType.String);

                parameters.Add("BloodGroup", EMP.BloodGroup, DbType.String);

                parameters.Add("MaritalStatus", EMP.MaritalStatus, DbType.String);

                parameters.Add("Active", EMP.Active, DbType.Boolean);

                parameters.Add("UserName", EMP.UserName, DbType.String);

                parameters.Add("Password", EMP.Password, DbType.String);
 
                parameters.Add("HomeAddress1", EMP.HomeAddress1, DbType.String);

                parameters.Add("HomeAddress2", EMP.HomeAddress2, DbType.String);

                parameters.Add("IsAdmin", EMP.IsAdmin, DbType.Boolean);

                parameters.Add("HomePager", EMP.HomePager, DbType.String);

                parameters.Add("EmerRelationship", EMP.EmerRelationship, DbType.String);

                parameters.Add("EmerFullName", EMP.EmerFullName, DbType.String);

                parameters.Add("EmerAddress1", EMP.EmerAddress1, DbType.String);

                parameters.Add("EmerAddress2", EMP.EmerAddress2, DbType.String);

                parameters.Add("EmerCountryId", EMP.EmerCountryId, DbType.Int64);

                parameters.Add("EmerStateId", EMP.EmerStateId, DbType.Int64);

                parameters.Add("EmerCityId", EMP.EmerCityId, DbType.Int64);

                parameters.Add("EmerZipCode", EMP.EmerZipCode, DbType.String);

                parameters.Add("EmerPhone", EMP.EmerPhone, DbType.String);

                parameters.Add("EmerCellPhone", EMP.EmerCellPhone, DbType.String);

                parameters.Add("EmerPager", EMP.EmerPager, DbType.String);

                parameters.Add("EmerFax", EMP.EmerFax, DbType.String);

                parameters.Add("IsPerson", EMP.IsPerson, DbType.String);

                parameters.Add("IsRefProvider", EMP.IsRefProvider, DbType.Boolean);

                parameters.Add("VIPPatientAccess", EMP.VIPPatientAccess, DbType.Boolean);

                parameters.Add("JoiningDate", EMP.JoiningDate, DbType.DateTime);

                parameters.Add("PassPortNo", EMP.PassPortNo, DbType.String);

                parameters.Add("BusAddress1", EMP.BusAddress1, DbType.String);

                parameters.Add("BusAddress2", EMP.BusAddress2, DbType.String);

                parameters.Add("BusCountryId", EMP.BusCountryId, DbType.Int64);

                parameters.Add("BusCityId", EMP.BusCityId, DbType.Int64);

                parameters.Add("BusStateId", EMP.BusStateId, DbType.Int64);

                parameters.Add("BusZipCode", EMP.BusZipCode, DbType.String);

                parameters.Add("BusPhone", EMP.BusPhone, DbType.String);

                parameters.Add("BusCellPhone", EMP.BusCellPhone, DbType.String);

                parameters.Add("BusPager", EMP.BusPager, DbType.String);

                parameters.Add("BusFax", EMP.BusFax, DbType.String);

                parameters.Add("@HREmployeeFacilityTypeVar", EmployeeFacilityDT, DbType.Object);

             parameters.Add("@HRLicenseInfoTypeVar", LicenseInfoDT, DbType.Object);

               parameters.Add("@SecEmployeeRoleTypeVar", SecEmployeeRoleDT, DbType.Object);

                bool res = await DapperHelper.ExcecuteSPByParams("CP_UpdateHREmployee", parameters);

                if (res == true)
                {
                    return "OK";
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                
                return (ex.Message);
            }




        }





        public async Task<DataSet> GetLicenseByID(long HRlicenseID)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@HRlicenseID", HRlicenseID, DbType.Int32);

                //DataSet ds = await DapperHelper.GetDataSetBySP("GetEmployeesById", EmployeeId);

                DataSet ds = await DapperHelper.GetDataSetBySPWithParams("CP_GetLicenseByID", parameters);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    throw new Exception("No data exist of such ID");
                }

                return ds;
            }
            catch (Exception ex)
            {
                // Handle the exception as necessary
                // Console.WriteLine($"An error occurred: {ex.Message}");
                // or throw a different exception, log the error, etc.
                return new DataSet();
            }
        }


    }
       

}
    
